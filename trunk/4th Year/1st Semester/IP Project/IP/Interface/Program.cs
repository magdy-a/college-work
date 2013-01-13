namespace PhotoLab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Program Class, that starts the Solution
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The Main Form
        /// </summary>
        private static IPForm mainForm;

        /// <summary>
        /// Gets the MainForm
        /// </summary>
        public static IPForm MainForm
        {
            get { return mainForm; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new IPForm();

            Application.Run(mainForm);
        }
    }
}
