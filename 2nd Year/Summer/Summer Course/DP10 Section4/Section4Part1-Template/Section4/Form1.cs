using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShapesLib;

namespace Section4
{
    internal enum SHAPENAME { NONE, RECTANGLE, ELLIPSE, CIRCLE };

    public partial class Form1 : Form
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();

            this.g = this.pictureBox1.CreateGraphics();
        }

        //Our Shapes ArrayList
        List<Shape> allShapes = new List<Shape>();

        #region Section2 Data

        SHAPENAME shapeToBeDrawn = SHAPENAME.NONE;
        Shape selectedShape = null;
        //bool secondClick = false;
        int firstPointX;
        int firstPointY;

        #endregion Section2 Data

        #region Section3 Data

        bool mouseDown = false;
        Shape tmpShape = null;

        #endregion Section3 Data

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //here redrawing ...
            for (int i = 0; i < allShapes.Count; i++)
            {
                //use the graphics object in "e" to draw
                // TODO Recheck here : allShapes[i].Draw(e.Graphics);
                allShapes[i].Draw(this.g);
            }

            #region Section3 Code

            if (tmpShape != null)
            {
                // TODO Recheck here : tmpShape.DrawForCreation(e.Graphics);
                tmpShape.DrawForCreation(this.g);
            }

            #endregion Section3 Code
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
            ScaleForm myScaleForm = new ScaleForm();
            if (myScaleForm.ShowDialog() == DialogResult.OK)
            {
                selectedShape.Scale(myScaleForm.ScaleFactor);
                Invalidate();
            }
        }

        #endregion Section2 Methods

        #region Section3 Methods

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            firstPointX = e.X;
            firstPointY = e.Y;

            #region If SELECTION mode

            if (shapeToBeDrawn == SHAPENAME.NONE)
            {
                selectedShape = null;
                for (int i = 0; i < allShapes.Count; i++)
                {
                    if (allShapes[i].PointInShape(e.X, e.Y))
                        selectedShape = allShapes[i];
                }
            }

            #endregion If SELECTION mode

            #region If DRAWING mode

            else
            {
                int InitialDimention = 2;
                switch (shapeToBeDrawn)
                {
                    case SHAPENAME.RECTANGLE:
                        tmpShape = new ShapesLib.Rectangle(firstPointX, firstPointY, InitialDimention, InitialDimention);
                        break;
                    default:
                        return;
                }
                Invalidate();
            }

            #endregion If DRAWING mode
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            #region If NO mouseDown

            if (!mouseDown)
                return;

            #endregion If NO mouseDown

            #region If SELECTION mode

            if (shapeToBeDrawn == SHAPENAME.NONE)
            {
                if (selectedShape != null)
                {
                    int deltaX = e.X - firstPointX;
                    int deltaY = e.Y - firstPointY;
                    selectedShape.Translate(deltaX, deltaY);
                    firstPointX = e.X;
                    firstPointY = e.Y;
                }
            }

            #endregion If SELECTION mode

            #region If DRAWING mode

            else
            {
                int TopLeftX = 0, TopLeftY = 0, Width = 0, Height = 0;
                GetBoundingBox(firstPointX, firstPointY, e.X, e.Y, ref TopLeftX, ref TopLeftY, ref Width, ref Height);

                switch (shapeToBeDrawn)
                {
                    case SHAPENAME.RECTANGLE:
                        tmpShape.X = TopLeftX;
                        tmpShape.Y = TopLeftY;
                        ((ShapesLib.Rectangle)tmpShape).Width = Width;
                        ((ShapesLib.Rectangle)tmpShape).Height = Height;
                        break;
                    default:
                        return;
                }
            }

            #endregion If DRAWING mode

            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            #region If NO mouseDown

            if (!mouseDown)
                return;

            #endregion If NO mouseDown

            mouseDown = false;

            #region If DRAWING Mode

            if (shapeToBeDrawn != SHAPENAME.NONE)
            {
                //add the temp Shape to our shapes container
                allShapes.Add(tmpShape);

                tmpShape = null;

                Invalidate(); //Let the form know that it is not valid
                // anymore, forcing it to redraw itself ...
            }

            #endregion If DRAWING Mode
        }

        private void GetBoundingBox(int firstPtX, int firstPtY, int secondPtX, int secondPtY, ref int topleftX, ref int topleftY, ref int width, ref int height)
        {
            width = Math.Abs(secondPtX - firstPtX);
            height = Math.Abs(secondPtY - firstPtY);

            topleftX = firstPtX;
            if (secondPtX < topleftX)
                topleftX = secondPtX;

            topleftY = firstPtY;
            if (secondPtY < topleftY)
                topleftY = secondPtY;
        }

        #endregion Section3 Methods
    }
}