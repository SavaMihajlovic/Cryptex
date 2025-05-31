namespace EncryptionApp
{
    partial class Form2
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cBoxFSW = new System.Windows.Forms.CheckBox();
            this.btnBrowseOutputFile = new System.Windows.Forms.Button();
            this.gBox2 = new System.Windows.Forms.GroupBox();
            this.rbDecrypt = new System.Windows.Forms.RadioButton();
            this.rbEncrypt = new System.Windows.Forms.RadioButton();
            this.btnAutoGen = new System.Windows.Forms.Button();
            this.tbInputFile = new System.Windows.Forms.TextBox();
            this.lbl5 = new System.Windows.Forms.Label();
            this.btnBrowseInputFile = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnCrypt = new System.Windows.Forms.Button();
            this.gBox1 = new System.Windows.Forms.GroupBox();
            this.rbA52 = new System.Windows.Forms.RadioButton();
            this.rbDT = new System.Windows.Forms.RadioButton();
            this.tbOutputFile = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnBrowseSendFile = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tbFileToSend = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gBox2.SuspendLayout();
            this.gBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(8, 5);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(878, 565);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.cBoxFSW);
            this.tabPage1.Controls.Add(this.btnBrowseOutputFile);
            this.tabPage1.Controls.Add(this.gBox2);
            this.tabPage1.Controls.Add(this.btnAutoGen);
            this.tabPage1.Controls.Add(this.tbInputFile);
            this.tabPage1.Controls.Add(this.lbl5);
            this.tabPage1.Controls.Add(this.btnBrowseInputFile);
            this.tabPage1.Controls.Add(this.btnDecrypt);
            this.tabPage1.Controls.Add(this.btnCrypt);
            this.tabPage1.Controls.Add(this.gBox1);
            this.tabPage1.Controls.Add(this.tbOutputFile);
            this.tabPage1.Controls.Add(this.tb2);
            this.tabPage1.Controls.Add(this.tb1);
            this.tabPage1.Controls.Add(this.lbl4);
            this.tabPage1.Controls.Add(this.lbl2);
            this.tabPage1.Controls.Add(this.lbl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(870, 528);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // cBoxFSW
            // 
            this.cBoxFSW.AutoSize = true;
            this.cBoxFSW.Location = new System.Drawing.Point(570, 88);
            this.cBoxFSW.Name = "cBoxFSW";
            this.cBoxFSW.Size = new System.Drawing.Size(71, 24);
            this.cBoxFSW.TabIndex = 33;
            this.cBoxFSW.Text = "FSW";
            this.cBoxFSW.UseVisualStyleBackColor = true;
            // 
            // btnBrowseOutputFile
            // 
            this.btnBrowseOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutputFile.Location = new System.Drawing.Point(680, 371);
            this.btnBrowseOutputFile.Name = "btnBrowseOutputFile";
            this.btnBrowseOutputFile.Size = new System.Drawing.Size(145, 36);
            this.btnBrowseOutputFile.TabIndex = 32;
            this.btnBrowseOutputFile.Text = "Browse";
            this.btnBrowseOutputFile.UseVisualStyleBackColor = true;
            this.btnBrowseOutputFile.Click += new System.EventHandler(this.btnBrowseOutputFile_Click);
            // 
            // gBox2
            // 
            this.gBox2.Controls.Add(this.rbDecrypt);
            this.gBox2.Controls.Add(this.rbEncrypt);
            this.gBox2.Location = new System.Drawing.Point(309, 53);
            this.gBox2.Name = "gBox2";
            this.gBox2.Size = new System.Drawing.Size(207, 106);
            this.gBox2.TabIndex = 31;
            this.gBox2.TabStop = false;
            this.gBox2.Text = "Operation";
            // 
            // rbDecrypt
            // 
            this.rbDecrypt.AutoSize = true;
            this.rbDecrypt.Location = new System.Drawing.Point(17, 72);
            this.rbDecrypt.Name = "rbDecrypt";
            this.rbDecrypt.Size = new System.Drawing.Size(89, 24);
            this.rbDecrypt.TabIndex = 1;
            this.rbDecrypt.TabStop = true;
            this.rbDecrypt.Text = "Decrypt";
            this.rbDecrypt.UseVisualStyleBackColor = true;
            // 
            // rbEncrypt
            // 
            this.rbEncrypt.AutoSize = true;
            this.rbEncrypt.Location = new System.Drawing.Point(17, 34);
            this.rbEncrypt.Name = "rbEncrypt";
            this.rbEncrypt.Size = new System.Drawing.Size(88, 24);
            this.rbEncrypt.TabIndex = 0;
            this.rbEncrypt.TabStop = true;
            this.rbEncrypt.Text = "Encrypt";
            this.rbEncrypt.UseVisualStyleBackColor = true;
            // 
            // btnAutoGen
            // 
            this.btnAutoGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoGen.Location = new System.Drawing.Point(446, 223);
            this.btnAutoGen.Name = "btnAutoGen";
            this.btnAutoGen.Size = new System.Drawing.Size(195, 35);
            this.btnAutoGen.TabIndex = 30;
            this.btnAutoGen.Text = "Auto generate keys";
            this.btnAutoGen.UseVisualStyleBackColor = true;
            this.btnAutoGen.Click += new System.EventHandler(this.btnAutoGen_Click);
            // 
            // tbInputFile
            // 
            this.tbInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInputFile.Location = new System.Drawing.Point(179, 316);
            this.tbInputFile.Name = "tbInputFile";
            this.tbInputFile.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbInputFile.Size = new System.Drawing.Size(462, 26);
            this.tbInputFile.TabIndex = 29;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(46, 317);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(105, 22);
            this.lbl5.TabIndex = 28;
            this.lbl5.Text = "File to read:";
            // 
            // btnBrowseInputFile
            // 
            this.btnBrowseInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseInputFile.Location = new System.Drawing.Point(680, 311);
            this.btnBrowseInputFile.Name = "btnBrowseInputFile";
            this.btnBrowseInputFile.Size = new System.Drawing.Size(145, 36);
            this.btnBrowseInputFile.TabIndex = 27;
            this.btnBrowseInputFile.Text = "Browse";
            this.btnBrowseInputFile.UseVisualStyleBackColor = true;
            this.btnBrowseInputFile.Click += new System.EventHandler(this.btnBrowseInputFile_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(496, 422);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(145, 36);
            this.btnDecrypt.TabIndex = 26;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnCrypt
            // 
            this.btnCrypt.Location = new System.Drawing.Point(179, 422);
            this.btnCrypt.Name = "btnCrypt";
            this.btnCrypt.Size = new System.Drawing.Size(145, 36);
            this.btnCrypt.TabIndex = 25;
            this.btnCrypt.Text = "Crypt";
            this.btnCrypt.UseVisualStyleBackColor = true;
            this.btnCrypt.Click += new System.EventHandler(this.btnCrypt_Click);
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.rbA52);
            this.gBox1.Controls.Add(this.rbDT);
            this.gBox1.Location = new System.Drawing.Point(50, 53);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(207, 106);
            this.gBox1.TabIndex = 24;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Algorithms";
            // 
            // rbA52
            // 
            this.rbA52.AutoSize = true;
            this.rbA52.Location = new System.Drawing.Point(17, 72);
            this.rbA52.Name = "rbA52";
            this.rbA52.Size = new System.Drawing.Size(67, 24);
            this.rbA52.TabIndex = 1;
            this.rbA52.TabStop = true;
            this.rbA52.Text = "A5/2";
            this.rbA52.UseVisualStyleBackColor = true;
            // 
            // rbDT
            // 
            this.rbDT.AutoSize = true;
            this.rbDT.Location = new System.Drawing.Point(17, 34);
            this.rbDT.Name = "rbDT";
            this.rbDT.Size = new System.Drawing.Size(184, 24);
            this.rbDT.TabIndex = 0;
            this.rbDT.TabStop = true;
            this.rbDT.Text = "Double Transposition";
            this.rbDT.UseVisualStyleBackColor = true;
            // 
            // tbOutputFile
            // 
            this.tbOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutputFile.Location = new System.Drawing.Point(179, 376);
            this.tbOutputFile.Name = "tbOutputFile";
            this.tbOutputFile.Size = new System.Drawing.Size(462, 26);
            this.tbOutputFile.TabIndex = 23;
            // 
            // tb2
            // 
            this.tb2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb2.Location = new System.Drawing.Point(179, 257);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(216, 26);
            this.tb2.TabIndex = 22;
            // 
            // tb1
            // 
            this.tb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb1.Location = new System.Drawing.Point(179, 198);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(216, 26);
            this.tb1.TabIndex = 21;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(46, 377);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(97, 22);
            this.lbl4.TabIndex = 20;
            this.lbl4.Text = "Output file:";
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(46, 199);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(116, 22);
            this.lbl2.TabIndex = 19;
            this.lbl2.Text = "ColumnsKey:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(46, 258);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(91, 22);
            this.lbl1.TabIndex = 18;
            this.lbl1.Text = "RowsKey:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage3.Controls.Add(this.btnBrowseSendFile);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.tbFileToSend);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.btnSendFile);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.tb4);
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(870, 528);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Send";
            // 
            // btnBrowseSendFile
            // 
            this.btnBrowseSendFile.Location = new System.Drawing.Point(585, 143);
            this.btnBrowseSendFile.Name = "btnBrowseSendFile";
            this.btnBrowseSendFile.Size = new System.Drawing.Size(145, 36);
            this.btnBrowseSendFile.TabIndex = 25;
            this.btnBrowseSendFile.Text = "Browse";
            this.btnBrowseSendFile.UseVisualStyleBackColor = true;
            this.btnBrowseSendFile.Click += new System.EventHandler(this.btnBrowseSendFile_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Double Transposition",
            "A52"});
            this.comboBox1.Location = new System.Drawing.Point(156, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(345, 28);
            this.comboBox1.TabIndex = 24;
            // 
            // tbFileToSend
            // 
            this.tbFileToSend.Location = new System.Drawing.Point(156, 148);
            this.tbFileToSend.Name = "tbFileToSend";
            this.tbFileToSend.Size = new System.Drawing.Size(345, 26);
            this.tbFileToSend.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Fille to send:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Algorithm:";
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(156, 281);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(341, 57);
            this.btnSendFile.TabIndex = 19;
            this.btnSendFile.Text = "Send File";
            this.btnSendFile.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(537, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "IP Address:";
            // 
            // tb4
            // 
            this.tb4.Location = new System.Drawing.Point(156, 213);
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(345, 26);
            this.tb4.TabIndex = 15;
            this.tb4.Text = "127.0.0.1";
            this.tb4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(585, 213);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(195, 26);
            this.textBox3.TabIndex = 16;
            this.textBox3.Text = "5000";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(870, 528);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Receive";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(174, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(278, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "5000";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Port:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(878, 565);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gBox2.ResumeLayout(false);
            this.gBox2.PerformLayout();
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox cBoxFSW;
        private System.Windows.Forms.Button btnBrowseOutputFile;
        private System.Windows.Forms.GroupBox gBox2;
        private System.Windows.Forms.RadioButton rbDecrypt;
        private System.Windows.Forms.RadioButton rbEncrypt;
        private System.Windows.Forms.TextBox tbInputFile;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Button btnBrowseInputFile;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnCrypt;
        private System.Windows.Forms.GroupBox gBox1;
        private System.Windows.Forms.RadioButton rbA52;
        private System.Windows.Forms.RadioButton rbDT;
        private System.Windows.Forms.TextBox tbOutputFile;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnAutoGen;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox tbFileToSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnBrowseSendFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
    }
}