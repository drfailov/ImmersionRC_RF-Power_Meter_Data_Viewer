
namespace RF_Power_Meter
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBoxListComs = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelBig = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxListComs
            // 
            this.comboBoxListComs.FormattingEnabled = true;
            this.comboBoxListComs.Location = new System.Drawing.Point(56, 39);
            this.comboBoxListComs.Name = "comboBoxListComs";
            this.comboBoxListComs.Size = new System.Drawing.Size(155, 21);
            this.comboBoxListComs.TabIndex = 1;
            // 
            // labelStatus
            // 
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelStatus.Location = new System.Drawing.Point(0, 523);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(1029, 30);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Ready";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelStatus.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(9, 35);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(155, 20);
            this.textBoxText.TabIndex = 4;
            this.textBoxText.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Commands:\r\n\'1\' is enabling output\r\n\'0\' is disabling output";
            // 
            // labelBig
            // 
            this.labelBig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBig.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBig.Location = new System.Drawing.Point(3, 16);
            this.labelBig.Name = "labelBig";
            this.labelBig.Size = new System.Drawing.Size(153, 105);
            this.labelBig.TabIndex = 7;
            this.labelBig.Text = "-00.00";
            this.labelBig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelBig);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(800, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 124);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current value";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(156, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 105);
            this.label2.TabIndex = 8;
            this.label2.Text = "dBm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1029, 144);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 144);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(1029, 379);
            this.panel2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Text to send";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "COM port:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSend);
            this.groupBox2.Controls.Add(this.textBoxText);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(353, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 123);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send commands";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1019, 369);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Image = global::RF_Power_Meter.Properties.Resources.refresh_button;
            this.buttonLoad.Location = new System.Drawing.Point(10, 21);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(40, 40);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Enabled = false;
            this.buttonConnect.Image = global::RF_Power_Meter.Properties.Resources.web_link;
            this.buttonConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConnect.Location = new System.Drawing.Point(217, 21);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Padding = new System.Windows.Forms.Padding(5);
            this.buttonConnect.Size = new System.Drawing.Size(112, 40);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Image = global::RF_Power_Meter.Properties.Resources.angle_pointing_to_right;
            this.buttonSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSend.Location = new System.Drawing.Point(170, 21);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Padding = new System.Windows.Forms.Padding(5);
            this.buttonSend.Size = new System.Drawing.Size(76, 35);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Send";
            this.buttonSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.buttonLoad);
            this.groupBox3.Controls.Add(this.buttonConnect);
            this.groupBox3.Controls.Add(this.comboBoxListComs);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 123);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Device";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 52);
            this.label5.TabIndex = 11;
            this.label5.Text = "1) Connect device to USB\r\n2) Refresh device list and select RF-Power meter\r\n3) Co" +
    "nnect to RF-Power meter\r\n4) Send commands to activate data transmission\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 553);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Immersion RC RF-Power meter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ComboBox comboBoxListComs;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelBig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
    }
}

