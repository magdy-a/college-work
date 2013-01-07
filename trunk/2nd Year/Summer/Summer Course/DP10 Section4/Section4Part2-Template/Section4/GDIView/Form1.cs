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
    enum SHAPENAME { NONE, RECTANGLE, ELLIPSE, CIRCLE };
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        #region Section2 Data
        SHAPENAME shapeToBeDrawn = SHAPENAME.NONE;
        Shape selectedShape = null;
        bool secondClick = false;
        int firstPointX;
        int firstPointY;
        #endregion 

        #region Section3 Data
        bool mouseDown = false;
        Shape tmpShape = null;
        #endregion

        GraFICSModel Model = new GraFICSModel();
        List<GDIShape> allGDIShapes = new List<GDIShape>();
        GDIShape tmpGDIShape;
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //here redrawing ...            
            for (int i = 0; i < allGDIShapes.Count; i++)
            {
                //use the graphics object in "e" to draw
                allGDIShapes[i].Draw(e.Graphics);
            }

            #region Section3 Code
            if (tmpGDIShape != null)
                tmpGDIShape.DrawForCreation(e.Graphics);
            #endregion
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

        #region Section3 Methods
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            firstPointX = e.X;
            firstPointY = e.Y;

            #region If SELECTION mode
            if (shapeToBeDrawn == SHAPENAME.NONE)
            {
                selectedShape = Model.GetShapeAtPt(e.X, e.Y);
            }
            #endregion

            #region If DRAWING mode
            else
            {
                int InitialDimention = 2;
                switch (shapeToBeDrawn)
                {
                    case SHAPENAME.RECTANGLE:
                        tmpShape = new ShapesLib.Rectangle(firstPointX, firstPointY, InitialDimention, InitialDimention);
                        tmpGDIShape = new GDIRectangle((ShapesLib.Rectangle)tmpShape);
                        break;
                    case SHAPENAME.ELLIPSE:
                        tmpShape = new Ellipse(firstPointX, firstPointY, InitialDimention, InitialDimention);
                        tmpGDIShape = new GDIEllipse((ShapesLib.Ellipse)tmpShape);
                        break;
                    case SHAPENAME.CIRCLE:
                        int Radius = InitialDimention / 2;
                        tmpShape = new Circle(firstPointX, firstPointY, Radius);
                        tmpGDIShape = new GDICircle((ShapesLib.Circle)tmpShape);
                        break;

                    default:
                        return;
                }
                Invalidate();
            }
            #endregion

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            #region If NO mouseDown
            if (!mouseDown)
                return;
            #endregion

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
            #endregion

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
                    case SHAPENAME.ELLIPSE:
                        tmpShape.X = TopLeftX;
                        tmpShape.Y = TopLeftY;
                        ((ShapesLib.Ellipse)tmpShape).R1 = Width;
                        ((ShapesLib.Ellipse)tmpShape).R2 = Height;
                        break;
                    case SHAPENAME.CIRCLE:
                        int Radius = (int)Math.Sqrt(Math.Pow(e.X - firstPointX, 2) + Math.Pow(e.Y - firstPointY, 2));
                        tmpShape.X = firstPointX;
                        tmpShape.Y = firstPointY;
                        ((ShapesLib.Circle)tmpShape).Radius = Radius;
                        break;
                    default:
                        return;
                }

            }
            #endregion

            Invalidate();
        }

 
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            #region If NO mouseDown
            if (!mouseDown)
                return;
            #endregion

            mouseDown = false;

            #region If DRAWING mode
            if (shapeToBeDrawn != SHAPENAME.NONE)
            {
                //add the temp Shape to our shapes container
                Model.AddShape(tmpShape);
                allGDIShapes.Add(tmpGDIShape);

                tmpShape = null;
                tmpGDIShape = null;

                Invalidate(); //Let the form know that it is not valid 
                // anymore, forcing it to redraw itself ...
            }
            #endregion
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
        #endregion
    }
}