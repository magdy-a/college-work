namespace MapDataEditor
{
    partial class AddItemForm
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
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.AddSpritesbutton = new System.Windows.Forms.Button();
            this.Namelabel = new System.Windows.Forms.Label();
            this.NametextBox = new System.Windows.Forms.TextBox();
            this.SharedInformationgroupBox = new System.Windows.Forms.GroupBox();
            this.ChildTypecomboBox = new System.Windows.Forms.ComboBox();
            this.ChildTypelabel = new System.Windows.Forms.Label();
            this.ParentTypecomboBox = new System.Windows.Forms.ComboBox();
            this.ParentTypelabel = new System.Windows.Forms.Label();
            this.ItemgroupBox = new System.Windows.Forms.GroupBox();
            this.WidthtextBox = new System.Windows.Forms.TextBox();
            this.Widthlabel = new System.Windows.Forms.Label();
            this.HeighttextBox = new System.Windows.Forms.TextBox();
            this.Heightlabel = new System.Windows.Forms.Label();
            this.WallgroupBox = new System.Windows.Forms.GroupBox();
            this.TallWallradioButton = new System.Windows.Forms.RadioButton();
            this.ShortWallradioButton = new System.Windows.Forms.RadioButton();
            this.GroundgroupBox = new System.Windows.Forms.GroupBox();
            this.CanWalkOncheckBox = new System.Windows.Forms.CheckBox();
            this.HasBorderscheckBox = new System.Windows.Forms.CheckBox();
            this.ImportancetextBox = new System.Windows.Forms.TextBox();
            this.Chanceslabel = new System.Windows.Forms.Label();
            this.GroundPiecestextBox = new System.Windows.Forms.TextBox();
            this.GroundPieceslabel = new System.Windows.Forms.Label();
            this.SharedInformationgroupBox.SuspendLayout();
            this.ItemgroupBox.SuspendLayout();
            this.WallgroupBox.SuspendLayout();
            this.GroundgroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(185, 280);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(80, 30);
            this.Cancelbutton.TabIndex = 0;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // AddSpritesbutton
            // 
            this.AddSpritesbutton.Location = new System.Drawing.Point(99, 280);
            this.AddSpritesbutton.Name = "AddSpritesbutton";
            this.AddSpritesbutton.Size = new System.Drawing.Size(80, 30);
            this.AddSpritesbutton.TabIndex = 1;
            this.AddSpritesbutton.Text = "Add Sprites";
            this.AddSpritesbutton.UseVisualStyleBackColor = true;
            this.AddSpritesbutton.Click += new System.EventHandler(this.AddSpritesbutton_Click);
            // 
            // Namelabel
            // 
            this.Namelabel.AutoSize = true;
            this.Namelabel.Location = new System.Drawing.Point(11, 24);
            this.Namelabel.Name = "Namelabel";
            this.Namelabel.Size = new System.Drawing.Size(42, 14);
            this.Namelabel.TabIndex = 2;
            this.Namelabel.Text = "Name:";
            // 
            // NametextBox
            // 
            this.NametextBox.Location = new System.Drawing.Point(87, 21);
            this.NametextBox.Name = "NametextBox";
            this.NametextBox.Size = new System.Drawing.Size(148, 22);
            this.NametextBox.TabIndex = 3;
            // 
            // SharedInformationgroupBox
            // 
            this.SharedInformationgroupBox.Controls.Add(this.ChildTypecomboBox);
            this.SharedInformationgroupBox.Controls.Add(this.ChildTypelabel);
            this.SharedInformationgroupBox.Controls.Add(this.ParentTypecomboBox);
            this.SharedInformationgroupBox.Controls.Add(this.ParentTypelabel);
            this.SharedInformationgroupBox.Controls.Add(this.NametextBox);
            this.SharedInformationgroupBox.Controls.Add(this.Namelabel);
            this.SharedInformationgroupBox.Location = new System.Drawing.Point(12, 12);
            this.SharedInformationgroupBox.Name = "SharedInformationgroupBox";
            this.SharedInformationgroupBox.Size = new System.Drawing.Size(252, 115);
            this.SharedInformationgroupBox.TabIndex = 4;
            this.SharedInformationgroupBox.TabStop = false;
            this.SharedInformationgroupBox.Text = "Shared Information";
            // 
            // ChildTypecomboBox
            // 
            this.ChildTypecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChildTypecomboBox.Enabled = false;
            this.ChildTypecomboBox.FormattingEnabled = true;
            this.ChildTypecomboBox.Location = new System.Drawing.Point(87, 77);
            this.ChildTypecomboBox.Name = "ChildTypecomboBox";
            this.ChildTypecomboBox.Size = new System.Drawing.Size(146, 22);
            this.ChildTypecomboBox.TabIndex = 10;
            // 
            // ChildTypelabel
            // 
            this.ChildTypelabel.AutoSize = true;
            this.ChildTypelabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ChildTypelabel.Location = new System.Drawing.Point(11, 80);
            this.ChildTypelabel.Name = "ChildTypelabel";
            this.ChildTypelabel.Size = new System.Drawing.Size(65, 14);
            this.ChildTypelabel.TabIndex = 9;
            this.ChildTypelabel.Text = "Child Type:";
            // 
            // ParentTypecomboBox
            // 
            this.ParentTypecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParentTypecomboBox.FormattingEnabled = true;
            this.ParentTypecomboBox.Location = new System.Drawing.Point(87, 49);
            this.ParentTypecomboBox.Name = "ParentTypecomboBox";
            this.ParentTypecomboBox.Size = new System.Drawing.Size(146, 22);
            this.ParentTypecomboBox.TabIndex = 8;
            this.ParentTypecomboBox.SelectedIndexChanged += new System.EventHandler(this.ParentTypecomboBox_SelectedIndexChanged);
            // 
            // ParentTypelabel
            // 
            this.ParentTypelabel.AutoSize = true;
            this.ParentTypelabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ParentTypelabel.Location = new System.Drawing.Point(11, 52);
            this.ParentTypelabel.Name = "ParentTypelabel";
            this.ParentTypelabel.Size = new System.Drawing.Size(72, 14);
            this.ParentTypelabel.TabIndex = 7;
            this.ParentTypelabel.Text = "Parent Type:";
            // 
            // ItemgroupBox
            // 
            this.ItemgroupBox.Controls.Add(this.WidthtextBox);
            this.ItemgroupBox.Controls.Add(this.Widthlabel);
            this.ItemgroupBox.Controls.Add(this.HeighttextBox);
            this.ItemgroupBox.Controls.Add(this.Heightlabel);
            this.ItemgroupBox.Location = new System.Drawing.Point(12, 134);
            this.ItemgroupBox.Name = "ItemgroupBox";
            this.ItemgroupBox.Size = new System.Drawing.Size(252, 86);
            this.ItemgroupBox.TabIndex = 9;
            this.ItemgroupBox.TabStop = false;
            this.ItemgroupBox.Text = "Item Information";
            // 
            // WidthtextBox
            // 
            this.WidthtextBox.Location = new System.Drawing.Point(75, 49);
            this.WidthtextBox.Name = "WidthtextBox";
            this.WidthtextBox.Size = new System.Drawing.Size(160, 22);
            this.WidthtextBox.TabIndex = 5;
            // 
            // Widthlabel
            // 
            this.Widthlabel.AutoSize = true;
            this.Widthlabel.Location = new System.Drawing.Point(7, 52);
            this.Widthlabel.Name = "Widthlabel";
            this.Widthlabel.Size = new System.Drawing.Size(43, 14);
            this.Widthlabel.TabIndex = 4;
            this.Widthlabel.Text = "Width:";
            // 
            // HeighttextBox
            // 
            this.HeighttextBox.Location = new System.Drawing.Point(75, 21);
            this.HeighttextBox.Name = "HeighttextBox";
            this.HeighttextBox.Size = new System.Drawing.Size(160, 22);
            this.HeighttextBox.TabIndex = 3;
            // 
            // Heightlabel
            // 
            this.Heightlabel.AutoSize = true;
            this.Heightlabel.Location = new System.Drawing.Point(7, 24);
            this.Heightlabel.Name = "Heightlabel";
            this.Heightlabel.Size = new System.Drawing.Size(46, 14);
            this.Heightlabel.TabIndex = 2;
            this.Heightlabel.Text = "Height:";
            // 
            // WallgroupBox
            // 
            this.WallgroupBox.Controls.Add(this.TallWallradioButton);
            this.WallgroupBox.Controls.Add(this.ShortWallradioButton);
            this.WallgroupBox.Location = new System.Drawing.Point(12, 134);
            this.WallgroupBox.Name = "WallgroupBox";
            this.WallgroupBox.Size = new System.Drawing.Size(252, 76);
            this.WallgroupBox.TabIndex = 10;
            this.WallgroupBox.TabStop = false;
            this.WallgroupBox.Text = "Wall Information";
            this.WallgroupBox.Visible = false;
            // 
            // TallWallradioButton
            // 
            this.TallWallradioButton.AutoSize = true;
            this.TallWallradioButton.Location = new System.Drawing.Point(10, 45);
            this.TallWallradioButton.Name = "TallWallradioButton";
            this.TallWallradioButton.Size = new System.Drawing.Size(74, 18);
            this.TallWallradioButton.TabIndex = 1;
            this.TallWallradioButton.TabStop = true;
            this.TallWallradioButton.Text = "Tall Wall";
            this.TallWallradioButton.UseVisualStyleBackColor = true;
            // 
            // ShortWallradioButton
            // 
            this.ShortWallradioButton.AutoSize = true;
            this.ShortWallradioButton.Location = new System.Drawing.Point(10, 21);
            this.ShortWallradioButton.Name = "ShortWallradioButton";
            this.ShortWallradioButton.Size = new System.Drawing.Size(82, 18);
            this.ShortWallradioButton.TabIndex = 0;
            this.ShortWallradioButton.TabStop = true;
            this.ShortWallradioButton.Text = "Short Wall";
            this.ShortWallradioButton.UseVisualStyleBackColor = true;
            // 
            // GroundgroupBox
            // 
            this.GroundgroupBox.Controls.Add(this.CanWalkOncheckBox);
            this.GroundgroupBox.Controls.Add(this.HasBorderscheckBox);
            this.GroundgroupBox.Controls.Add(this.ImportancetextBox);
            this.GroundgroupBox.Controls.Add(this.Chanceslabel);
            this.GroundgroupBox.Controls.Add(this.GroundPiecestextBox);
            this.GroundgroupBox.Controls.Add(this.GroundPieceslabel);
            this.GroundgroupBox.Location = new System.Drawing.Point(12, 134);
            this.GroundgroupBox.Name = "GroundgroupBox";
            this.GroundgroupBox.Size = new System.Drawing.Size(252, 140);
            this.GroundgroupBox.TabIndex = 11;
            this.GroundgroupBox.TabStop = false;
            this.GroundgroupBox.Text = "Ground Information";
            this.GroundgroupBox.Visible = false;
            // 
            // CanWalkOncheckBox
            // 
            this.CanWalkOncheckBox.AutoSize = true;
            this.CanWalkOncheckBox.Location = new System.Drawing.Point(129, 109);
            this.CanWalkOncheckBox.Name = "CanWalkOncheckBox";
            this.CanWalkOncheckBox.Size = new System.Drawing.Size(101, 18);
            this.CanWalkOncheckBox.TabIndex = 10;
            this.CanWalkOncheckBox.Text = "Can Walk On?";
            this.CanWalkOncheckBox.UseVisualStyleBackColor = true;
            // 
            // HasBorderscheckBox
            // 
            this.HasBorderscheckBox.AutoSize = true;
            this.HasBorderscheckBox.Location = new System.Drawing.Point(6, 109);
            this.HasBorderscheckBox.Name = "HasBorderscheckBox";
            this.HasBorderscheckBox.Size = new System.Drawing.Size(98, 18);
            this.HasBorderscheckBox.TabIndex = 9;
            this.HasBorderscheckBox.Text = "Has Borders?";
            this.HasBorderscheckBox.UseVisualStyleBackColor = true;
            // 
            // ImportancetextBox
            // 
            this.ImportancetextBox.Location = new System.Drawing.Point(6, 81);
            this.ImportancetextBox.Name = "ImportancetextBox";
            this.ImportancetextBox.Size = new System.Drawing.Size(229, 22);
            this.ImportancetextBox.TabIndex = 8;
            // 
            // Chanceslabel
            // 
            this.Chanceslabel.AutoSize = true;
            this.Chanceslabel.Location = new System.Drawing.Point(6, 61);
            this.Chanceslabel.Name = "Chanceslabel";
            this.Chanceslabel.Size = new System.Drawing.Size(228, 14);
            this.Chanceslabel.TabIndex = 7;
            this.Chanceslabel.Text = "Their importance, separated by commas:";
            // 
            // GroundPiecestextBox
            // 
            this.GroundPiecestextBox.Location = new System.Drawing.Point(124, 26);
            this.GroundPiecestextBox.Name = "GroundPiecestextBox";
            this.GroundPiecestextBox.Size = new System.Drawing.Size(111, 22);
            this.GroundPiecestextBox.TabIndex = 5;
            // 
            // GroundPieceslabel
            // 
            this.GroundPieceslabel.AutoSize = true;
            this.GroundPieceslabel.Location = new System.Drawing.Point(7, 29);
            this.GroundPieceslabel.Name = "GroundPieceslabel";
            this.GroundPieceslabel.Size = new System.Drawing.Size(111, 14);
            this.GroundPieceslabel.TabIndex = 4;
            this.GroundPieceslabel.Text = "# of Ground Pieces:";
            // 
            // AddItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 322);
            this.Controls.Add(this.GroundgroupBox);
            this.Controls.Add(this.WallgroupBox);
            this.Controls.Add(this.ItemgroupBox);
            this.Controls.Add(this.SharedInformationgroupBox);
            this.Controls.Add(this.AddSpritesbutton);
            this.Controls.Add(this.Cancelbutton);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddForm_FormClosing);
            this.SharedInformationgroupBox.ResumeLayout(false);
            this.SharedInformationgroupBox.PerformLayout();
            this.ItemgroupBox.ResumeLayout(false);
            this.ItemgroupBox.PerformLayout();
            this.WallgroupBox.ResumeLayout(false);
            this.WallgroupBox.PerformLayout();
            this.GroundgroupBox.ResumeLayout(false);
            this.GroundgroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button AddSpritesbutton;
        private System.Windows.Forms.Label Namelabel;
        private System.Windows.Forms.TextBox NametextBox;
        private System.Windows.Forms.GroupBox SharedInformationgroupBox;
        private System.Windows.Forms.ComboBox ParentTypecomboBox;
        private System.Windows.Forms.Label ParentTypelabel;
        private System.Windows.Forms.GroupBox ItemgroupBox;
        private System.Windows.Forms.TextBox HeighttextBox;
        private System.Windows.Forms.Label Heightlabel;
        private System.Windows.Forms.TextBox WidthtextBox;
        private System.Windows.Forms.Label Widthlabel;
        private System.Windows.Forms.GroupBox WallgroupBox;
        private System.Windows.Forms.RadioButton TallWallradioButton;
        private System.Windows.Forms.RadioButton ShortWallradioButton;
        private System.Windows.Forms.GroupBox GroundgroupBox;
        private System.Windows.Forms.TextBox ImportancetextBox;
        private System.Windows.Forms.Label Chanceslabel;
        private System.Windows.Forms.TextBox GroundPiecestextBox;
        private System.Windows.Forms.Label GroundPieceslabel;
        private System.Windows.Forms.ComboBox ChildTypecomboBox;
        private System.Windows.Forms.Label ChildTypelabel;
        private System.Windows.Forms.CheckBox CanWalkOncheckBox;
        private System.Windows.Forms.CheckBox HasBorderscheckBox;
    }
}