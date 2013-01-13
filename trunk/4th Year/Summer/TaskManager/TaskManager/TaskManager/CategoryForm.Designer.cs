namespace TaskManager
{
    partial class CategoryForm
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCreateTitle = new System.Windows.Forms.Label();
            this.lblUpdateTitle = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.pnlBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(74, 46);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(176, 20);
            this.txtID.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(74, 72);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(176, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblCreateTitle
            // 
            this.lblCreateTitle.AutoSize = true;
            this.lblCreateTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCreateTitle.Font = new System.Drawing.Font("Vladimir Script", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateTitle.Location = new System.Drawing.Point(3, 8);
            this.lblCreateTitle.Name = "lblCreateTitle";
            this.lblCreateTitle.Size = new System.Drawing.Size(141, 29);
            this.lblCreateTitle.TabIndex = 23;
            this.lblCreateTitle.Text = "Create Category";
            this.lblCreateTitle.Visible = false;
            this.lblCreateTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnStyle_MouseDown);
            this.lblCreateTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnStyle_MouseMove);
            // 
            // lblUpdateTitle
            // 
            this.lblUpdateTitle.AutoSize = true;
            this.lblUpdateTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdateTitle.Font = new System.Drawing.Font("Vladimir Script", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateTitle.Location = new System.Drawing.Point(3, 8);
            this.lblUpdateTitle.Name = "lblUpdateTitle";
            this.lblUpdateTitle.Size = new System.Drawing.Size(149, 29);
            this.lblUpdateTitle.TabIndex = 23;
            this.lblUpdateTitle.Text = "Update Category";
            this.lblUpdateTitle.Visible = false;
            this.lblUpdateTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnStyle_MouseDown);
            this.lblUpdateTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnStyle_MouseMove);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(4, 49);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 13);
            this.lblID.TabIndex = 18;
            this.lblID.Text = "ID : ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 75);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 13);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Name : ";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = global::TaskManager.Properties.Resources.Close_White;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(223, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.BtnStyle_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.BtnStyle_MouseHover);
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.White;
            this.btnDone.BackgroundImage = global::TaskManager.Properties.Resources.Done;
            this.btnDone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDone.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Location = new System.Drawing.Point(182, 3);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(35, 35);
            this.btnDone.TabIndex = 6;
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.BtnDone_Click);
            this.btnDone.MouseLeave += new System.EventHandler(this.BtnStyle_MouseLeave);
            this.btnDone.MouseHover += new System.EventHandler(this.BtnStyle_MouseHover);
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.White;
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackground.Controls.Add(this.btnClose);
            this.pnlBackground.Controls.Add(this.txtID);
            this.pnlBackground.Controls.Add(this.lblID);
            this.pnlBackground.Controls.Add(this.txtName);
            this.pnlBackground.Controls.Add(this.lblName);
            this.pnlBackground.Controls.Add(this.btnDone);
            this.pnlBackground.Controls.Add(this.lblUpdateTitle);
            this.pnlBackground.Controls.Add(this.lblCreateTitle);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(263, 102);
            this.pnlBackground.TabIndex = 1;
            this.pnlBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnStyle_MouseDown);
            this.pnlBackground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnStyle_MouseMove);
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(263, 102);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CategoryForm";
            this.Text = "Category Form";
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblCreateTitle;
        private System.Windows.Forms.Label lblUpdateTitle;

    }
}