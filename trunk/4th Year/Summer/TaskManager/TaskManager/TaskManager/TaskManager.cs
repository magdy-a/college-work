namespace TaskManager
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public enum DBTables
    {
        Task,
        Category,
        TaskCategory
    }

    public partial class TaskManager : Form
    {
        #region Attributes

        private Point movingMouseDownLocation;
        private Point resizingMouseDownLocation;

        #endregion

        // #DONE
        // Category attribute to the db
        // the other view, category and it'list specificTasks
        // add TaskCategory TableIdentity
        // update to the interface functions
        // more functionality to the delete function, recheck approval for delete, delete multi_Tasks
        // use dynamic SQL
        // filter by category
        // Optimize Interface
        // TODO
        // Use Split Container, to have the option of removing category lv and filteing
        // fast update functionality (delay: day or week)
        // [Done] attribue to the db Task-Table
        // Coloring: color task accroding to Done or not, and time to deadline (green - yellow - red) with ratio between start & end dates
        // db recovery and backup
        // think about using the db only, without the Lists
        // Configure TaskType Enum
        // log exceptions
        // log actions done (CRUD actions for all tables)
        // add StartMenu Balloon Notification
        // Use StyleCop & SVN

        public TaskManager()
        {
            this.InitializeComponent();

            this.lvTasks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.lvTasks.AllowColumnReorder = false;
            this.lvTasks.Columns[this.col_Tasks_ID.Index].TextAlign = HorizontalAlignment.Center;

            this.lvCategories.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.lvCategories.AllowColumnReorder = false;
            this.lvCategories.Columns[this.col_Categories_ID.Index].TextAlign = HorizontalAlignment.Center;
        }

        private void TaskManager_Load(object sender, EventArgs e)
        {
            if (DBConnection.OpenConnection())
            {
                DBCommands.ReadCategories();
                DBCommands.ReadTasksData();

                this.UpdateTasksListView();
                this.UpdateCategoriesListView();
            }
            else
            {
                MessageBox.Show("Couldn't Open the Connection to the DB");
            }
        }

        #region Task Buttons

        private void BtnCreateTask_Click(object sender, EventArgs e)
        {
            if (DBConnection.IsOpen == false)
            {
                return;
            }

            TaskForm createTask = new TaskForm(DBTableIdentity.ReadIdentitySeed(DBTables.Task.ToString()) + 1);

            createTask.ShowDialog();

            if (createTask.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                DBCommands.CreateTask(createTask.NewTask);
            }

            this.UpdateTasksListView();
        }

        private void BtnUpdateTask_Click(object sender, EventArgs e)
        {
            if (DBConnection.IsOpen == false)
            {
                return;
            }

            if (this.lvTasks.SelectedIndices.Count == 0)
            {
                MessageBox.Show("No Tasks Selected");
            }
            else
            {
                TaskForm updateTask = new TaskForm(Task.GetTaskByID(int.Parse(this.lvTasks.Items[this.lvTasks.SelectedIndices[0]].SubItems[0].Text)));

                updateTask.ShowDialog();

                if (updateTask.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    DBCommands.UpdateTask(updateTask.NewTask);
                }

                this.UpdateTasksListView();
            }
        }

        private void BtnDeleteTask_Click(object sender, EventArgs e)
        {
            if (DBConnection.IsOpen == false)
            {
                return;
            }

            Task tmpTask;

            if (this.lvTasks.SelectedIndices.Count == 0)
            {
                MessageBox.Show("No Tasks Selected");
            }
            else if (this.lvTasks.SelectedIndices.Count == 1)
            {
                tmpTask = Task.GetTaskByID(int.Parse(this.lvTasks.Items[this.lvTasks.SelectedIndices[0]].SubItems[0].Text));

                if (MessageBox.Show("Delete : " + Environment.NewLine + tmpTask.ToString(), "Are you sure", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DBCommands.DeleteTask(tmpTask.ID);
                }
            }
            else
            {
                if (MessageBox.Show("Delete " + this.lvTasks.SelectedIndices.Count + " Tasks ? ", "Are you sure", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    for (int i = 0; i < this.lvTasks.SelectedIndices.Count; i++)
                    {
                        DBCommands.DeleteTask(int.Parse(this.lvTasks.Items[this.lvTasks.SelectedIndices[i]].SubItems[0].Text));
                    }
                }
            }

            this.UpdateTasksListView();
        }

        #endregion

        #region Category Buttons

        private void BtnCreateCategory_Click(object sender, EventArgs e)
        {
            if (DBConnection.IsOpen == false)
            {
                return;
            }

            CategoryForm createCategory = new CategoryForm(DBTableIdentity.ReadIdentitySeed(DBTables.Category.ToString()) + 1);

            createCategory.ShowDialog();

            if (createCategory.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                DBCommands.CreateCategory(createCategory.NewCategory);
            }

            this.UpdateCategoriesListView();
        }

        private void BtnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (DBConnection.IsOpen == false)
            {
                return;
            }

            if (this.lvCategories.SelectedIndices.Count == 0)
            {
                MessageBox.Show("No Categories Selected");
            }
            else
            {
                Category tmpCategory = Category.GetCategoryByID(int.Parse(this.lvCategories.Items[this.lvCategories.SelectedIndices[0]].SubItems[0].Text));

                if (tmpCategory.ID == 1)
                {
                    MessageBox.Show("Can't Update General Category", "Sorry");
                }
                else
                {
                    CategoryForm updateCategory = new CategoryForm(tmpCategory);

                    updateCategory.ShowDialog();

                    if (updateCategory.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        DBCommands.UpdateCategory(updateCategory.NewCategory);
                    }

                    this.UpdateCategoriesListView();
                    this.UpdateTasksListView();
                }
            }
        }

        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (DBConnection.IsOpen == false)
            {
                return;
            }

            Category tmpCategory;

            if (this.lvCategories.SelectedIndices.Count == 0)
            {
                MessageBox.Show("No Categories Selected");
            }
            else if (this.lvCategories.SelectedIndices.Count == 1)
            {
                tmpCategory = Category.GetCategoryByID(int.Parse(this.lvCategories.Items[this.lvCategories.SelectedIndices[0]].SubItems[0].Text));

                if (tmpCategory.ID == 1)
                {
                    MessageBox.Show("Can't Delete General Category", "Sorry");
                }
                else if (MessageBox.Show("Delete : " + Environment.NewLine + tmpCategory.ToString(), "Are you sure", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DBCommands.DeleteCategory(tmpCategory.ID);
                }
            }
            else
            {
                if (MessageBox.Show("Delete " + this.lvCategories.SelectedIndices.Count + " Tasks ? ", "Are you sure", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    for (int i = 0; i < this.lvCategories.SelectedIndices.Count; i++)
                    {
                        DBCommands.DeleteCategory(int.Parse(this.lvCategories.Items[this.lvCategories.SelectedIndices[i]].SubItems[0].Text));
                    }
                }
            }

            this.UpdateTasksListView();
            this.UpdateCategoriesListView();
        }

        #endregion

        #region ListViews

        private void UpdateTasksListViewWith(List<Task> specificTasks)
        {
            ListView lv = this.lvTasks;

            ListViewItem newTask;

            bool testColor = false;

            // Clear the List
            lv.Items.Clear();

            foreach (Task t in specificTasks)
            {
                newTask = new ListViewItem(t.ToStringArrWithoutIDs());

                if (testColor = !testColor)
                {
                    newTask.BackColor = Color.LightGreen;
                }
                else
                {
                    newTask.BackColor = Color.Orange;
                }

                lv.Items.Add(newTask);
            }

            // Set Auto Resize
            if (lv.Items.Count > 0)
            {
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            else
            {
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            lv.Update();
        }

        private void UpdateTasksListView()
        {
            this.UpdateTasksListViewWith(this.cbShowAll.Checked ? Task.Tasks : Task.Tasks.FindAll(task => task.StartDate.Date.ToShortDateString().Equals(this.dtpGeneralCalendar.Value.Date.ToShortDateString())));
        }

        private void UpdateCategoriesListView()
        {
            ListView lv = this.lvCategories;

            ListViewItem tmpCategory;

            bool testColor = false;

            lv.Items.Clear();

            foreach (Category t in Category.Categories)
            {
                tmpCategory = new ListViewItem(new string[] { t.ID.ToString(), t.Name });

                if (testColor = !testColor)
                {
                    tmpCategory.BackColor = Color.LightGreen;
                }
                else
                {
                    tmpCategory.BackColor = Color.Orange;
                }

                lv.Items.Add(tmpCategory);
            }

            lv.Update();
        }

        #endregion

        #region Form Events

        private void DtpGeneralCalendar_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateTasksListView();
        }

        private void CbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateTasksListView();
        }

        #endregion

        #region Form Static Functions

        #region Close and Minimize Form

        private void TaskManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBConnection.CloseConnection();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Move Form

        private void TaskManagerForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.movingMouseDownLocation = e.Location;
        }

        private void TaskManagerForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            this.Location = new Point(this.Location.X + e.X - this.movingMouseDownLocation.X, this.Location.Y + e.Y - this.movingMouseDownLocation.Y);
        }

        #endregion

        #region Resize Form

        private void PbResize_MouseDown(object sender, MouseEventArgs e)
        {
            this.resizingMouseDownLocation = e.Location;
        }

        private void PbResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            Size = new Size(Size.Width + e.X - this.resizingMouseDownLocation.X, Size.Height + e.Y - this.resizingMouseDownLocation.Y);

            Refresh();
        }

        #endregion

        #region Button Style

        private void BtnStyle_MouseHover(object sender, EventArgs e)
        {
            ((Button)sender).FlatStyle = FlatStyle.Standard;
        }

        private void BtnStyle_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).FlatStyle = FlatStyle.Flat;
        }

        #endregion

        #endregion

        private void LvCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvCategories.SelectedIndices.Count < 1 || this.cbShowAll.Checked)
            {
                return;
            }

            Category tmpCategory = Category.GetCategoryByID(int.Parse(this.lvCategories.Items[this.lvCategories.SelectedIndices[0]].SubItems[0].Text));

            List<Task> categoryList = new List<Task>();

            foreach (Task t in Task.Tasks)
            {
                if (t.Category.ID == tmpCategory.ID)
                {
                    categoryList.Add(t);
                }
            }

            this.UpdateTasksListViewWith(categoryList);
        }
    }
}
