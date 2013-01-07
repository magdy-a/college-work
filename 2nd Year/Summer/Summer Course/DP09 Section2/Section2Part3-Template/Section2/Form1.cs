using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Section2
{
    internal enum SHAPENAME { NONE, RECTANGLE, ELLIPSE, CIRCLE };

    public partial class Form1 : Form
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();

            g = this.pictureBox1.CreateGraphics();
        }

        List<Shape> allShapes = new List<Shape>();

        SHAPENAME shapeToBeDrawn = SHAPENAME.NONE;
        Shape selectedShape = null;

        bool secondClick = false;
        bool moveOn = false;
        int dX = 0;
        int dY = 0;
        int firstPointX;
        int firstPointY;

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Shape newShape = null;
            if (moveOn)
            {
                selectedShape.X = e.X;
                selectedShape.Y = e.Y;
                moveOn = false;
                Invalidate();
            }
            if (!secondClick)
            {
                firstPointX = e.X;
                firstPointY = e.Y;
                secondClick = true;
            }
            if (shapeToBeDrawn == SHAPENAME.NONE)
            {
                selectedShape = null;
                for (int i = 0; i < allShapes.Count; i++)
                {
                    if (allShapes[i].PointInShape(e.X, e.Y))
                        selectedShape = allShapes[i];
                }
                if (selectedShape != null)
                {
                    dX = e.X - selectedShape.X;
                    dY = e.Y - selectedShape.Y;
                }
                return;
            }

            if (secondClick)
            {
                if (selectedShape != null)
                {
                    selectedShape.X = e.X + dX;
                    selectedShape.Y = e.Y + dY;
                    selectedShape = null;
                    Invalidate();
                    return;
                }
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
                        int Radius = (int)Math.Sqrt(Math.Pow(e.X - firstPointX, 2) + Math.Pow(e.Y - firstPointY, 2));
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
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //here redrawing ...
            for (int i = 0; i < allShapes.Count; i++)
            {
                //use the graphics object in "e" to draw
                // TODO recheck this : allShapes[i].Draw(e.Graphics);
                allShapes[i].Draw(this.g);
            }
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            shapeToBeDrawn = SHAPENAME.RECTANGLE;
            secondClick = false;
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            shapeToBeDrawn = SHAPENAME.ELLIPSE;
            secondClick = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            shapeToBeDrawn = SHAPENAME.NONE;
            secondClick = false;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            shapeToBeDrawn = SHAPENAME.CIRCLE;
            secondClick = false;
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
            selectedShape = null;
            secondClick = false;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            moveOn = true;
            if (selectedShape == null)
            {
                MessageBox.Show("Please select a shape first!");
                moveOn = false;
            }
        }
    }
}