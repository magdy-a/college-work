namespace DataEditor
{
    partial class AddSpritesForm
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
            this.AddSpritesbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.AddItembutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Helpbutton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(10, 10);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(320, 320);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // AddSpritesbutton
            // 
            this.AddSpritesbutton.Location = new System.Drawing.Point(10, 391);
            this.AddSpritesbutton.Name = "AddSpritesbutton";
            this.AddSpritesbutton.Size = new System.Drawing.Size(90, 30);
            this.AddSpritesbutton.TabIndex = 0;
            this.AddSpritesbutton.Text = "Add Sprites";
            this.AddSpritesbutton.UseVisualStyleBackColor = true;
            this.AddSpritesbutton.Click += new System.EventHandler(this.AddSpritesbutton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(184, 391);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(60, 30);
            this.Cancelbutton.TabIndex = 2;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // AddItembutton
            // 
            this.AddItembutton.Location = new System.Drawing.Point(106, 391);
            this.AddItembutton.Name = "AddItembutton";
            this.AddItembutton.Size = new System.Drawing.Size(70, 30);
            this.AddItembutton.TabIndex = 1;
            this.AddItembutton.Text = "Add Item";
            this.AddItembutton.UseVisualStyleBackColor = true;
            this.AddItembutton.Click += new System.EventHandler(this.AddItembutton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 42);
            this.label1.TabIndex = 5;
            this.label1.Text = "Right click to delete a sprite or drag a sprite ontop of another to exchange them" +
                ". Click \"Show Help\" to know more about the correct order of sprites addition.";
            // 
            // Helpbutton
            // 
            this.Helpbutton.Location = new System.Drawing.Point(250, 391);
            this.Helpbutton.Name = "Helpbutton";
            this.Helpbutton.Size = new System.Drawing.Size(80, 30);
            this.Helpbutton.TabIndex = 3;
            this.Helpbutton.Text = "Show Help";
            this.Helpbutton.UseVisualStyleBackColor = true;
            this.Helpbutton.Click += new System.EventHandler(this.Helpbutton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DataEditor.Properties.Resources.HelpPage;
            this.pictureBox1.Location = new System.Drawing.Point(346, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 417);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // AddSpritesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 432);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Helpbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddItembutton);
            this.Controls.Add(this.AddSpritesbutton);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.pictureBox);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddSpritesForm";
            this.Text = "AddSprites";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSpritesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button AddSpritesbutton;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button AddItembutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Helpbutton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}