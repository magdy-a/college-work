using System;
using System.Windows.Forms;

namespace Bearing_Machine
{
    internal static class Program
    {
        static SystemStartup startupForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            startupForm = new SystemStartup();

            Application.Run(startupForm);

            if (startupForm.DialogResult != DialogResult.OK)
            {
                return;
            }

            Application.Run(new Bearing_Machine.BearingSimulation());
        }
    }
}