using System;
using System.Collections.Generic;
using System.Text;
using ShapesLib;
using System.Drawing;

namespace Section4
{
    class GDIRectangle:GDIShape
    {
        private ShapesLib.Rectangle _rect;
        
        public GDIRectangle(ShapesLib.Rectangle rect)
        {
            _rect = rect;
        }


        public override void Draw(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(_rect.FillColor);
            g.FillRectangle(sBrush, _rect.X, _rect.Y, _rect.Width, _rect.Height);

            #region Section3 Code
            Pen myPen = new Pen(_rect.PenColor, _rect.PenWidth);
            g.DrawRectangle(myPen, _rect.X, _rect.Y, _rect.Width, _rect.Height);
            #endregion
        }

        #region Section3 method
        public override void DrawForCreation(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(Color.FromArgb(128, _rect.FillColor));
            g.FillRectangle(sBrush, _rect.X, _rect.Y, _rect.Width, _rect.Height);

            Pen myPen = new Pen(_rect.PenColor, _rect.PenWidth);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawRectangle(myPen, _rect.X, _rect.Y, _rect.Width, _rect.Height);
        }

        #endregion

    }
}
