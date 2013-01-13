namespace IPClassLibrary.StaticClasses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Logger class for application exceptions.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// The log file path.
        /// </summary>
        private static string logFilePath;

        /// <summary>
        /// Tmp Object carries the Last Exception
        /// </summary>
        private static Exception lastException;

        /// <summary>
        /// Boolean indicates if a new Exception has arrived
        /// </summary>
        private static bool newExceptoin = false;

        /// <summary>
        /// Gets the Tmp Exception
        /// </summary>
        public static Exception Exception
        {
            get
            {
                newExceptoin = false;
                return lastException;
            }
        }

        /// <summary>
        /// Gets a value indicating whether a new exception has arrived
        /// </summary>
        public static bool IsNewException
        {
            get { return newExceptoin; }
        }

        /// <summary>
        /// Gets or sets the log file path.
        /// </summary>
        /// <value>The log file path.</value>
        public static string LogFilePath
        {
            get { return logFilePath; }
            set { logFilePath = value; }
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="ex">The Exception to Log</param>
        public static void LogException(Exception ex)
        {
            lastException = ex;
            newExceptoin = true;

            if (string.IsNullOrEmpty(logFilePath))
            {
                logFilePath = Application.ExecutablePath + "\\..\\log.txt";
            }

            string message = "-----------------------------------------------------" + Environment.NewLine;
            message += "DateTime: " + DateTime.Now.ToString() + Environment.NewLine;
            message += "Message: " + ex.Message + Environment.NewLine;
            if (ex.InnerException != null)
            {
                message += "Inner Exception: " + ex.InnerException.Message;
            }

            message += "Stack Trace: " + ex.StackTrace + Environment.NewLine;
            FileStream fileStream;
            StreamWriter streamWriter;
            try
            {
                fileStream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                streamWriter = new StreamWriter(fileStream);
                if (fileStream.CanWrite == true)
                {
                    streamWriter.Write(message + Environment.NewLine);
                }

                streamWriter.Close();
                fileStream.Close();
            }
            catch
            {
            }

            streamWriter = null;
            fileStream = null;
        }
    }
}
