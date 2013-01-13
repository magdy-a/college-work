﻿namespace TaskManager
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    /// <summary>
    /// Carries all the static commands to access DB
    /// </summary>
    public class DBCommands
    {

        #region Task CRUD

        public static bool CreateTask(Task newTask)
        {
            bool isAdded = false;

            SqlCommand cmd;

            cmd = new SqlCommand("CreateTask", DBConnection.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@Name", newTask.Name), new SqlParameter("@StartDate", newTask.StartDate), new SqlParameter("@EndDate", newTask.EndDate), new SqlParameter("@Type", newTask.Type.ToString()), new SqlParameter("@Details", newTask.Details) });

            try
            {
                cmd.ExecuteNonQuery();

                // Get LastIdentity (current record, cause I just added it to the db), and add it to the tmpCategory object
                newTask.ID = DBCommands.ReadTaskMaxIdentityCol();

                // Add tmpCategory object to List of Tasks
                Task.Tasks.Add(newTask);

                cmd = new SqlCommand("CreateTaskCategory", DBConnection.Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@TaskID", newTask.ID), new SqlParameter("@CategoryID", newTask.Category.ID) });

                cmd.ExecuteNonQuery();

                isAdded = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }

            return isAdded;
        }

        public static void ReadTasksData()
        {
            DataSet ds;

            SqlCommand cmd;
            SqlDataAdapter adap;

            cmd = new SqlCommand("ReadTasksData", DBConnection.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            adap = new SqlDataAdapter(cmd);

            ds = new DataSet();

            try
            {
                adap.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    Task.Tasks.Clear();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Task.Tasks.Add(new Task()
                        {
                            ID = (int)dr["ID"],
                            Name = dr["Name"].ToString(),
                            StartDate = (DateTime)dr["StartDate"],
                            EndDate = (DateTime)dr["EndDate"],
                            Type = (TaskType)Enum.Parse(typeof(TaskType), dr["Type"].ToString()),
                            Details = dr["Details"].ToString(),
                            Category = new Category()
                            {
                                ID = (int)dr["CategoryID"],
                                Name = dr["Name1"].ToString()
                            }
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }
        }

        public static bool UpdateTask(Task updatedTask)
        {
            bool isUpdated = false;

            Task oldTask;

            SqlCommand cmd;

            try
            {
                // Get Old Task from the list
                oldTask = Task.GetTaskByID(updatedTask.ID);

                // Update TaskCategory (if needed)
                if (oldTask.Category.ID != updatedTask.Category.ID)
                {
                    cmd = new SqlCommand("UpdateTaskCategory", DBConnection.Conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@TaskID", updatedTask.ID), new SqlParameter("@CategoryID", updatedTask.Category.ID) });
                    cmd.ExecuteNonQuery();
                }

                // Update Task Table
                cmd = new SqlCommand("UpdateTask", DBConnection.Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@ID", updatedTask.ID), new SqlParameter("@Name", updatedTask.Name), new SqlParameter("@StartDate", updatedTask.StartDate), new SqlParameter("@EndDate", updatedTask.EndDate), new SqlParameter("@Type", updatedTask.Type.ToString()), new SqlParameter("@Details", updatedTask.Details) });
                cmd.ExecuteNonQuery();

                // Update Task in list
                Task.GetTaskByID(oldTask.ID).Update(updatedTask);

                isUpdated = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }

            return isUpdated;
        }

        public static bool DeleteTask(int taskID)
        {
            bool isDeleted = false;

            SqlCommand cmd;

            // check that this id exists
            if (Task.GetTaskByID(taskID) == null || Task.Tasks.Count == 0)
            {
                return isDeleted;
            }

            try
            {
                // Delete Record from TaskCategory
                cmd = new SqlCommand("DeleteRecord", DBConnection.Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@Table", "TaskCategory"), new SqlParameter("IDColName", "TaskID"), new SqlParameter("@ID", taskID) });
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("DeleteRecord", DBConnection.Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@Table", "Task"), new SqlParameter("IDColName", "ID"), new SqlParameter("@ID", taskID) });
                cmd.ExecuteNonQuery();

                Task.Tasks.Remove(Task.GetTaskByID(taskID));

                DBCommands.UpdateTaskIdentitySeed();
                DBCommands.UpdateTaskCategoryIdentitySeed();

                isDeleted = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }

            return isDeleted;
        }

        #endregion

        #region Category CRUD

        public static bool CreateCategory(Category newCategory)
        {
            bool isAdded = false;

            SqlCommand cmd;

            cmd = new SqlCommand("CreateCategory", DBConnection.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@Name", newCategory.Name) });

            try
            {
                cmd.ExecuteNonQuery();

                Category.Categories.Add(newCategory);

                isAdded = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }

            return isAdded;
        }

        public static void ReadCategories()
        {
            DataSet ds;

            SqlCommand cmd;
            SqlDataAdapter adap;

            cmd = new SqlCommand("ReadTable", DBConnection.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Table", "Category");
            adap = new SqlDataAdapter(cmd);

            ds = new DataSet();

            try
            {
                adap.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    Category.Categories.Clear();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Category.Categories.Add(new Category()
                        {
                            ID = (int)dr["ID"],
                            Name = dr["Name"].ToString()
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }
        }

        public static bool UpdateCategory(Category updatedCategory)
        {
            bool isUpdated = false;

            Category oldCategory;

            SqlCommand cmd;

            try
            {
                // Get Old Category from the list
                oldCategory = Category.GetCategoryByID(updatedCategory.ID);

                // Update Category Table
                cmd = new SqlCommand("UpdateCategory", DBConnection.Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@ID", updatedCategory.ID), new SqlParameter("@Name", updatedCategory.Name) });
                cmd.ExecuteNonQuery();

                // Update Task in list
                Category.GetCategoryByID(oldCategory.ID).Name = updatedCategory.Name;

                isUpdated = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }

            return isUpdated;
        }

        public static bool DeleteCategory(int CategoryID)
        {
            bool isDeleted = false;

            SqlCommand cmd;

            // check that this id exists
            if (CategoryID == 1 || Category.GetCategoryByID(CategoryID) == null || Category.Categories.Count == 0)
            {
                return isDeleted;
            }

            try
            {
                Task newTask;
                foreach (Task t in Task.Tasks)
                {
                    if (t.Category.ID == CategoryID)
                    {
                        newTask = new Task(t);
                        newTask.Category = Category.Categories[0];
                        DBCommands.UpdateTask(newTask);
                    }
                }

                cmd = new SqlCommand("DeleteRecord", DBConnection.Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@Table", "Category"), new SqlParameter("IDColName", "ID"), new SqlParameter("@ID", CategoryID) });
                cmd.ExecuteNonQuery();

                Category.Categories.Remove(Category.GetCategoryByID(CategoryID));

                DBCommands.UpdateCategoryIdentitySeed();

                isDeleted = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }

            return isDeleted;
        }

        #endregion

        #region IdentityCol_Task

        public static int ReadTaskMaxIdentityCol()
        {
            return DBTableIdentity.ReadMaxIdentityCol("Task");
        }

        public static int ReadTaskIdentitySeed()
        {
            return new DBTableIdentity().ReadIdentitySeed("Task");
        }

        public static bool UpdateTaskIdentitySeed()
        {
            bool updated = false;

            DBTableIdentity ti = new DBTableIdentity();

            int maxID = DBCommands.ReadTaskMaxIdentityCol();

            if (DBCommands.ReadTaskIdentitySeed() != maxID)
            {
                DBTableIdentity.UpdateIdentitySeed("Task", maxID);

                updated = true;
            }

            return updated;
        }

        #endregion

        #region IdentityCol_TaskCategory

        public static int ReadTaskCategoryMaxIdentityCol()
        {
            return DBTableIdentity.ReadMaxIdentityCol("TaskCategory");
        }

        public int ReadTaskCategoryIdentitySeed()
        {
            return new DBTableIdentity().ReadIdentitySeed("TaskCategory");
        }

        public static bool UpdateTaskCategoryIdentitySeed()
        {
            bool updated = false;

            DBTableIdentity ti = new DBTableIdentity();

            int maxID = DBTableIdentity.ReadMaxIdentityCol("TaskCategory");

            if (ti.ReadIdentitySeed("TaskCategory") != maxID)
            {
                DBTableIdentity.UpdateIdentitySeed("TaskCategory", maxID);

                updated = true;
            }

            return updated;
        }

        #endregion

        #region IdentityCol_Category

        public static int ReadCategoryMaxIdentityCol()
        {
            return DBTableIdentity.ReadMaxIdentityCol("Category");
        }

        public static int ReadCategoryIdentitySeed()
        {
            return new DBTableIdentity().ReadIdentitySeed("Category");
        }

        public static bool UpdateCategoryIdentitySeed()
        {
            bool updated = false;

            DBTableIdentity ti = new DBTableIdentity();

            int maxID = DBCommands.ReadCategoryMaxIdentityCol();

            if (DBCommands.ReadCategoryIdentitySeed() != maxID)
            {
                DBTableIdentity.UpdateIdentitySeed("Category", maxID);

                updated = true;
            }

            return updated;
        }

        #endregion
    }
}