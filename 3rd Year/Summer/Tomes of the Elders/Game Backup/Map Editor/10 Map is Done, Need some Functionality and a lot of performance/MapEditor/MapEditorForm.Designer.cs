namespace MapEditor
{
    partial class MapEditorForm
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
            this.pbTileset = new System.Windows.Forms.PictureBox();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.cmbPalette = new System.Windows.Forms.ComboBox();
            this.cmbTileset = new System.Windows.Forms.ComboBox();
            this.lblPalette = new System.Windows.Forms.Label();
            this.lblTileset = new System.Windows.Forms.Label();
            this.hScrollBarMap = new System.Windows.Forms.HScrollBar();
            this.vScrollBarMap = new System.Windows.Forms.VScrollBar();
            this.vScrollBarThumbnail = new System.Windows.Forms.VScrollBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCoordinates = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelBlank = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelObject = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbTileset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbTileset
            // 
            this.pbTileset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTileset.Location = new System.Drawing.Point(11, 140);
            this.pbTileset.Name = "pbTileset";
            this.pbTileset.Size = new System.Drawing.Size(160, 448);
            this.pbTileset.TabIndex = 0;
            this.pbTileset.TabStop = false;
            this.pbTileset.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbTileset_MouseClick);
            // 
            // pbMap
            // 
            this.pbMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMap.Location = new System.Drawing.Point(207, 43);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(800, 512);
            this.pbMap.TabIndex = 1;
            this.pbMap.TabStop = false;
            this.pbMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseClick);
            this.pbMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseMove);
            // 
            // cmbPalette
            // 
            this.cmbPalette.FormattingEnabled = true;
            this.cmbPalette.Location = new System.Drawing.Point(11, 63);
            this.cmbPalette.Name = "cmbPalette";
            this.cmbPalette.Size = new System.Drawing.Size(190, 24);
            this.cmbPalette.TabIndex = 2;
            this.cmbPalette.SelectedIndexChanged += new System.EventHandler(this.cmbPalette_SelectedIndexChanged);
            // 
            // cmbTileset
            // 
            this.cmbTileset.FormattingEnabled = true;
            this.cmbTileset.Location = new System.Drawing.Point(11, 110);
            this.cmbTileset.Name = "cmbTileset";
            this.cmbTileset.Size = new System.Drawing.Size(190, 24);
            this.cmbTileset.TabIndex = 3;
            this.cmbTileset.SelectedIndexChanged += new System.EventHandler(this.cmbTileset_SelectedIndexChanged);
            // 
            // lblPalette
            // 
            this.lblPalette.AutoSize = true;
            this.lblPalette.Location = new System.Drawing.Point(8, 43);
            this.lblPalette.Name = "lblPalette";
            this.lblPalette.Size = new System.Drawing.Size(52, 17);
            this.lblPalette.TabIndex = 4;
            this.lblPalette.Text = "Palette";
            // 
            // lblTileset
            // 
            this.lblTileset.AutoSize = true;
            this.lblTileset.Location = new System.Drawing.Point(11, 90);
            this.lblTileset.Name = "lblTileset";
            this.lblTileset.Size = new System.Drawing.Size(50, 17);
            this.lblTileset.TabIndex = 5;
            this.lblTileset.Text = "Tileset";
            // 
            // hScrollBarMap
            // 
            this.hScrollBarMap.Location = new System.Drawing.Point(207, 561);
            this.hScrollBarMap.Maximum = 1000;
            this.hScrollBarMap.Name = "hScrollBarMap";
            this.hScrollBarMap.Size = new System.Drawing.Size(800, 27);
            this.hScrollBarMap.TabIndex = 6;
            this.hScrollBarMap.Value = 1000;
            this.hScrollBarMap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarMap_Scroll);
            // 
            // vScrollBarMap
            // 
            this.vScrollBarMap.Location = new System.Drawing.Point(1010, 43);
            this.vScrollBarMap.Maximum = 1000;
            this.vScrollBarMap.Name = "vScrollBarMap";
            this.vScrollBarMap.Size = new System.Drawing.Size(27, 512);
            this.vScrollBarMap.TabIndex = 7;
            this.vScrollBarMap.Value = 1000;
            this.vScrollBarMap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarMap_Scroll);
            // 
            // vScrollBarThumbnail
            // 
            this.vScrollBarThumbnail.Location = new System.Drawing.Point(177, 140);
            this.vScrollBarThumbnail.Name = "vScrollBarThumbnail";
            this.vScrollBarThumbnail.Size = new System.Drawing.Size(27, 448);
            this.vScrollBarThumbnail.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCoordinates,
            this.toolStripStatusLabelBlank,
            this.toolStripStatusLabelObject});
            this.statusStrip1.Location = new System.Drawing.Point(0, 593);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1047, 25);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCoordinates
            // 
            this.toolStripStatusLabelCoordinates.Name = "toolStripStatusLabelCoordinates";
            this.toolStripStatusLabelCoordinates.Size = new System.Drawing.Size(223, 20);
            this.toolStripStatusLabelCoordinates.Text = "toolStripStatusLabelCoordinates";
            // 
            // toolStripStatusLabelBlank
            // 
            this.toolStripStatusLabelBlank.Name = "toolStripStatusLabelBlank";
            this.toolStripStatusLabelBlank.Size = new System.Drawing.Size(179, 20);
            this.toolStripStatusLabelBlank.Text = "toolStripStatusLabelBlank";
            // 
            // toolStripStatusLabelObject
            // 
            this.toolStripStatusLabelObject.Name = "toolStripStatusLabelObject";
            this.toolStripStatusLabelObject.Size = new System.Drawing.Size(187, 20);
            this.toolStripStatusLabelObject.Text = "toolStripStatusLabelObject";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1047, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 618);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.vScrollBarThumbnail);
            this.Controls.Add(this.vScrollBarMap);
            this.Controls.Add(this.hScrollBarMap);
            this.Controls.Add(this.lblTileset);
            this.Controls.Add(this.lblPalette);
            this.Controls.Add(this.cmbTileset);
            this.Controls.Add(this.cmbPalette);
            this.Controls.Add(this.pbMap);
            this.Controls.Add(this.pbTileset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.Name = "MapEditorForm";
            this.Text = "Map Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pbTileset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPalette;
        private System.Windows.Forms.ComboBox cmbTileset;
        private System.Windows.Forms.Label lblPalette;
        private System.Windows.Forms.Label lblTileset;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCoordinates;
        internal System.Windows.Forms.PictureBox pbMap;
        internal System.Windows.Forms.HScrollBar hScrollBarMap;
        internal System.Windows.Forms.VScrollBar vScrollBarMap;
        internal System.Windows.Forms.VScrollBar vScrollBarThumbnail;
        internal System.Windows.Forms.PictureBox pbTileset;
        internal System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelObject;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBlank;
    }
}

