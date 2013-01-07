namespace MapDataEditor
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.SheetslistView = new System.Windows.Forms.ListView();
            this.ItemslistView = new System.Windows.Forms.ListView();
            this.Clearbutton = new System.Windows.Forms.Button();
            this.Savebutton = new System.Windows.Forms.Button();
            this.Loadbutton = new System.Windows.Forms.Button();
            this.AddGroundbutton = new System.Windows.Forms.Button();
            this.AddWallbutton = new System.Windows.Forms.Button();
            this.AddItembutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox.Location = new System.Drawing.Point(120, 11);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(640, 640);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // SheetslistView
            // 
            this.SheetslistView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.SheetslistView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SheetslistView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SheetslistView.LabelWrap = false;
            this.SheetslistView.Location = new System.Drawing.Point(10, 30);
            this.SheetslistView.Name = "SheetslistView";
            this.SheetslistView.Size = new System.Drawing.Size(100, 107);
            this.SheetslistView.TabIndex = 1;
            this.SheetslistView.UseCompatibleStateImageBehavior = false;
            this.SheetslistView.View = System.Windows.Forms.View.List;
            this.SheetslistView.SelectedIndexChanged += new System.EventHandler(this.SheetslistView_SelectedIndexChanged);
            // 
            // ItemslistView
            // 
            this.ItemslistView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.ItemslistView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ItemslistView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ItemslistView.LabelWrap = false;
            this.ItemslistView.Location = new System.Drawing.Point(10, 160);
            this.ItemslistView.Name = "ItemslistView";
            this.ItemslistView.Size = new System.Drawing.Size(100, 215);
            this.ItemslistView.TabIndex = 2;
            this.ItemslistView.UseCompatibleStateImageBehavior = false;
            this.ItemslistView.View = System.Windows.Forms.View.List;
            // 
            // Clearbutton
            // 
            this.Clearbutton.Location = new System.Drawing.Point(10, 385);
            this.Clearbutton.Name = "Clearbutton";
            this.Clearbutton.Size = new System.Drawing.Size(100, 32);
            this.Clearbutton.TabIndex = 3;
            this.Clearbutton.Text = "Clear All";
            this.Clearbutton.UseVisualStyleBackColor = true;
            this.Clearbutton.Click += new System.EventHandler(this.Clearbutton_Click);
            // 
            // Savebutton
            // 
            this.Savebutton.Location = new System.Drawing.Point(10, 428);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(100, 32);
            this.Savebutton.TabIndex = 4;
            this.Savebutton.Text = "Save";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // Loadbutton
            // 
            this.Loadbutton.Location = new System.Drawing.Point(10, 471);
            this.Loadbutton.Name = "Loadbutton";
            this.Loadbutton.Size = new System.Drawing.Size(100, 32);
            this.Loadbutton.TabIndex = 5;
            this.Loadbutton.Text = "Load";
            this.Loadbutton.UseVisualStyleBackColor = true;
            this.Loadbutton.Click += new System.EventHandler(this.Loadbutton_Click);
            // 
            // AddGroundbutton
            // 
            this.AddGroundbutton.Location = new System.Drawing.Point(10, 600);
            this.AddGroundbutton.Name = "AddGroundbutton";
            this.AddGroundbutton.Size = new System.Drawing.Size(100, 32);
            this.AddGroundbutton.TabIndex = 8;
            this.AddGroundbutton.Text = "Add Ground";
            this.AddGroundbutton.UseVisualStyleBackColor = true;
            this.AddGroundbutton.Click += new System.EventHandler(this.AddGroundbutton_Click);
            // 
            // AddWallbutton
            // 
            this.AddWallbutton.Location = new System.Drawing.Point(10, 557);
            this.AddWallbutton.Name = "AddWallbutton";
            this.AddWallbutton.Size = new System.Drawing.Size(100, 32);
            this.AddWallbutton.TabIndex = 7;
            this.AddWallbutton.Text = "Add Wall";
            this.AddWallbutton.UseVisualStyleBackColor = true;
            this.AddWallbutton.Click += new System.EventHandler(this.AddWallbutton_Click);
            // 
            // AddItembutton
            // 
            this.AddItembutton.Location = new System.Drawing.Point(10, 514);
            this.AddItembutton.Name = "AddItembutton";
            this.AddItembutton.Size = new System.Drawing.Size(100, 32);
            this.AddItembutton.TabIndex = 6;
            this.AddItembutton.Text = "Add Item";
            this.AddItembutton.UseVisualStyleBackColor = true;
            this.AddItembutton.Click += new System.EventHandler(this.AddItembutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sprite Sheets:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Items:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 661);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddGroundbutton);
            this.Controls.Add(this.AddWallbutton);
            this.Controls.Add(this.AddItembutton);
            this.Controls.Add(this.Loadbutton);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.Clearbutton);
            this.Controls.Add(this.ItemslistView);
            this.Controls.Add(this.SheetslistView);
            this.Controls.Add(this.pictureBox);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Data Editor :: Tomes of the Elders";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ListView SheetslistView;
        private System.Windows.Forms.ListView ItemslistView;
        private System.Windows.Forms.Button Clearbutton;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.Button Loadbutton;
        private System.Windows.Forms.Button AddGroundbutton;
        private System.Windows.Forms.Button AddWallbutton;
        private System.Windows.Forms.Button AddItembutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;



    }
}

