namespace TaskManager
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    /// <summary>
    /// Handles Opening and Closing the Connection to the DB
    /// </summary>
    public class DBConnection
    {
        private static SqlConnection conn;

        private static string connectionString;

        private static bool isOpen;

        /// <summary>
        /// Gets or sets a value indicating whether the Connection to the DB is open or not
        /// </summary>
        public static bool IsOpen
        {
            get { return isOpen; }
            protected set { isOpen = value; }
        }

        /// <summary>
        /// Gets or sets The ConnectionString used to connect to the DB
        /// </summary>
        public static string ConnectionString
        {
            get { return DBConnection.connectionString; }
            protected set { DBConnection.connectionString = value; }
        }

        /// <summary>
        /// Gets or sets The SQLConnection to the DB, with the ConnectionString in the App.config file
        /// </summary>
        public static SqlConnection Conn
        {
            get { return DBConnection.conn; }
            protected set { DBConnection.conn = value; }
        }

        /// <summary>
        /// Open the Connection with DB
        /// </summary>
        /// <returns>Indicates whether DB is open or not</returns>
        public static bool OpenConnection()
        {
            isOpen = true;

            AppSettingsReader appSettings = new AppSettingsReader();
            AppSettingsSection sec = new AppSettingsSection();
            connectionString = ConfigurationManager.AppSettings["strConnectionString"];
            //connectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;

            conn = new SqlConnection(connectionString);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception e)
            {
                isOpen = false;

                MessageBox.Show(e.Message);
            }

            if (isOpen == false)
            {
                isOpen = true;

                connectionString = ConfigurationManager.AppSettings["strConnectionString"];
                //connectionString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
                conn = new SqlConnection(connectionString);

                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                }
                catch (Exception e)
                {
                    isOpen = false;

                    MessageBox.Show(e.Message);
                }
            }

            return isOpen;
        }

        /// <summary>
        /// Clos the Connection with DB
        /// </summary>
        /// <returns>Indicates whether DB is closed or not</returns>
        public static bool CloseConnection()
        {
            // if the TestRead isn'task open
            if (isOpen != true || conn == null)
            {
                // then the purpose of this function is done, and the TestRead is closed

                // just in case conn went null for some reason, and isOpen is still true
                isOpen = false;
            }
            else
            {
                try
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    isOpen = false;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                    return false;
                }
            }

            // all went good
            return !isOpen;
        }
    }
}