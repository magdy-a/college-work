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
        SHAPENAME shapeToBeDrawn = SHAPENAME.NONE;
        bool secondClick = false;
        int firstPointX;
        int firstPointY;
        #endregion


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            #region Section2 Code
            Shape newShape = null;
            if (shapeToBeDrawn == SHAPENAME.NONE)
                return;
            if (!secondClick)
            {
                firstPointX = e.X;
                firstPointY = e.Y;
                secondClick = true;
            }
            else
            {
                int Width = Math.Abs(e.X - firstPointX);
                int Height = Math.Abs(e.Y - firstPointY);

                int TopLeftX = firstPointX;
                if (e.X < TopLeftX)
                    TopLeftX = e.X;

                int TopLeftY = firstPointY;
                if (e.Y < TopLeftY)
                    TopLeftY = e.Y;

                secondClick = false;

                switch (shapeToBeDrawn)
                {
                    case SHAPENAME.RECTANGLE:
                        newShape = new Rectangle(TopLeftX, TopLeftY, Width, Height);
                        break;
                    case SHAPENAME.ELLIPSE:
                        newShape = new Ellipse(TopLeftX, TopLeftY, Width, Height);
                        break;
                    default:
                        return;
                }

                //add new Shape to our shapes container
                allShapes.Add(newShape);

                Invalidate(); //Let the form know that it is not valid 
                // anymore, forcing it to redraw itself ...
            }
            #endregion
            
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
            shapeToBeDrawn = SHAPENAME.RECTANGLE;
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            shapeToBeDrawn = SHAPENAME.ELLIPSE;
        }
 
        private void btnSelect_Click(object sender, EventArgs e)
        {
            shapeToBeDrawn = SHAPENAME.NONE;
        }
        #endregion


    }
}