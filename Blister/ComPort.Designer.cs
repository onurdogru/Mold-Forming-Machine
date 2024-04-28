namespace Blister
{
    partial class ComPort
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComPort));
            this.lblStatusCom1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnAyar = new System.Windows.Forms.Button();
            this.timerAdmin = new System.Windows.Forms.Timer(this.components);
            this.label30 = new System.Windows.Forms.Label();
            this.admin = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.projectNameTxt = new System.Windows.Forms.TextBox();
            this.comboBoxSelectedProductCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSelectedProductAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.loopTimer = new System.Windows.Forms.Timer(this.components);
            this.txProductedAmount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox7.SuspendLayout();
            this.admin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatusCom1
            // 
            this.lblStatusCom1.AutoSize = true;
            this.lblStatusCom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusCom1.Location = new System.Drawing.Point(212, 102);
            this.lblStatusCom1.Name = "lblStatusCom1";
            this.lblStatusCom1.Size = new System.Drawing.Size(65, 29);
            this.lblStatusCom1.TabIndex = 0;
            this.lblStatusCom1.Text = "OFF";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LimeGreen;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStart.Location = new System.Drawing.Point(85, 350);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(269, 58);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rtbConsole);
            this.groupBox7.Location = new System.Drawing.Point(445, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(457, 552);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Operator Output";
            // 
            // rtbConsole
            // 
            this.rtbConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.rtbConsole.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbConsole.ForeColor = System.Drawing.Color.White;
            this.rtbConsole.Location = new System.Drawing.Point(11, 16);
            this.rtbConsole.Margin = new System.Windows.Forms.Padding(0);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.Size = new System.Drawing.Size(440, 533);
            this.rtbConsole.TabIndex = 46;
            this.rtbConsole.TabStop = false;
            this.rtbConsole.Text = "";
            this.rtbConsole.TextChanged += new System.EventHandler(this.rtbConsole_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(153, 68);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 20);
            this.textBox1.TabIndex = 46;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.Location = new System.Drawing.Point(266, 18);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(140, 45);
            this.btnCikis.TabIndex = 45;
            this.btnCikis.Text = "ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnAyar
            // 
            this.btnAyar.BackColor = System.Drawing.Color.Aqua;
            this.btnAyar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAyar.Location = new System.Drawing.Point(9, 18);
            this.btnAyar.Name = "btnAyar";
            this.btnAyar.Size = new System.Drawing.Size(148, 45);
            this.btnAyar.TabIndex = 6;
            this.btnAyar.Text = "AYARLAR";
            this.btnAyar.UseVisualStyleBackColor = false;
            this.btnAyar.Click += new System.EventHandler(this.btnAyar_Click);
            // 
            // timerAdmin
            // 
            this.timerAdmin.Tick += new System.EventHandler(this.timerAdmin_Tick_1);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(113, 102);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(93, 29);
            this.label30.TabIndex = 46;
            this.label30.Text = "COM1:";
            // 
            // admin
            // 
            this.admin.Controls.Add(this.btnCikis);
            this.admin.Controls.Add(this.textBox1);
            this.admin.Controls.Add(this.lblStatusCom1);
            this.admin.Controls.Add(this.label30);
            this.admin.Controls.Add(this.btnAyar);
            this.admin.Location = new System.Drawing.Point(18, 413);
            this.admin.Margin = new System.Windows.Forms.Padding(2);
            this.admin.Name = "admin";
            this.admin.Padding = new System.Windows.Forms.Padding(2);
            this.admin.Size = new System.Drawing.Size(411, 151);
            this.admin.TabIndex = 50;
            this.admin.TabStop = false;
            this.admin.Text = "Admin Kontrol";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Blister.Properties.Resources.alpnext_Logo_kopyası;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(52, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(338, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // projectNameTxt
            // 
            this.projectNameTxt.BackColor = System.Drawing.Color.Ivory;
            this.projectNameTxt.Enabled = false;
            this.projectNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.projectNameTxt.Location = new System.Drawing.Point(18, 153);
            this.projectNameTxt.Name = "projectNameTxt";
            this.projectNameTxt.Size = new System.Drawing.Size(411, 46);
            this.projectNameTxt.TabIndex = 55;
            this.projectNameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBoxSelectedProductCode
            // 
            this.comboBoxSelectedProductCode.FormattingEnabled = true;
            this.comboBoxSelectedProductCode.Items.AddRange(new object[] {
            "100000",
            "100001",
            "100002",
            "100003",
            "100004",
            "100005",
            "100006",
            "100007",
            "100008",
            "100009"});
            this.comboBoxSelectedProductCode.Location = new System.Drawing.Point(183, 251);
            this.comboBoxSelectedProductCode.Name = "comboBoxSelectedProductCode";
            this.comboBoxSelectedProductCode.Size = new System.Drawing.Size(171, 21);
            this.comboBoxSelectedProductCode.TabIndex = 56;
            this.comboBoxSelectedProductCode.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectedProductCode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Product Code";
            // 
            // textBoxSelectedProductAmount
            // 
            this.textBoxSelectedProductAmount.Location = new System.Drawing.Point(183, 286);
            this.textBoxSelectedProductAmount.Name = "textBoxSelectedProductAmount";
            this.textBoxSelectedProductAmount.Size = new System.Drawing.Size(171, 20);
            this.textBoxSelectedProductAmount.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Amount";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(183, 216);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(171, 20);
            this.textBoxStatus.TabIndex = 90;
            this.textBoxStatus.Text = "TARANIYOR";
            this.textBoxStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(88, 216);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 13);
            this.label19.TabIndex = 89;
            this.label19.Text = "Status";
            // 
            // loopTimer
            // 
            this.loopTimer.Tick += new System.EventHandler(this.loopTimer_Tick);
            // 
            // txProductedAmount
            // 
            this.txProductedAmount.Enabled = false;
            this.txProductedAmount.FormattingEnabled = true;
            this.txProductedAmount.Items.AddRange(new object[] {
            "10000000",
            "10000001",
            "10000002",
            "10000003",
            "10000004",
            "10000005",
            "10000006",
            "10000007",
            "10000008",
            "10000009"});
            this.txProductedAmount.Location = new System.Drawing.Point(183, 321);
            this.txProductedAmount.Name = "txProductedAmount";
            this.txProductedAmount.Size = new System.Drawing.Size(171, 21);
            this.txProductedAmount.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "Producted Amount";
            // 
            // ComPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(913, 571);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txProductedAmount);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSelectedProductAmount);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxSelectedProductCode);
            this.Controls.Add(this.projectNameTxt);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComPort";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FCT";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox7.ResumeLayout(false);
            this.admin.ResumeLayout(false);
            this.admin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lblStatusCom1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.Button btnAyar;
        private System.Windows.Forms.Timer timerAdmin;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox admin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox projectNameTxt;
        private System.Windows.Forms.ComboBox comboBoxSelectedProductCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSelectedProductAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Timer loopTimer;
        private System.Windows.Forms.ComboBox txProductedAmount;
        private System.Windows.Forms.Label label1;
    }
}

