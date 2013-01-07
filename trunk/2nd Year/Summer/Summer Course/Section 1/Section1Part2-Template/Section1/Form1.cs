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

        //Our Shapes ArrayList
        List<Shape> allShapes = new List<Shape>();

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Section1.Rectangle myRectangle = new Section1.Rectangle(e.X, e.Y, 50, 50);
            
            //add it to our shapes container
            allShapes.Add(myRectangle);

            //the same for the ellipse
            Section1.Ellipse myEllipse = new Section1.Ellipse(e.X, e.Y + 50, 50, 70);            
            allShapes.Add(myEllipse);
            
            Invalidate(); //Let the form know that it is not valid 
                            // anymore, forcing it to redraw itself ...
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //here redrawing ...            
            for (int i = 0; i < allShapes.Count; i++)
            {
                //use the graphics object in "e" to draw
                allShapes[i].Draw(e.Graphics);
            }
        }
    }
}
