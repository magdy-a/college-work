namespace MapEditor
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.SpriteSheetMakerTab = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CreateNewSheetBtn = new System.Windows.Forms.ToolStripButton();
            this.OpenSheetBtn = new System.Windows.Forms.ToolStripButton();
            this.SaveSheetBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddNewSpriteBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.MapEditorTab = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SpriteSheetMakerTab.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.SpriteSheetMakerTab);
            this.tabControl.Controls.Add(this.MapEditorTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(339, 382);
            this.tabControl.TabIndex = 0;
            // 
            // SpriteSheetMakerTab
            // 
            this.SpriteSheetMakerTab.Controls.Add(this.toolStrip1);
            this.SpriteSheetMakerTab.Controls.Add(this.pictureBox);
            this.SpriteSheetMakerTab.Location = new System.Drawing.Point(4, 23);
            this.SpriteSheetMakerTab.Name = "SpriteSheetMakerTab";
            this.SpriteSheetMakerTab.Padding = new System.Windows.Forms.Padding(3);
            this.SpriteSheetMakerTab.Size = new System.Drawing.Size(331, 355);
            this.SpriteSheetMakerTab.TabIndex = 0;
            this.SpriteSheetMakerTab.Text = "Sprite Sheet Maker";
            this.SpriteSheetMakerTab.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateNewSheetBtn,
            this.OpenSheetBtn,
            this.SaveSheetBtn,
            this.toolStripSeparator1,
            this.AddNewSpriteBtn,
            this.toolStripSeparator2,
            this.toolStripLabel});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(325, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CreateNewSheetBtn
            // 
            this.CreateNewSheetBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CreateNewSheetBtn.Image = global::MapEditor.Properties.Resources.AddBlankSheet;
            this.CreateNewSheetBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateNewSheetBtn.Name = "CreateNewSheetBtn";
            this.CreateNewSheetBtn.Size = new System.Drawing.Size(23, 22);
            this.CreateNewSheetBtn.ToolTipText = "Create New Sheet";
            this.CreateNewSheetBtn.Click += new System.EventHandler(this.CreateNewSheetBtn_Click);
            // 
            // OpenSheetBtn
            // 
            this.OpenSheetBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenSheetBtn.Image = global::MapEditor.Properties.Resources.OpenSheet;
            this.OpenSheetBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenSheetBtn.Name = "OpenSheetBtn";
            this.OpenSheetBtn.Size = new System.Drawing.Size(23, 22);
            this.OpenSheetBtn.ToolTipText = "Open Sheet";
            this.OpenSheetBtn.Click += new System.EventHandler(this.OpenSheetBtn_Click);
            // 
            // SaveSheetBtn
            // 
            this.SaveSheetBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveSheetBtn.Image = global::MapEditor.Properties.Resources.SaveSheet;
            this.SaveSheetBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveSheetBtn.Name = "SaveSheetBtn";
            this.SaveSheetBtn.Size = new System.Drawing.Size(23, 22);
            this.SaveSheetBtn.ToolTipText = "Save Sheet";
            this.SaveSheetBtn.Click += new System.EventHandler(this.SaveSheetBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // AddNewSpriteBtn
            // 
            this.AddNewSpriteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddNewSpriteBtn.Image = global::MapEditor.Properties.Resources.AddNewSprite;
            this.AddNewSpriteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddNewSpriteBtn.Name = "AddNewSpriteBtn";
            this.AddNewSpriteBtn.Size = new System.Drawing.Size(23, 22);
            this.AddNewSpriteBtn.ToolTipText = "Add New Sprite";
            this.AddNewSpriteBtn.Click += new System.EventHandler(this.AddNewSpriteBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(104, 22);
            this.toolStripLabel.Text = "No Current Action";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Fuchsia;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(6, 31);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(320, 320);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // MapEditorTab
            // 
            this.MapEditorTab.Location = new System.Drawing.Point(4, 23);
            this.MapEditorTab.Name = "MapEditorTab";
            this.MapEditorTab.Padding = new System.Windows.Forms.Padding(3);
            this.MapEditorTab.Size = new System.Drawing.Size(331, 355);
            this.MapEditorTab.TabIndex = 1;
            this.MapEditorTab.Text = "Map Editor";
            this.MapEditorTab.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 382);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Tomes Of The Elders :: Map Editor 1.0";
            this.tabControl.ResumeLayout(false);
            this.SpriteSheetMakerTab.ResumeLayout(false);
            this.SpriteSheetMakerTab.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage SpriteSheetMakerTab;
        private System.Windows.Forms.TabPage MapEditorTab;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton CreateNewSheetBtn;
        private System.Windows.Forms.ToolStripButton OpenSheetBtn;
        private System.Windows.Forms.ToolStripButton SaveSheetBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton AddNewSpriteBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel;
    }
}

