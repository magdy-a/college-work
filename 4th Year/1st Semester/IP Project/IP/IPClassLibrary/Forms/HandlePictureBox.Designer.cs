namespace IPClassLibrary.Forms
{
    partial class HandlePictureBox
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pbMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(336, 214);
            this.pnlMain.TabIndex = 1;
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(0, 0);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(334, 213);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandlePictureBox_MouseDown);
            this.pbMain.MouseEnter += new System.EventHandler(this.PbMain_MouseEnter);
            this.pbMain.MouseLeave += new System.EventHandler(this.pbMain_MouseLeave);
            this.pbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HandlePictureBox_MouseMove);
            // 
            // HandlePictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(336, 214);
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Name = "HandlePictureBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeChanged += new System.EventHandler(this.HandlePictureBox_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandlePictureBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HandlePictureBox_MouseMove);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pbMain;

    }
}