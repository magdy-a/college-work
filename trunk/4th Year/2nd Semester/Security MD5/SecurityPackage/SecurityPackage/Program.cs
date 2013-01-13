using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SecurityLibrary;

namespace SecurityPackage
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //int x = 5 | 6;
            //long y = 4294967296;
            //x = int.MaxValue;
            //uint z = uint.MaxValue;
            //List<byte> l = new List<byte>(BitConverter.GetBytes(z));
            //string str = string.Empty;
            //l.ForEach(j => str += Convertors.FromIntToBinary(j, 8));
            //MessageBox.Show(str);

            Application.Run(new MainForm());
        }
    }
}