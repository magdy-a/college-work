namespace TaskManager
{
    partial class TaskForm
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
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.cmbTaskType = new System.Windows.Forms.ComboBox();
            this.lblCreateTitle = new System.Windows.Forms.Label();
            this.lblUpdateTitle = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblTaskType = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.btnPlusWeek = new System.Windows.Forms.Button();
            this.btnPlusDay = new System.Windows.Forms.Button();
            this.pnlBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(56, 138);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(181, 33);
            this.txtDetails.TabIndex = 5;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(56, 36);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(85, 20);
            this.txtID.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(56, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(85, 20);
            this.txtName.TabIndex = 0;
            // 
            // cmbCategories
            // 
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(118, 192);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(119, 21);
            this.cmbCategories.TabIndex = 4;
            // 
            // cmbTaskType
            // 
            this.cmbTaskType.FormattingEnabled = true;
            this.cmbTaskType.Location = new System.Drawing.Point(11, 192);
            this.cmbTaskType.Name = "cmbTaskType";
            this.cmbTaskType.Size = new System.Drawing.Size(101, 21);
            this.cmbTaskType.TabIndex = 3;
            // 
            // lblCreateTitle
            // 
            this.lblCreateTitle.AutoSize = true;
            this.lblCreateTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCreateTitle.Font = new System.Drawing.Font("Vladimir Script", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateTitle.Location = new System.Drawing.Point(11, 4);
            this.lblCreateTitle.Name = "lblCreateTitle";
            this.lblCreateTitle.Size = new System.Drawing.Size(122, 29);
            this.lblCreateTitle.TabIndex = 23;
            this.lblCreateTitle.Text = "Create Task";
            this.lblCreateTitle.Visible = false;
            this.lblCreateTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TaskForm_MouseDown);
            this.lblCreateTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TaskForm_MouseMove);
            // 
            // lblUpdateTitle
            // 
            this.lblUpdateTitle.AutoSize = true;
            this.lblUpdateTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdateTitle.Font = new System.Drawing.Font("Vladimir Script", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateTitle.Location = new System.Drawing.Point(11, 4);
            this.lblUpdateTitle.Name = "lblUpdateTitle";
            this.lblUpdateTitle.Size = new System.Drawing.Size(130, 29);
            this.lblUpdateTitle.TabIndex = 23;
            this.lblUpdateTitle.Text = "Update Task";
            this.lblUpdateTitle.Visible = false;
            this.lblUpdateTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TaskForm_MouseDown);
            this.lblUpdateTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TaskForm_MouseMove);
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(9, 138);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(49, 13);
            this.lblDetails.TabIndex = 20;
            this.lblDetails.Text = "Details : ";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(115, 174);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(59, 13);
            this.lblCategory.TabIndex = 21;
            this.lblCategory.Text = "Category :";
            // 
            // lblTaskType
            // 
            this.lblTaskType.AutoSize = true;
            this.lblTaskType.Location = new System.Drawing.Point(9, 176);
            this.lblTaskType.Name = "lblTaskType";
            this.lblTaskType.Size = new System.Drawing.Size(41, 13);
            this.lblTaskType.TabIndex = 21;
            this.lblTaskType.Text = "Type : ";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(9, 115);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(32, 13);
            this.lblEndDate.TabIndex = 22;
            this.lblEndDate.Text = "To  : ";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(9, 39);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 13);
            this.lblID.TabIndex = 18;
            this.lblID.Text = "ID : ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 59);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 13);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Name : ";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(9, 87);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(41, 13);
            this.lblStartDate.TabIndex = 19;
            this.lblStartDate.Text = "From : ";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(56, 109);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(181, 20);
            this.dtpEndDate.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CalendarMonthBackground = System.Drawing.Color.OliveDrab;
            this.dtpStartDate.Location = new System.Drawing.Point(56, 83);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(181, 20);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.DtpStartDate_ValueChanged);
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
            this.btnClose.Location = new System.Drawing.Point(202, 11);
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
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDone.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Location = new System.Drawing.Point(161, 11);
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
            this.pnlBackground.Controls.Add(this.btnPlusWeek);
            this.pnlBackground.Controls.Add(this.btnPlusDay);
            this.pnlBackground.Controls.Add(this.txtDetails);
            this.pnlBackground.Controls.Add(this.btnClose);
            this.pnlBackground.Controls.Add(this.txtID);
            this.pnlBackground.Controls.Add(this.lblID);
            this.pnlBackground.Controls.Add(this.txtName);
            this.pnlBackground.Controls.Add(this.cmbCategories);
            this.pnlBackground.Controls.Add(this.cmbTaskType);
            this.pnlBackground.Controls.Add(this.dtpStartDate);
            this.pnlBackground.Controls.Add(this.lblDetails);
            this.pnlBackground.Controls.Add(this.dtpEndDate);
            this.pnlBackground.Controls.Add(this.lblCategory);
            this.pnlBackground.Controls.Add(this.lblStartDate);
            this.pnlBackground.Controls.Add(this.lblTaskType);
            this.pnlBackground.Controls.Add(this.lblName);
            this.pnlBackground.Controls.Add(this.lblEndDate);
            this.pnlBackground.Controls.Add(this.lblCreateTitle);
            this.pnlBackground.Controls.Add(this.lblUpdateTitle);
            this.pnlBackground.Controls.Add(this.btnDone);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(246, 223);
            this.pnlBackground.TabIndex = 1;
            this.pnlBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TaskForm_MouseDown);
            this.pnlBackground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TaskForm_MouseMove);
            // 
            // btnPlusWeek
            // 
            this.btnPlusWeek.BackColor = System.Drawing.Color.White;
            this.btnPlusWeek.Location = new System.Drawing.Point(188, 54);
            this.btnPlusWeek.Name = "btnPlusWeek";
            this.btnPlusWeek.Size = new System.Drawing.Size(32, 23);
            this.btnPlusWeek.TabIndex = 24;
            this.btnPlusWeek.Text = "+7";
            this.btnPlusWeek.UseVisualStyleBackColor = false;
            this.btnPlusWeek.Click += new System.EventHandler(this.btnPlusWeek_Click);
            // 
            // btnPlusDay
            // 
            this.btnPlusDay.BackColor = System.Drawing.Color.White;
            this.btnPlusDay.Location = new System.Drawing.Point(147, 54);
            this.btnPlusDay.Name = "btnPlusDay";
            this.btnPlusDay.Size = new System.Drawing.Size(35, 23);
            this.btnPlusDay.TabIndex = 24;
            this.btnPlusDay.Text = "+1";
            this.btnPlusDay.UseVisualStyleBackColor = false;
            this.btnPlusDay.Click += new System.EventHandler(this.btnPlusDay_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(246, 223);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TaskForm";
            this.Text = "Task Form";
            this.Load += new System.EventHandler(this.TaskForm_Load);
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbTaskType;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblTaskType;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblCreateTitle;
        private System.Windows.Forms.Label lblUpdateTitle;
        private System.Windows.Forms.Button btnPlusWeek;
        private System.Windows.Forms.Button btnPlusDay;

    }
}