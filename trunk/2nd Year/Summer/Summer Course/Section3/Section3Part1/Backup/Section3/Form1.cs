using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Section3
{
    #region Section2 Enum
    enum SHAPENAME { NONE, RECTANGLE, ELLIPSE, CIRCLE };
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
        Shape selectedShape = null;
        bool secondClick = false;
        int firstPointX;
        int firstPointY;
        #endregion


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            #region Section2 Code
            Shape newShape = null;
            if (shapeToBeDrawn == SHAPENAME.NONE)
            {
                selectedShape = null;
                for (int i = 0; i < allShapes.Count; i++)
                {
                    if (allShapes[i].PointInShape(e.X, e.Y))
                        selectedShape = allShapes[i];
                }
                return;
            }

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
                    case SHAPENAME.CIRCLE:
                        int Radius = (int)Math.Sqrt(Math.Pow(e.X - firstPointX, 2) + Math.Pow(e.Y - firstPointY,2));
                        newShape = new Circle(firstPointX, firstPointY, Radius); 
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
        
        private void btnCircle_Click(object sender, EventArgs e)
        {
            shapeToBeDrawn = SHAPENAME.CIRCLE;
        }
        

        private void mnuChangeColor_Click(object sender, EventArgs e)
        {
            if (selectedShape == null)
            {
                MessageBox.Show("Please select a shape first!");
                return;
            }
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedShape.FillColor = colorDialog1.Color;
                Invalidate();
            }
        }
        
        private void mnuScale_Click(object sender, EventArgs e)
        {
            if (selectedShape == null)
            {
                MessageBox.Show("Please select a shape first!");
                return;
            }
            ScaleForm myScaleForm = new ScaleForm() ;
            if (myScaleForm.ShowDialog() == DialogResult.OK)
            {
                selectedShape.Scale(myScaleForm.ScaleFactor);
                Invalidate();
            }
        }
        #endregion

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}