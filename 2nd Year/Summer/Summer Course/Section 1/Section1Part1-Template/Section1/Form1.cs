using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Section1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Section1.Rectangle myRectangle = new Section1.Rectangle(e.X, e.Y, 50, 50);
            
            Graphics g = CreateGraphics();
            myRectangle.Draw(g);
        }
    }
}
