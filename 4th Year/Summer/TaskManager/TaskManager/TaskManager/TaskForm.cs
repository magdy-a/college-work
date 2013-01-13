namespace TaskManager
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Task Form Class
    /// </summary>
    public partial class TaskForm : Form
    {
        private Task newTask;

        private Point movingMouseDownLocation;

        public TaskForm(Task taskToUpdate)
        {
            this.InitializeComponent();

            this.AddCmbValues();

            this.txtID.Text = taskToUpdate.ID.ToString();
            this.txtName.Text = taskToUpdate.Name;
            this.dtpStartDate.Value = taskToUpdate.StartDate;
            this.dtpEndDate.Value = taskToUpdate.EndDate;

            this.cmbTaskType.SelectedIndex = (int)taskToUpdate.Type;
            this.cmbCategories.SelectedIndex = taskToUpdate.Category.ID - 1;

            this.txtDetails.Text = taskToUpdate.Details;

            this.lblUpdateTitle.Visible = true;
        }

        public TaskForm(int newTaskID)
        {
            this.InitializeComponent();

            this.AddCmbValues();

            this.txtID.Text = newTaskID.ToString();
            this.cmbTaskType.SelectedIndex = this.cmbCategories.SelectedIndex = 0;
            this.lblCreateTitle.Visible = true;
        }

        /// <summary>
        /// Gets the NewCategory Object
        /// </summary>
        internal Task NewTask
        {
            get { return this.newTask; }
        }

        private void TaskForm_Load(object sender, System.EventArgs e)
        {
            // Set MinValue for EndDate according to StartDate
            this.DtpStartDate_ValueChanged(null, null);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            this.newTask = new Task()
            {
                ID = int.Parse(this.txtID.Text),
                Name = this.txtName.Text,
                StartDate = this.dtpStartDate.Value,
                EndDate = this.dtpEndDate.Value,
                Type = (TaskType)Enum.Parse(typeof(TaskType), this.cmbTaskType.SelectedItem.ToString()),
                Category = Category.GetCategoryWithName(this.cmbCategories.SelectedItem.ToString()),
                Details = this.txtDetails.Text
            };
        }

        private void AddCmbValues()
        {
            // Set TaskType ComboBox Data
            this.cmbTaskType.Items.AddRange(Enum.GetNames(typeof(TaskType)));

            // Set Categories ComboBox Data
            this.cmbCategories.Items.AddRange(Category.GetListOfNames());
        }

        private void DtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpEndDate.MinDate = this.dtpStartDate.Value;
        }

        #region Move Form

        private void TaskForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.movingMouseDownLocation = e.Location;
        }

        private void TaskForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            this.Location = new Point(this.Location.X + e.X - this.movingMouseDownLocation.X, this.Location.Y + e.Y - this.movingMouseDownLocation.Y);
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

        private void btnPlusDay_Click(object sender, EventArgs e)
        {
            this.dtpEndDate.Value = this.dtpEndDate.Value.AddDays(1);
            this.dtpStartDate.Value = this.dtpStartDate.Value.AddDays(1);
        }

        private void btnPlusWeek_Click(object sender, EventArgs e)
        {
            this.dtpEndDate.Value = this.dtpEndDate.Value.AddDays(7);
            this.dtpStartDate.Value = this.dtpStartDate.Value.AddDays(7);
        }
    }
}