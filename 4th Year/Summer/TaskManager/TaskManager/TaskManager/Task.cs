namespace TaskManager
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Task Type, recurrence and other sort of stuff
    /// </summary>
    public enum TaskType
    {
        /// <summary>
        /// Task happens every day
        /// </summary>
        DAILY,

        /// <summary>
        /// Task happens every week
        /// </summary>
        WEEKLY,

        /// <summary>
        /// Task happens every month
        /// </summary>
        MONTHLY,

        /// <summary>
        /// Task happens every year
        /// </summary>
        YEARLY
    }

    /// <summary>
    /// Task Class, holds all task Info
    /// </summary>
    public class Task
    {
        #region Fields

        /// <summary>
        /// List of all Tasks
        /// </summary>
        private static List<Task> tasks = new List<Task>();

        /// <summary>
        /// Identity Number for the task
        /// </summary>
        private int id;

        /// <summary>
        /// name of the task
        /// </summary>
        private string name;

        /// <summary>
        /// Start Date of the Task
        /// </summary>
        private DateTime startDate;

        /// <summary>
        /// End Date of the Task
        /// </summary>
        private DateTime endDate;

        /// <summary>
        /// Task list Type
        /// </summary>
        private TaskType type;

        /// <summary>
        /// The Category of this Task
        /// </summary>
        private Category category;

        /// <summary>
        /// Task Detailed Information
        /// </summary>
        private string details;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the Task class.
        /// </summary>
        public Task()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Task class.
        /// </summary>
        public Task(Task task)
        {
            this.id = task.id;
            this.name = task.name;
            this.startDate = task.startDate;
            this.endDate = task.endDate;
            this.type = task.type;
            this.details = task.details;
            this.category = task.category;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets List of all Tasks
        /// </summary>
        public static List<Task> Tasks
        {
            get { return Task.tasks; }
            set { Task.tasks = value; }
        }

        /// <summary>
        /// Gets or sets Identity Number for the task
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Gets or sets name of the task
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets Start Date of the Task
        /// </summary>
        public DateTime StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        /// <summary>
        /// Gets or sets End Date of the Task
        /// </summary>
        public DateTime EndDate
        {
            get { return this.endDate; }
            set { this.endDate = value; }
        }

        /// <summary>
        /// Gets or sets Task list Type
        /// </summary>
        public TaskType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        /// <summary>
        /// Gets or sets The Category of this Task
        /// </summary>
        public Category Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        /// <summary>
        /// Gets or sets Task Detailed Information
        /// </summary>
        public string Details
        {
            get { return this.details; }
            set { this.details = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Task Object
        /// </summary>
        /// <param name="CategoryID">required Task ID</param>
        /// <returns>Task Object</returns>
        public static Task GetTaskByID(int taskID)
        {
            return Task.Tasks.Find(task => task.id == taskID);
        }

        /// <summary>
        /// Get the Last Task in the List
        /// </summary>
        /// <returns>Last Task in the list</returns>
        public static Task GetLastTaskInTheList()
        {
            return Task.Tasks.Count > 0 ? Task.GetTaskByID(Task.Tasks.Count - 1) : null;
        }

        /// <summary>
        /// Update Task Information
        /// </summary>
        /// <param name="updatedTask">The Updated version of this task</param>
        /// <returns>Value indicating whether the task was updatedTask or not</returns>
        public bool Update(Task updatedTask)
        {
            bool isUpdated = false;

            try
            {
                this.name = updatedTask.name;
                this.startDate = updatedTask.startDate;
                this.endDate = updatedTask.endDate;
                this.type = updatedTask.type;
                this.category = updatedTask.category;
                this.details = updatedTask.details;

                isUpdated = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return isUpdated;
        }

        /// <summary>
        /// Checks if some date belongs to this task interval
        /// </summary>
        /// <param name="givenDate">date to look for</param>
        /// <returns>Value indicating whether givenDate belongs to this task</returns>
        public bool IsGivenDateBelongsToThisTask(DateTime givenDate)
        {
            //// TODO ReCheck This Function Logic

            bool result = false;

            DateTime tmpDate;

            /*if (this.type == TaskType.SPECIFICDATES && specificDates.Find(day => day.Date == givenDate.Date) != null)
            {
                result = true;
            }
            else */
            if (this.type == TaskType.DAILY)
            {
                result = true;
            }
            else if (this.type == TaskType.WEEKLY)
            {
                if (givenDate.Date == this.startDate.Date)
                {
                    result = true;
                }
                else if (givenDate.Date > this.endDate.Date && givenDate.Date < this.startDate.Date)
                {
                    result = false;
                }
                else
                {
                    tmpDate = this.startDate;

                    do
                    {
                        tmpDate.AddDays(7);
                    }
                    while (givenDate.Date > tmpDate.Date);

                    if (givenDate.Date == tmpDate.Date)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Converts this Task Data to a readable string
        /// </summary>
        /// <returns>String that carries all Task information</returns>
        public override string ToString()
        {
            return "ID = " + this.id + "\t Name = " + this.name + "\t StartDate = " + this.startDate.Date.ToShortDateString() + "\t EndDate = " + this.endDate.Date.ToShortDateString() + "\t Type = " + this.type.ToString() + "\t CategoryID = " + this.category.ID + "\t CategoryName = " + this.category.Name + "\t Details = " + this.details + Environment.NewLine;
        }

        /// <summary>
        /// Creates String Array contains the data of this task without any IDs to represent on ListViews
        /// </summary>
        /// <returns>String Array of this Task Data without IDs</returns>
        public string[] ToStringArrWithoutIDs()
        {
            return new string[] { this.ID.ToString(), this.name, this.startDate.Date.ToShortDateString(), this.endDate.Date.ToShortDateString(), this.type.ToString(), this.category.Name, this.details };
        }

        #endregion
    }
}