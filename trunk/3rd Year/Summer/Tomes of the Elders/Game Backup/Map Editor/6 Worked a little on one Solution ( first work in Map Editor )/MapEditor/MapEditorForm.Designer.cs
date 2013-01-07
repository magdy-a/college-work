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
            ((System.ComponentModel.ISupportInitialize)(this.pbTileset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTileset
            // 
            this.pbTileset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTileset.Location = new System.Drawing.Point(12, 106);
            this.pbTileset.Name = "pbTileset";
            this.pbTileset.Size = new System.Drawing.Size(160, 437);
            this.pbTileset.TabIndex = 0;
            this.pbTileset.TabStop = false;
            // 
            // pbMap
            // 
            this.pbMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMap.Location = new System.Drawing.Point(189, 12);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(837, 531);
            this.pbMap.TabIndex = 1;
            this.pbMap.TabStop = false;
            // 
            // cmbPalette
            // 
            this.cmbPalette.FormattingEnabled = true;
            this.cmbPalette.Location = new System.Drawing.Point(12, 29);
            this.cmbPalette.Name = "cmbPalette";
            this.cmbPalette.Size = new System.Drawing.Size(160, 24);
            this.cmbPalette.TabIndex = 2;
            // 
            // cmbTileset
            // 
            this.cmbTileset.FormattingEnabled = true;
            this.cmbTileset.Location = new System.Drawing.Point(12, 76);
            this.cmbTileset.Name = "cmbTileset";
            this.cmbTileset.Size = new System.Drawing.Size(160, 24);
            this.cmbTileset.TabIndex = 3;
            // 
            // lblPalette
            // 
            this.lblPalette.AutoSize = true;
            this.lblPalette.Location = new System.Drawing.Point(12, 9);
            this.lblPalette.Name = "lblPalette";
            this.lblPalette.Size = new System.Drawing.Size(52, 17);
            this.lblPalette.TabIndex = 4;
            this.lblPalette.Text = "Palette";
            // 
            // lblTileset
            // 
            this.lblTileset.AutoSize = true;
            this.lblTileset.Location = new System.Drawing.Point(12, 56);
            this.lblTileset.Name = "lblTileset";
            this.lblTileset.Size = new System.Drawing.Size(50, 17);
            this.lblTileset.TabIndex = 5;
            this.lblTileset.Text = "Tileset";
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 555);
            this.Controls.Add(this.lblTileset);
            this.Controls.Add(this.lblPalette);
            this.Controls.Add(this.cmbTileset);
            this.Controls.Add(this.cmbPalette);
            this.Controls.Add(this.pbMap);
            this.Controls.Add(this.pbTileset);
            this.MaximumSize = new System.Drawing.Size(1056, 600);
            this.MinimumSize = new System.Drawing.Size(1056, 600);
            this.Name = "MapEditorForm";
            this.Text = "Map Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pbTileset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTileset;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.ComboBox cmbPalette;
        private System.Windows.Forms.ComboBox cmbTileset;
        private System.Windows.Forms.Label lblPalette;
        private System.Windows.Forms.Label lblTileset;
    }
}

