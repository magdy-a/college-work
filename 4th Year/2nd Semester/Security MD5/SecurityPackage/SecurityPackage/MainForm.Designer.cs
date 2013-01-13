namespace SecurityPackage
{
    partial class MainForm
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
            this.txtPlain = new System.Windows.Forms.TextBox();
            this.txtCipher = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.lblPlainText = new System.Windows.Forms.Label();
            this.lblCipherText = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPlain
            // 
            this.txtPlain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlain.Location = new System.Drawing.Point(106, 16);
            this.txtPlain.Name = "txtPlain";
            this.txtPlain.Size = new System.Drawing.Size(160, 20);
            this.txtPlain.TabIndex = 0;
            // 
            // txtCipher
            // 
            this.txtCipher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCipher.Location = new System.Drawing.Point(106, 65);
            this.txtCipher.Name = "txtCipher";
            this.txtCipher.Size = new System.Drawing.Size(160, 20);
            this.txtCipher.TabIndex = 1;
            // 
            // txtKey
            // 
            this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKey.Location = new System.Drawing.Point(106, 111);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(160, 20);
            this.txtKey.TabIndex = 2;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEncrypt.Location = new System.Drawing.Point(15, 154);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.BtnEncrypt_Click);
            // 
            // lblPlainText
            // 
            this.lblPlainText.AutoSize = true;
            this.lblPlainText.Location = new System.Drawing.Point(12, 19);
            this.lblPlainText.Name = "lblPlainText";
            this.lblPlainText.Size = new System.Drawing.Size(60, 13);
            this.lblPlainText.TabIndex = 2;
            this.lblPlainText.Text = "Plain Text: ";
            // 
            // lblCipherText
            // 
            this.lblCipherText.AutoSize = true;
            this.lblCipherText.Location = new System.Drawing.Point(12, 68);
            this.lblCipherText.Name = "lblCipherText";
            this.lblCipherText.Size = new System.Drawing.Size(67, 13);
            this.lblCipherText.TabIndex = 2;
            this.lblCipherText.Text = "Cipher Text: ";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(12, 114);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(31, 13);
            this.lblKey.TabIndex = 2;
            this.lblKey.Text = "Key: ";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecrypt.Location = new System.Drawing.Point(191, 154);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 4;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 189);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.lblCipherText);
            this.Controls.Add(this.lblPlainText);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtCipher);
            this.Controls.Add(this.txtPlain);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlain;
        private System.Windows.Forms.TextBox txtCipher;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label lblPlainText;
        private System.Windows.Forms.Label lblCipherText;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button btnDecrypt;
    }
}

