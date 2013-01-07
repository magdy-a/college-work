using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Section2
{
    #region Section2 Enum
    enum SHAPENAME { NONE, RECTANGLE, ELLIPSE };
    #endregion

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Our Shapes ArrayList
        List<Shape> allShapes = new List<Shape>();

        #region Section2 Data
        SHAPENAME selectedShape = SHAPENAME.NONE;
        #endregion


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            #region Section2 Code
            Shape newShape = null;
            switch (selectedShape)
            {
                case SHAPENAME.RECTANGLE:
                    newShape = new Rectangle(e.X, e.Y, 50, 50);
                    break;
                case SHAPENAME.ELLIPSE:
                    newShape = new Ellipse(e.X, e.Y, 50, 70);
                    break;
                default:
                    return;
            }
            #endregion
            //add new Shape to our shapes container
            allShapes.Add(newShape);

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

        #region Section2 Methods
        private void btnRect_Click(object sender, EventArgs e)
        {
            selectedShape = SHAPENAME.RECTANGLE;
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            selectedShape = SHAPENAME.ELLIPSE;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            selectedShape = SHAPENAME.NONE;
        }
        #endregion
    }
}