using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace RF_Power_Meter
{
    public partial class Form1 : Form
    {

        private SerialPort port = null;
        private double[] history = new double[300];

        public Form1()
        {
            InitializeComponent();
        }

        private String status(String text)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate { status(text); });
                    return text;
                }
                labelStatus.Text = text;
                Application.DoEvents();
            }
            catch(Exception e)
            {
                //ignore
            }
            return text;
        }
        private String bigNumber(String text)
        {
            try{ 
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate { bigNumber(text); });
                    return text;
                }
                labelBig.Text = text;
                Application.DoEvents();
            }
            catch (Exception e)
            {
                //ignore
            }
            return text;
        }

        private void sleep(int ms)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < ms)
                Application.DoEvents();
        }
        public char[] inputBuffer = new char[100];
        public int lastIndex = 0;
        public int prelastIndex(int howMuchBack)
        {
            int result = lastIndex - howMuchBack;
            while (result < 0)
                result += inputBuffer.Length;
            return result;
        }
        public void bufferChar(char c)
        {
            lastIndex++;
            if (lastIndex >= inputBuffer.Length)
                lastIndex = 0;
            inputBuffer[lastIndex] = c;
        }

        public char lastChar(int howMuchBack)
        {
            return inputBuffer[prelastIndex(howMuchBack)];
        }
        public bool send(String text)
        {
            if (port != null && port.IsOpen)
            {
                status("|#| <-- " + text);
                port.Write(text);
                return true;
            }
            return false;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            comboBoxListComs.Items.Clear();
            List<string> COMs = new List<string>();
            status("Получение портов...");
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                var portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());

                var portList = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();

                foreach (string s in portList)
                {
                    Console.WriteLine(s);
                    COMs.Add(s);
                }
            }

            int sel = 0;
            for (int i = 0; i < COMs.Count; i++)
            {
                String com = COMs[i];
                if (com.Contains("USB"))
                    sel = i;
                comboBoxListComs.Items.Add(com);
            }

            if (comboBoxListComs.Items.Count > 0)
                comboBoxListComs.SelectedIndex = sel;
            buttonConnect.Enabled = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (port == null)
            {
                try
                {
                    string selected = comboBoxListComs.SelectedItem.ToString();
                    status("Выбранный порт: " + selected);
                    sleep(100);
                    string name = selected.Split('-')[0].Trim();
                    status("Порт для покдлючения: " + name);
                    status("Подключение к порту: " + name + "...");
                    port = new SerialPort(name, 9600, Parity.None, 8, StopBits.One);
                    port.DataReceived += DataReceivedHandler;
                    port.DtrEnable = true;
                    //port.RtsEnable = true;
                    port.Open();
                    buttonConnect.Text = "Disconnect";
                    buttonSend.Enabled = true;
                    status("Подключено к " + name);
                }
                catch (Exception ex)
                {
                    status("Ошибка подключения: " + ex.Message);
                    port = null;
                }
            }
            else
            {
                try
                {
                    status("Отключение...");
                    port.DataReceived -= DataReceivedHandler;
                    sleep(100);
                    try { port.DiscardInBuffer(); } catch (Exception) { };
                    try { port.Dispose(); } catch (Exception) { };
                    try { port.DiscardInBuffer(); } catch (Exception) { };
                    port.Close();
                    port = null;
                    buttonConnect.Text = "Connect";
                    buttonSend.Enabled = false;
                    status("Отключено");
                }
                catch (Exception ex)
                {
                    status("Ошибка отключения: " + ex.Message);
                    port = null;
                }
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            while (sp.IsOpen && sp.BytesToRead > 0)
            {
                char inbyte = (char)sp.ReadByte();
                //log("Byte received: " + inbyte);
                bufferChar(inbyte);
                //когда нашли конец строки
                if (lastChar(0) == '\n')
                {
                    for (int i = 1; i < inputBuffer.Length; i++)//поиск начала строки
                    {
                        if (lastChar(i + 1) == '\n' || lastChar(i + 1) == '\0')//тут мы нашли начало строки
                        {
                            String line = "";   //получаем команду двигаясь от ячеек раньше к ячейкам новее
                            for (int j = i; j > 0; j--)
                                line += lastChar(j);
                            parseLine(line);
                            break;
                        }
                    }
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(port != null)
            {
                send(textBoxText.Text);
                textBoxText.Text = "";
            }
        }
        public static string getOnlyNumbers(string input)
        {
            StringBuilder stringBuilder = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
                if ((input[i] >= '0' && input[i] <= '9') || input[i] == '-' || input[i] == '.')
                    stringBuilder.Append(input[i]);

            return stringBuilder.ToString();
        }

        private void parseLine(String text)
        {
            text = text.Replace('\n', ' ').Trim();
            status("Получено |" + text + "|");
            text = getOnlyNumbers(text);
            text = text.Replace('.', ',');
            //корректный диапазон: 0 ... -90
            try
            {
                double value = Double.Parse(text);
                if (value > -90 && value < 0)
                {
                    bigNumber(value.ToString());
                    //value = rollingAverage(value);
                    for (int i = history.Length-1; i > 0; i--)
                        history[i] = history[i - 1];
                    history[0] = value;
                    drawGraph();
                }
            }
            catch (FormatException e)
            {
                status("Строка не распознана: |" + text + "|");
            }
        }

        double rollingAverageCurrent = -1;
        
        double rollingAverage(double current)
        {
            if(rollingAverageCurrent == -1)
                rollingAverageCurrent = current;

            double d = current - rollingAverageCurrent;
            rollingAverageCurrent += d * 0.2;
            return rollingAverageCurrent;
        }


        void drawGraph()
        {
            //pictureBox1.Width  
            Bitmap _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics gr = Graphics.FromImage(_bitmap))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                double max = 5;
                double min = -60;
                double height = pictureBox1.Height;
                double width = pictureBox1.Width;


                {//draw main grid
                    Color color = Color.FromArgb(80, 0, 0, 0);
                    Pen gridPen = new Pen(color, 1);
                    Font gridFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
                    Brush gridTextBrush = new SolidBrush(color);
                    for (int value = -90; value < 0; value += 10)
                    {
                        double y = height * (value - min) / (max - min);
                        y = height - y;
                        gr.DrawLine(gridPen, (float)0, (float)y, (float)width, (float)y);
                        gr.DrawString(value + " dBm", gridFont, gridTextBrush, 10, (float)y);
                    }
                }


                {//draw sub grid
                    Color color = Color.FromArgb(30, 0, 0, 0);
                    Pen gridPen = new Pen(color, 1);
                    Font gridFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
                    Brush gridTextBrush = new SolidBrush(color);
                    for (int value = -85; value < 0; value += 10)
                    {
                        double y = height * (value - min) / (max - min);
                        y = height - y;
                        gr.DrawLine(gridPen, (float)0, (float)y, (float)width, (float)y);
                        gr.DrawString(value + " dBm", gridFont, gridTextBrush, 10, (float)y);
                    }
                }

                {//draw average for third
                    double sum = 0;
                    double cnt = 0;
                    double startX = 2 * width / 3;
                    Brush brush = new SolidBrush(Color.FromArgb(50, 0, 100, 0));
                    Brush brushLight = new SolidBrush(Color.FromArgb(15, 0, 255, 0));
                    Font font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular);
                    Font fontSmall = new Font(FontFamily.GenericSansSerif, 13, FontStyle.Regular);
                    Brush textBrush = new SolidBrush(Color.DarkGreen);

                    for (int i = 0; i < history.Length / 3; i++)
                    {
                        double value = history[i];
                        if (value != 0)
                        {
                            sum += value;
                            cnt++;
                        }
                    }
                    double avg = sum / cnt;
                    double y = height * (avg - min) / (max - min);
                    y = height - y;
                    gr.FillRectangle(brushLight, (float)startX, (float)0, (float)width / 3, (float)height);
                    gr.FillRectangle(brush, (float)startX, (float)y, (float)width / 3, (float)height - (float)y);
                    gr.DrawString(String.Format("{0:0.0}", avg) + " dBm", font, textBrush, (float)startX + 10, 10);
                    gr.DrawString("Average", fontSmall, textBrush, (float)startX + 10, 40);
                }


                {//draw data
                    Pen linePen = new Pen(Color.DarkBlue, 3);
                    double lx = -1;
                    double ly = -1;
                    for (int i = 0; i < history.Length; i++)
                    {
                        double value = history[i];
                        if (value != 0)
                        {
                            double x = i * width / history.Length;
                            x = width - x;
                            double y = height * (value - min) / (max - min);
                            y = height - y;
                            if (lx == -1)
                            {
                                lx = x;
                                ly = y;
                            }
                            gr.DrawLine(linePen, (float)lx, (float)ly, (float)x, (float)y);
                            lx = x;
                            ly = y;
                        }
                    }
                }
            }
            pictureBox1.Image = _bitmap;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //version
            {
                FileInfo f = new FileInfo(Application.ExecutablePath);
                Text = Text + " (Версия от " + f.LastWriteTime.ToShortDateString() + ")";
            }
        }
    }
}
