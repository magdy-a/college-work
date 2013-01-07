using System;
using System.Windows.Forms;
namespace Files_Project{
    static class Program{
        static public mainForm myForm = null;
        public static string intToString(int integer){
            string Length = "";
            char x, y;
            x = (char)((integer % 10) + 48);
            integer = integer / 10;
            y = (char)((integer % 10) + 48);
            Length += y;
            Length += x;
            return Length;}
        public static int charArrToInt(char[] integer){
            int Length = 0;
            Length += (((int)integer[1]) - 48);
            Length += ((((int)integer[0]) - 48) * 10);
            return Length;}
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }}}
