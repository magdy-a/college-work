using System;
using System.Collections.Generic;
using System.Text;
using ShapesLib;
using System.Drawing;
using ShapesLib;

namespace Section4
{
    class GDICircle:GDIShape
    {
        private Circle _circle;

        public GDICircle(Circle circle)
        {
            _circle = circle;
        }

        public override void Draw(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(_circle.FillColor);
            g.FillEllipse(sBrush, _circle.X - _circle.Radius, _circle.Y - _circle.Radius, 2 * _circle.Radius, 2 * _circle.Radius);

            #region Section3 Code
            Pen myPen = new Pen(_circle.PenColor, _circle.PenWidth);
            g.DrawEllipse(myPen, _circle.X - _circle.Radius, _circle.Y - _circle.Radius, 2 * _circle.Radius, 2 * _circle.Radius);
            #endregion

        }

        #region Section3 method
        public override void DrawForCreation(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(Color.FromArgb(128, _circle.FillColor));
            g.FillEllipse(sBrush, _circle.X - _circle.Radius, _circle.Y - _circle.Radius, 2 * _circle.Radius, 2 * _circle.Radius);

            Pen myPen = new Pen(_circle.PenColor, _circle.PenWidth);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawEllipse(myPen, _circle.X - _circle.Radius, _circle.Y - _circle.Radius, 2 * _circle.Radius, 2 * _circle.Radius);
            
        }

        #endregion

    }
}
