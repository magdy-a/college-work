namespace MD5HashGenerator
{
    partial class MD5HashGeneratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MD5HashGeneratorForm));
            this.btnMD5Encrypt = new System.Windows.Forms.Button();
            this.txtPlain = new System.Windows.Forms.TextBox();
            this.txtMD5Hash = new System.Windows.Forms.TextBox();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMD5Encrypt
            // 
            this.btnMD5Encrypt.BackColor = System.Drawing.Color.White;
            this.btnMD5Encrypt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMD5Encrypt.BackgroundImage")));
            this.btnMD5Encrypt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMD5Encrypt.FlatAppearance.BorderSize = 0;
            this.btnMD5Encrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMD5Encrypt.Location = new System.Drawing.Point(3, 2);
            this.btnMD5Encrypt.Name = "btnMD5Encrypt";
            this.btnMD5Encrypt.Size = new System.Drawing.Size(53, 50);
            this.btnMD5Encrypt.TabIndex = 0;
            this.btnMD5Encrypt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMD5Encrypt.UseVisualStyleBackColor = false;
            this.btnMD5Encrypt.Click += new System.EventHandler(this.BtnMD5Encrypt_Click);
            this.btnMD5Encrypt.MouseLeave += new System.EventHandler(this.BtnStyle_MouseLeave);
            this.btnMD5Encrypt.MouseHover += new System.EventHandler(this.BtnStyle_MouseHover);
            // 
            // txtPlain
            // 
            this.txtPlain.Location = new System.Drawing.Point(62, 6);
            this.txtPlain.Name = "txtPlain";
            this.txtPlain.Size = new System.Drawing.Size(172, 20);
            this.txtPlain.TabIndex = 1;
            // 
            // txtMD5Hash
            // 
            this.txtMD5Hash.Location = new System.Drawing.Point(62, 32);
            this.txtMD5Hash.Name = "txtMD5Hash";
            this.txtMD5Hash.Size = new System.Drawing.Size(202, 20);
            this.txtMD5Hash.TabIndex = 1;
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.Transparent;
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackground.Controls.Add(this.btnClose);
            this.pnlBackground.Controls.Add(this.txtPlain);
            this.pnlBackground.Controls.Add(this.txtMD5Hash);
            this.pnlBackground.Controls.Add(this.btnMD5Encrypt);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(269, 60);
            this.pnlBackground.TabIndex = 2;
            this.pnlBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MD5HashGeneratorForm_MouseDown);
            this.pnlBackground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MD5HashGeneratorForm_MouseMove);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(240, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.BtnStyle_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.BtnStyle_MouseHover);
            // 
            // MD5HashGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(269, 60);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MD5HashGeneratorForm";
            this.Text = "MD5HashGenerator";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MD5HashGeneratorForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MD5HashGeneratorForm_MouseMove);
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMD5Encrypt;
        private System.Windows.Forms.TextBox txtPlain;
        private System.Windows.Forms.TextBox txtMD5Hash;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Button btnClose;
    }
}

