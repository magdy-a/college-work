using System;
using System.Collections.Generic;
using System.Text;
using ShapesLib;
using System.Drawing;
using ShapesLib;

namespace Section4
{
    class GDIEllipse:GDIShape
    {
        private Ellipse _ellipse;

        public GDIEllipse(Ellipse ellipse)
        {
            _ellipse = ellipse;
        }


        public override void Draw(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(_ellipse.FillColor);
            g.FillEllipse(sBrush, _ellipse.X, _ellipse.Y, _ellipse.R1, _ellipse.R2);

            #region Section3 Code
            Pen myPen = new Pen(_ellipse.PenColor, _ellipse.PenWidth);
            g.DrawEllipse(myPen, _ellipse.X, _ellipse.Y, _ellipse.R1, _ellipse.R2);
            #endregion
        }

        #region Section3 method
        public override void DrawForCreation(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(Color.FromArgb(128, _ellipse.FillColor));
            g.FillEllipse(sBrush, _ellipse.X, _ellipse.Y, _ellipse.R1, _ellipse.R2);

            Pen myPen = new Pen(_ellipse.PenColor, _ellipse.PenWidth);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawEllipse(myPen, _ellipse.X, _ellipse.Y, _ellipse.R1, _ellipse.R2);
        }

        #endregion


    }
}
