namespace TaskManager
{
    partial class TaskManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskManager));
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.pnlInterface = new System.Windows.Forms.Panel();
            this.cbShowAll = new System.Windows.Forms.CheckBox();
            this.lvCategories = new System.Windows.Forms.ListView();
            this.col_Categories_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Categories_Category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpGeneralCalendar = new System.Windows.Forms.DateTimePicker();
            this.lvTasks = new System.Windows.Forms.ListView();
            this.col_Tasks_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Tasks_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Tasks_StartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Tasks_EndDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Tasks_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Tasks_Details = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdateCategory = new System.Windows.Forms.Button();
            this.btnUpdateTask = new System.Windows.Forms.Button();
            this.btnCreateCategory = new System.Windows.Forms.Button();
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.pbResize = new System.Windows.Forms.PictureBox();
            this.pnlBackground.SuspendLayout();
            this.pnlInterface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResize)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.White;
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackground.Controls.Add(this.pnlInterface);
            this.pnlBackground.Controls.Add(this.pbResize);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(315, 260);
            this.pnlBackground.TabIndex = 0;
            this.pnlBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TaskManagerForm_MouseDown);
            this.pnlBackground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TaskManagerForm_MouseMove);
            // 
            // pnlInterface
            // 
            this.pnlInterface.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInterface.Controls.Add(this.btnDeleteCategory);
            this.pnlInterface.Controls.Add(this.btnDeleteTask);
            this.pnlInterface.Controls.Add(this.btnMinimize);
            this.pnlInterface.Controls.Add(this.btnClose);
            this.pnlInterface.Controls.Add(this.btnUpdateCategory);
            this.pnlInterface.Controls.Add(this.btnUpdateTask);
            this.pnlInterface.Controls.Add(this.btnCreateCategory);
            this.pnlInterface.Controls.Add(this.cbShowAll);
            this.pnlInterface.Controls.Add(this.btnCreateTask);
            this.pnlInterface.Controls.Add(this.lvCategories);
            this.pnlInterface.Controls.Add(this.dtpGeneralCalendar);
            this.pnlInterface.Controls.Add(this.lvTasks);
            this.pnlInterface.Location = new System.Drawing.Point(0, 0);
            this.pnlInterface.Name = "pnlInterface";
            this.pnlInterface.Size = new System.Drawing.Size(310, 255);
            this.pnlInterface.TabIndex = 31;
            this.pnlInterface.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TaskManagerForm_MouseDown);
            this.pnlInterface.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TaskManagerForm_MouseMove);
            // 
            // cbShowAll
            // 
            this.cbShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowAll.AutoSize = true;
            this.cbShowAll.Location = new System.Drawing.Point(143, 230);
            this.cbShowAll.Name = "cbShowAll";
            this.cbShowAll.Size = new System.Drawing.Size(66, 17);
            this.cbShowAll.TabIndex = 26;
            this.cbShowAll.Text = "Show All";
            this.cbShowAll.UseVisualStyleBackColor = true;
            this.cbShowAll.CheckedChanged += new System.EventHandler(this.CbShowAll_CheckedChanged);
            // 
            // lvCategories
            // 
            this.lvCategories.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvCategories.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_Categories_ID,
            this.col_Categories_Category});
            this.lvCategories.FullRowSelect = true;
            this.lvCategories.GridLines = true;
            this.lvCategories.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCategories.HideSelection = false;
            this.lvCategories.LabelEdit = true;
            this.lvCategories.LabelWrap = false;
            this.lvCategories.Location = new System.Drawing.Point(215, 42);
            this.lvCategories.Name = "lvCategories";
            this.lvCategories.Size = new System.Drawing.Size(87, 179);
            this.lvCategories.TabIndex = 25;
            this.lvCategories.UseCompatibleStateImageBehavior = false;
            this.lvCategories.View = System.Windows.Forms.View.Details;
            this.lvCategories.SelectedIndexChanged += new System.EventHandler(this.LvCategories_SelectedIndexChanged);
            // 
            // col_Categories_ID
            // 
            this.col_Categories_ID.Text = "ID";
            this.col_Categories_ID.Width = 23;
            // 
            // col_Categories_Category
            // 
            this.col_Categories_Category.Text = "Category";
            this.col_Categories_Category.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_Categories_Category.Width = 59;
            // 
            // dtpGeneralCalendar
            // 
            this.dtpGeneralCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpGeneralCalendar.Location = new System.Drawing.Point(11, 11);
            this.dtpGeneralCalendar.Name = "dtpGeneralCalendar";
            this.dtpGeneralCalendar.Size = new System.Drawing.Size(185, 20);
            this.dtpGeneralCalendar.TabIndex = 25;
            this.dtpGeneralCalendar.ValueChanged += new System.EventHandler(this.DtpGeneralCalendar_ValueChanged);
            // 
            // lvTasks
            // 
            this.lvTasks.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvTasks.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_Tasks_ID,
            this.col_Tasks_Name,
            this.col_Tasks_StartDate,
            this.col_Tasks_EndDate,
            this.col_Tasks_Type,
            this.col_Tasks_Details});
            this.lvTasks.FullRowSelect = true;
            this.lvTasks.GridLines = true;
            this.lvTasks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTasks.HideSelection = false;
            this.lvTasks.LabelEdit = true;
            this.lvTasks.LabelWrap = false;
            this.lvTasks.Location = new System.Drawing.Point(11, 42);
            this.lvTasks.Name = "lvTasks";
            this.lvTasks.Size = new System.Drawing.Size(198, 179);
            this.lvTasks.TabIndex = 24;
            this.lvTasks.UseCompatibleStateImageBehavior = false;
            this.lvTasks.View = System.Windows.Forms.View.Details;
            // 
            // col_Tasks_ID
            // 
            this.col_Tasks_ID.Text = "ID";
            this.col_Tasks_ID.Width = 23;
            // 
            // col_Tasks_Name
            // 
            this.col_Tasks_Name.Text = "Name";
            this.col_Tasks_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_Tasks_Name.Width = 39;
            // 
            // col_Tasks_StartDate
            // 
            this.col_Tasks_StartDate.Text = "From";
            this.col_Tasks_StartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_Tasks_StartDate.Width = 36;
            // 
            // col_Tasks_EndDate
            // 
            this.col_Tasks_EndDate.Text = "To";
            this.col_Tasks_EndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_Tasks_EndDate.Width = 24;
            // 
            // col_Tasks_Type
            // 
            this.col_Tasks_Type.Text = "Type";
            this.col_Tasks_Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_Tasks_Type.Width = 36;
            // 
            // col_Tasks_Details
            // 
            this.col_Tasks_Details.Text = "Info";
            this.col_Tasks_Details.Width = 36;
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCategory.BackColor = System.Drawing.Color.White;
            this.btnDeleteCategory.BackgroundImage = global::TaskManager.Properties.Resources.Close_Paint;
            this.btnDeleteCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteCategory.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeleteCategory.FlatAppearance.BorderSize = 0;
            this.btnDeleteCategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDeleteCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCategory.Location = new System.Drawing.Point(275, 225);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteCategory.TabIndex = 29;
            this.btnDeleteCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteCategory.UseVisualStyleBackColor = false;
            this.btnDeleteCategory.Click += new System.EventHandler(this.BtnDeleteCategory_Click);
            this.btnDeleteCategory.MouseLeave += new System.EventHandler(this.BtnStyle_MouseLeave);
            this.btnDeleteCategory.MouseHover += new System.EventHandler(this.BtnStyle_MouseHover);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteTask.BackColor = System.Drawing.Color.White;
            this.btnDeleteTask.BackgroundImage = global::TaskManager.Properties.Resources.Close_Paint;
            this.btnDeleteTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteTask.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeleteTask.FlatAppearance.BorderSize = 0;
            this.btnDeleteTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTask.Location = new System.Drawing.Point(75, 225);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteTask.TabIndex = 7;
            this.btnDeleteTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.BtnDeleteTask_Click);
            this.btnDeleteTask.MouseLeave += new System.EventHandler(this.BtnStyle_MouseLeave);
            this.btnDeleteTask.MouseHover += new System.EventHandler(this.BtnStyle_MouseHover);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.White;
            this.btnMinimize.BackgroundImage = global::TaskManager.Properties.Resources.Minimize;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(215, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            this.btnMinimize.MouseLeave += new System.EventHandler(this.BtnStyle_MouseLeave);
            this.btnMinimize.MouseHover += new System.EventHandler(this.BtnStyle_MouseHover);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = global::TaskManager.Properties.Resources.Close_Red;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(264, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 0;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.BtnStyle_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.BtnStyle_MouseHover);
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateCategory.BackColor = System.Drawing.Color.White;
            this.btnUpdateCategory.BackgroundImage = global::TaskManager.Properties.Resources.Edit;
            this.btnUpdateCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdateCategory.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpdateCategory.FlatAppearance.BorderSize = 0;
            this.btnUpdateCategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnUpdateCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCategory.Location = new System.Drawing.Point(246, 225);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.Size = new System.Drawing.Size(25, 25);
            this.btnUpdateCategory.TabIndex = 28;
            this.btnUpdateCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUpdateCategory.UseVisualStyleBackColor = false;
            this.btnUpdateCategory.Click += new System.EventHandler(this.BtnUpdateCategory_Click);
            this.btnUpdateCategory.MouseLeave += new System.EventHandler(this.BtnStyle_MouseLeave);
            this.btnUpdateCategory.MouseHover += new System.EventHandler(this.BtnStyle_MouseHover);
            // 
            // btnUpdateTask
            // 
            this.btnUpdateTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdateTask.BackColor = System.Drawing.Color.White;
            this.btnUpdateTask.BackgroundImage = global::TaskManager.Properties.Resources.Edit;
            this.btnUpdateTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdateTask.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpdateTask.FlatAppearance.BorderSize = 0;
            this.btnUpdateTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnUpdateTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateTask.Location = new System.Drawing.Point(44, 225);
            this.btnUpdateTask.Name = "btnUpdateTask";
            this.btnUpdateTask.Size = new System.Drawing.Size(25, 25);
            this.btnUpdateTask.TabIndex = 7;
            this.btnUpdateTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUpdateTask.UseVisualStyleBackColor = false;
            this.btnUpdateTask.Click += new System.EventHandler(this.BtnUpdateTask_Click);
            this.btnUpdateTask.MouseLeave += new System.EventHandler(this.BtnStyle_MouseLeave);
            this.btnUpdateTask.MouseHover += new System.EventHandler(this.BtnStyle_MouseHover);
            // 
            // btnCreateCategory
            // 
            this.btnCreateCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCategory.BackColor = System.Drawing.Color.White;
            this.btnCreateCategory.BackgroundImage = global::TaskManager.Properties.Resources.Add;
            this.btnCreateCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCreateCategory.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCreateCategory.FlatAppearance.BorderSize = 0;
            this.btnCreateCategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCreateCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateCategory.Location = new System.Drawing.Point(215, 225);
            this.btnCreateCategory.Name = "btnCreateCategory";
            this.btnCreateCategory.Size = new System.Drawing.Size(25, 25);
            this.btnCreateCategory.TabIndex = 27;
            this.btnCreateCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCreateCategory.UseVisualStyleBackColor = false;
            this.btnCreateCategory.Click += new System.EventHandler(this.BtnCreateCategory_Click);
            this.btnCreateCategory.MouseLeave += new System.EventHandler(this.BtnStyle_MouseLeave);
            this.btnCreateCategory.MouseHover += new System.EventHandler(this.BtnStyle_MouseHover);
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateTask.BackColor = System.Drawing.Color.White;
            this.btnCreateTask.BackgroundImage = global::TaskManager.Properties.Resources.Add;
            this.btnCreateTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCreateTask.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCreateTask.FlatAppearance.BorderSize = 0;
            this.btnCreateTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCreateTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTask.Location = new System.Drawing.Point(11, 225);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(25, 25);
            this.btnCreateTask.TabIndex = 7;
            this.btnCreateTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCreateTask.UseVisualStyleBackColor = false;
            this.btnCreateTask.Click += new System.EventHandler(this.BtnCreateTask_Click);
            this.btnCreateTask.MouseLeave += new System.EventHandler(this.BtnStyle_MouseLeave);
            this.btnCreateTask.MouseHover += new System.EventHandler(this.BtnStyle_MouseHover);
            // 
            // pbResize
            // 
            this.pbResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbResize.BackColor = System.Drawing.Color.White;
            this.pbResize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbResize.BackgroundImage")));
            this.pbResize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pbResize.ErrorImage = null;
            this.pbResize.InitialImage = null;
            this.pbResize.Location = new System.Drawing.Point(303, 246);
            this.pbResize.Margin = new System.Windows.Forms.Padding(0);
            this.pbResize.Name = "pbResize";
            this.pbResize.Size = new System.Drawing.Size(11, 13);
            this.pbResize.TabIndex = 21;
            this.pbResize.TabStop = false;
            this.pbResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbResize_MouseDown);
            this.pbResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbResize_MouseMove);
            // 
            // TaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(315, 260);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(315, 260);
            this.Name = "TaskManager";
            this.Text = "TaskManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskManager_FormClosing);
            this.Load += new System.EventHandler(this.TaskManager_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TaskManagerForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TaskManagerForm_MouseMove);
            this.pnlBackground.ResumeLayout(false);
            this.pnlInterface.ResumeLayout(false);
            this.pnlInterface.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.PictureBox pbResize;
        private System.Windows.Forms.DateTimePicker dtpGeneralCalendar;
        private System.Windows.Forms.ColumnHeader col_Tasks_ID;
        private System.Windows.Forms.ColumnHeader col_Tasks_Name;
        private System.Windows.Forms.ColumnHeader col_Tasks_StartDate;
        private System.Windows.Forms.ColumnHeader col_Tasks_EndDate;
        private System.Windows.Forms.ColumnHeader col_Tasks_Type;
        private System.Windows.Forms.ColumnHeader col_Tasks_Details;
        private System.Windows.Forms.ColumnHeader col_Categories_Category;
        private System.Windows.Forms.ListView lvTasks;
        private System.Windows.Forms.ListView lvCategories;
        private System.Windows.Forms.CheckBox cbShowAll;
        private System.Windows.Forms.Button btnCreateTask;
        private System.Windows.Forms.Button btnUpdateTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnUpdateCategory;
        private System.Windows.Forms.Button btnCreateCategory;
        private System.Windows.Forms.Panel pnlInterface;
        private System.Windows.Forms.ColumnHeader col_Categories_ID;
    }
}