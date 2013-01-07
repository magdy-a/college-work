using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShapesLib
{
    public class Circle : Shape
    {
        #region constructor(s)

        public Circle(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
            
            FillColor = Color.Yellow; //Yellow is a static member of class Color
        }

        #endregion

        #region Members

        private int _radius;
        #endregion

        #region Properities
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        #endregion

        #region Methods
        public override void Draw(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(FillColor);
            g.FillEllipse(sBrush, X - Radius , Y - Radius, 2*Radius, 2*Radius);

            #region Section3 Code
            Pen myPen = new Pen(PenColor, PenWidth);
            g.DrawEllipse(myPen, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            #endregion

        }

        public override void Scale(double factor)
        {
            Radius = (int)((double)Radius * factor);
        }

        public override bool PointInShape(int x, int y)
        {
            if ((double)(System.Math.Pow(x - X, 2) + System.Math.Pow(y - Y, 2)) < (double)(Radius) * Radius)
                return true;
            else
                return false;

        }
        #region Section3 method
        public override void DrawForCreation(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(Color.FromArgb(128, FillColor));
            g.FillEllipse(sBrush, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);

            Pen myPen = new Pen(PenColor, PenWidth);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawEllipse(myPen, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);

        }

        #endregion
        
        #endregion


    }
}
