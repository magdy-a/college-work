using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace TaskManager
{

    /// <summary>
    /// Handles Reading and Updating Table'list Identity Seed
    /// </summary>
    public class DBTableIdentity
    {

        #region Attributes

        private int currentIdentity, currentColumn;

        private static DBTableIdentity ti = new DBTableIdentity();

        #endregion

        #region Constructor

        public DBTableIdentity()
        {
        }

        #endregion

        #region properties

        public int CurrentIdentity
        {
            get { return this.currentIdentity; }
            set { this.currentIdentity = value; }
        }

        public int CurrentColumn
        {
            get { return this.currentColumn; }
            set { this.currentColumn = value; }
        }

        public static DBTableIdentity TI
        {
            get { return DBTableIdentity.ti; }
            protected set { DBTableIdentity.ti = value; }
        }

        #endregion

        #region Methods

        #region Read Max Identity Col

        /// <summary>
        /// Reads the Max of Identity Column value in a Table
        /// </summary>
        /// <returns>Man Column ID</returns>
        public static int ReadMaxIdentityCol(string TableName)
        {
            int lastIdentity = 0;

            DataSet ds;

            SqlCommand cmd;
            SqlDataAdapter adap;

            cmd = new SqlCommand("ReadMaxIdentityCol", DBConnection.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Table", TableName);

            adap = new SqlDataAdapter(cmd);

            ds = new DataSet();

            try
            {
                adap.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr[0] == DBNull.Value)
                        {
                            lastIdentity = 0;
                        }
                        else
                        {
                            lastIdentity = (int)dr[0];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }

            return lastIdentity;
        }

        #endregion

        #region Read Identity Seed

        /// <summary>
        /// Read Identity Seed (Last ID used - even if deleted from the table), value+1 will be next record's ID
        /// </summary>
        /// <returns>Identity Seed for table Task</returns>
        public static int ReadIdentitySeed(string TableName)
        {
            return DBTableIdentity.TI._ReadIdentitySeed(TableName);
        }

        /// <summary>
        /// Read Identity Seed (Last ID used - even if deleted from the table), value+1 will be next record's ID
        /// </summary>
        /// <returns>Identity Seed for table Task</returns>
        private int _ReadIdentitySeed(string TableName)
        {
            this.currentIdentity = this.currentColumn = 0;

            DataSet ds;

            SqlCommand cmd;
            SqlDataAdapter adap;

            DBConnection.Conn.InfoMessage += new SqlInfoMessageEventHandler(Conn_InfoMessage);

            cmd = new SqlCommand("ReadIdentitySeed", DBConnection.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Table", TableName);

            adap = new SqlDataAdapter(cmd);

            ds = new DataSet();

            try
            {
                adap.Fill(ds);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }
            finally
            {
                DBConnection.Conn.InfoMessage -= Conn_InfoMessage;
            }

            return this.currentIdentity;
        }

        /// <summary>
        /// Event for reading Info Messages from SQL
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="eventArgs">Sql Info Message Object</param>
        private void Conn_InfoMessage(object sender, SqlInfoMessageEventArgs eventArgs)
        {
            List<string> list = new List<string>(eventArgs.Message.Split(new char[] { '\'' }));

            try
            {
                if (list.Count > 1)
                {
                    this.currentIdentity = int.Parse(list[1]);
                    this.currentColumn = int.Parse(list[3]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }
        }

        #endregion

        #region Update Identity Seed

        /// <summary>
        /// Updates the Identity seed for identity col, according to the max Identity_col
        /// </summary>
        /// <param name="TableName">Table Name</param>
        /// <returns>indicates whether value was updated or not</returns>
        public static bool UpdateIdentitySeed(string TableName)
        {
            bool isChanged = false;

            SqlCommand cmd;

            int maxID = 0;

            maxID = DBTableIdentity.ReadMaxIdentityCol(TableName);

            if (DBTableIdentity.ReadIdentitySeed(TableName) != maxID)
            {
                // If newSeed is 2, next entry use number 3
                cmd = new SqlCommand("UpdateIdentitySeed", DBConnection.Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@Table", TableName), new SqlParameter("@newSeed", maxID) });

                try
                {
                    cmd.ExecuteNonQuery();

                    isChanged = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error!");
                }
            }
            else
            {
                isChanged = true;
            }

            return isChanged;

            /*
            SELECT MAX(IDENTITYCOL) AS MaximumIdentity, MIN(IDENTITYCOL) AS MinimumIdentity
            FROM Task
            */
            /*DBCC CHECKIDENT(Task, RESEED)*/
        }

        /// <summary>
        /// Updates the Identity seed for identity col - Old Technique
        /// </summary>
        /// <param name="TableName">Table Name</param>
        /// <param name="newSeed">New Seed Value</param>
        /// <returns>indicates whether value was updated or not</returns>
        private static bool UpdateIdentitySeed_Manual_Technique(string TableName, int newSeed)
        {
            bool isChanged = false;

            SqlCommand cmd;

            // If newSeed is 2, next entry use number 3
            cmd = new SqlCommand("UpdateIdentitySeed", DBConnection.Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@Table", TableName), new SqlParameter("@newSeed", newSeed) });

            try
            {
                cmd.ExecuteNonQuery();

                isChanged = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }

            return isChanged;

            /*
            SELECT MAX(IDENTITYCOL) AS MaximumIdentity, MIN(IDENTITYCOL) AS MinimumIdentity
            FROM Task
            */
            /*DBCC CHECKIDENT(Task, RESEED)*/
        } 

        #endregion

        #endregion
    }
}
