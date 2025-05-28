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
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tbOutputFile = new System.Windows.Forms.TextBox();
            this.gBox1 = new System.Windows.Forms.GroupBox();
            this.rbA52 = new System.Windows.Forms.RadioButton();
            this.rbDT = new System.Windows.Forms.RadioButton();
            this.btnCrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnBrowseInputFile = new System.Windows.Forms.Button();
            this.lbl5 = new System.Windows.Forms.Label();
            this.tbInputFile = new System.Windows.Forms.TextBox();
            this.btnAutoGen = new System.Windows.Forms.Button();
            this.gBox2 = new System.Windows.Forms.GroupBox();
            this.rbDecrypt = new System.Windows.Forms.RadioButton();
            this.rbEncrypt = new System.Windows.Forms.RadioButton();
            this.btnBrowseOutputFile = new System.Windows.Forms.Button();
            this.cBoxFSW = new System.Windows.Forms.CheckBox();
            this.gBox1.SuspendLayout();
            this.gBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(23, 238);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(91, 22);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "RowsKey:";
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(23, 179);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(116, 22);
            this.lbl2.TabIndex = 1;
            this.lbl2.Text = "ColumnsKey:";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(23, 357);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(97, 22);
            this.lbl4.TabIndex = 3;
            this.lbl4.Text = "Output file:";
            // 
            // tb1
            // 
            this.tb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb1.Location = new System.Drawing.Point(156, 178);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(216, 26);
            this.tb1.TabIndex = 4;
            // 
            // tb2
            // 
            this.tb2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb2.Location = new System.Drawing.Point(156, 237);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(216, 26);
            this.tb2.TabIndex = 5;
            // 
            // tbOutputFile
            // 
            this.tbOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutputFile.Location = new System.Drawing.Point(156, 356);
            this.tbOutputFile.Name = "tbOutputFile";
            this.tbOutputFile.Size = new System.Drawing.Size(462, 26);
            this.tbOutputFile.TabIndex = 7;
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.rbA52);
            this.gBox1.Controls.Add(this.rbDT);
            this.gBox1.Location = new System.Drawing.Point(27, 33);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(207, 106);
            this.gBox1.TabIndex = 8;
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
            // btnCrypt
            // 
            this.btnCrypt.Location = new System.Drawing.Point(156, 402);
            this.btnCrypt.Name = "btnCrypt";
            this.btnCrypt.Size = new System.Drawing.Size(145, 36);
            this.btnCrypt.TabIndex = 9;
            this.btnCrypt.Text = "Crypt";
            this.btnCrypt.UseVisualStyleBackColor = true;
            this.btnCrypt.Click += new System.EventHandler(this.btnCrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(473, 402);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(145, 36);
            this.btnDecrypt.TabIndex = 10;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnBrowseInputFile
            // 
            this.btnBrowseInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseInputFile.Location = new System.Drawing.Point(657, 291);
            this.btnBrowseInputFile.Name = "btnBrowseInputFile";
            this.btnBrowseInputFile.Size = new System.Drawing.Size(145, 36);
            this.btnBrowseInputFile.TabIndex = 11;
            this.btnBrowseInputFile.Text = "Browse";
            this.btnBrowseInputFile.UseVisualStyleBackColor = true;
            this.btnBrowseInputFile.Click += new System.EventHandler(this.btnBrowseInputFile_Click);
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(23, 297);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(105, 22);
            this.lbl5.TabIndex = 12;
            this.lbl5.Text = "File to read:";
            // 
            // tbInputFile
            // 
            this.tbInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInputFile.Location = new System.Drawing.Point(156, 296);
            this.tbInputFile.Name = "tbInputFile";
            this.tbInputFile.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbInputFile.Size = new System.Drawing.Size(462, 26);
            this.tbInputFile.TabIndex = 13;
            // 
            // btnAutoGen
            // 
            this.btnAutoGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoGen.Location = new System.Drawing.Point(423, 207);
            this.btnAutoGen.Name = "btnAutoGen";
            this.btnAutoGen.Size = new System.Drawing.Size(195, 35);
            this.btnAutoGen.TabIndex = 14;
            this.btnAutoGen.Text = "Auto generate keys";
            this.btnAutoGen.UseVisualStyleBackColor = true;
            this.btnAutoGen.Click += new System.EventHandler(this.btnAutoGen_Click);
            // 
            // gBox2
            // 
            this.gBox2.Controls.Add(this.rbDecrypt);
            this.gBox2.Controls.Add(this.rbEncrypt);
            this.gBox2.Location = new System.Drawing.Point(286, 33);
            this.gBox2.Name = "gBox2";
            this.gBox2.Size = new System.Drawing.Size(207, 106);
            this.gBox2.TabIndex = 15;
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
            // btnBrowseOutputFile
            // 
            this.btnBrowseOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutputFile.Location = new System.Drawing.Point(657, 351);
            this.btnBrowseOutputFile.Name = "btnBrowseOutputFile";
            this.btnBrowseOutputFile.Size = new System.Drawing.Size(145, 36);
            this.btnBrowseOutputFile.TabIndex = 16;
            this.btnBrowseOutputFile.Text = "Browse";
            this.btnBrowseOutputFile.UseVisualStyleBackColor = true;
            this.btnBrowseOutputFile.Click += new System.EventHandler(this.btnBrowseOutputFile_Click);
            // 
            // cBoxFSW
            // 
            this.cBoxFSW.AutoSize = true;
            this.cBoxFSW.Location = new System.Drawing.Point(547, 68);
            this.cBoxFSW.Name = "cBoxFSW";
            this.cBoxFSW.Size = new System.Drawing.Size(71, 24);
            this.cBoxFSW.TabIndex = 17;
            this.cBoxFSW.Text = "FSW";
            this.cBoxFSW.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(878, 483);
            this.Controls.Add(this.cBoxFSW);
            this.Controls.Add(this.btnBrowseOutputFile);
            this.Controls.Add(this.gBox2);
            this.Controls.Add(this.btnAutoGen);
            this.Controls.Add(this.tbInputFile);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.btnBrowseInputFile);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnCrypt);
            this.Controls.Add(this.gBox1);
            this.Controls.Add(this.tbOutputFile);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            this.gBox2.ResumeLayout(false);
            this.gBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tbOutputFile;
        private System.Windows.Forms.GroupBox gBox1;
        private System.Windows.Forms.Button btnCrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnBrowseInputFile;
        private System.Windows.Forms.RadioButton rbA52;
        private System.Windows.Forms.RadioButton rbDT;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.TextBox tbInputFile;
        private System.Windows.Forms.Button btnAutoGen;
        private System.Windows.Forms.GroupBox gBox2;
        private System.Windows.Forms.RadioButton rbDecrypt;
        private System.Windows.Forms.RadioButton rbEncrypt;
        private System.Windows.Forms.Button btnBrowseOutputFile;
        private System.Windows.Forms.CheckBox cBoxFSW;
    }
}