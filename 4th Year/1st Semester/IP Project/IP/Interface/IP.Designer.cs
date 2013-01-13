namespace PhotoLab
{
    /// <summary>
    /// The Designer Class of BilinearResize
    /// </summary>
    partial class IPForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPForm));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.lblNewSize = new System.Windows.Forms.ToolStripLabel();
            this.txtNewWidth = new System.Windows.Forms.ToolStripTextBox();
            this.lblComma = new System.Windows.Forms.ToolStripLabel();
            this.txtNewHeight = new System.Windows.Forms.ToolStripTextBox();
            this.separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbResizeType = new System.Windows.Forms.ToolStripComboBox();
            this.btnResize = new System.Windows.Forms.ToolStripButton();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lblOriginalSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLogger = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblErrorMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnSave,
            this.lblNewSize,
            this.txtNewWidth,
            this.lblComma,
            this.txtNewHeight,
            this.separator2,
            this.cmbResizeType,
            this.btnResize});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(599, 25);
            this.tsMain.TabIndex = 10;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(40, 22);
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblNewSize
            // 
            this.lblNewSize.Name = "lblNewSize";
            this.lblNewSize.Size = new System.Drawing.Size(91, 22);
            this.lblNewSize.Text = "NewSize (W,H): ";
            // 
            // txtNewWidth
            // 
            this.txtNewWidth.Name = "txtNewWidth";
            this.txtNewWidth.Size = new System.Drawing.Size(40, 25);
            this.txtNewWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IPForm_KeyDown);
            // 
            // lblComma
            // 
            this.lblComma.Name = "lblComma";
            this.lblComma.Size = new System.Drawing.Size(10, 22);
            this.lblComma.Text = ",";
            // 
            // txtNewHeight
            // 
            this.txtNewHeight.Name = "txtNewHeight";
            this.txtNewHeight.Size = new System.Drawing.Size(40, 25);
            this.txtNewHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IPForm_KeyDown);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cmbResizeType
            // 
            this.cmbResizeType.Name = "cmbResizeType";
            this.cmbResizeType.Size = new System.Drawing.Size(75, 25);
            // 
            // btnResize
            // 
            this.btnResize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnResize.Image = ((System.Drawing.Image)(resources.GetObject("btnResize.Image")));
            this.btnResize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(43, 22);
            this.btnResize.Text = "Resize";
            this.btnResize.Click += new System.EventHandler(this.BtnResize_Click);
            // 
            // ssMain
            // 
            this.ssMain.BackColor = System.Drawing.Color.White;
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblOriginalSize,
            this.lblLogger,
            this.lblErrorMessage});
            this.ssMain.Location = new System.Drawing.Point(0, 295);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(599, 22);
            this.ssMain.TabIndex = 11;
            this.ssMain.Text = "ssMain";
            // 
            // lblOriginalSize
            // 
            this.lblOriginalSize.Name = "lblOriginalSize";
            this.lblOriginalSize.Size = new System.Drawing.Size(0, 17);
            // 
            // lblLogger
            // 
            this.lblLogger.Name = "lblLogger";
            this.lblLogger.Size = new System.Drawing.Size(0, 17);
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // IPForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(599, 317);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.tsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(594, 331);
            this.Name = "IPForm";
            this.Text = "IP";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.IPForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.IPForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IPForm_KeyDown);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripLabel lblNewSize;
        private System.Windows.Forms.ToolStripTextBox txtNewWidth;
        private System.Windows.Forms.ToolStripLabel lblComma;
        private System.Windows.Forms.ToolStripTextBox txtNewHeight;
        private System.Windows.Forms.ToolStripSeparator separator2;
        private System.Windows.Forms.ToolStripComboBox cmbResizeType;
        private System.Windows.Forms.ToolStripButton btnResize;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel lblOriginalSize;
        private System.Windows.Forms.ToolStripStatusLabel lblLogger;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripStatusLabel lblErrorMessage;
    }
}