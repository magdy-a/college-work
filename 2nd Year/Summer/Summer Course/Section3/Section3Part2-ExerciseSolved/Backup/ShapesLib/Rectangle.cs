using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShapesLib
{
    public class Rectangle : Shape
    {
        #region constructor(s)

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            FillColor = Color.Red; //Orange is a static member of class Color

        }

        #endregion

        #region Members

        private int _width;
        private int _height;

        #endregion

        #region Properities
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        #endregion

        #region Methods
        public override void Draw(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(FillColor);
            g.FillRectangle(sBrush, X, Y, Width, Height);

            #region Section3 Code
            Pen myPen = new Pen(PenColor, PenWidth);
            g.DrawRectangle(myPen, X, Y, Width, Height);
            #endregion
        }

        public override void Scale(double factor)
        {
            Width = (int)((double)Width * factor);
            Height = (int)((double)Height * factor);
        }

        #region Section2 methods
        public override bool PointInShape(int x, int y)
        {
            if (x >= X && x < (X + Width) && y >= Y && y < (Y + Height))
                return true;
            else
                return false;
        }
        #endregion

        #region Section3 method
        public override void DrawForCreation(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(Color.FromArgb(128, FillColor));
            g.FillRectangle(sBrush, X, Y, Width, Height);

            Pen myPen = new Pen(PenColor, PenWidth);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawRectangle(myPen, X, Y, Width, Height);
        }

        #endregion

        #endregion


        
    }
}
