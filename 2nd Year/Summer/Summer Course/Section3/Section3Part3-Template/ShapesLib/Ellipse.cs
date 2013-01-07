using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShapesLib
{
    public class Ellipse : Shape
    {
        #region constructor(s)
        public Ellipse(int x, int y, int r1, int r2)
        {
            X = x;
            Y = y;
            R1 = r1;
            R2 = r2;
            FillColor = Color.Green;
        }
        #endregion

        #region Members
        private int _r1;
        private int _r2;
        #endregion

        #region Properities
        public int R1
        {
            get { return _r1; }
            set { _r1 = value; }
        }

        public int R2
        {
            get { return _r2; }
            set { _r2 = value; }
        }
        #endregion

        #region Methods
        public override void Draw(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(FillColor);
            Pen myPen = new Pen ( PenColor , PenWidth );

            g . FillEllipse ( new SolidBrush ( Color . Gray ) , X , Y - R1 / 2 + R2 / 2 , R1 , R1 );

            g.FillEllipse(sBrush, X, Y, R1, R2);

            
            g.DrawEllipse(myPen, X, Y, R1, R2);

            g.FillEllipse(new SolidBrush(Color.Yellow),X+R1/2-R2/2,Y,R2,R2);

            g . DrawRectangle ( myPen , X , Y , R1 , R2 );

            g . DrawLine ( myPen , new Point ( X + R1 / 2 , Y ) , new Point ( X + R1 / 2 , Y + R2 ) );
            g . DrawLine ( myPen , new Point ( X , Y + R2 / 2 ) , new Point ( X + R1 , Y + R2 / 2 ) );
        }
        public override void Scale(double factor)
        {
            R1 = (int)((double)R1 * factor);
            R2 = (int)((double)R2 * factor);
        }

        #region Section2 methods
        public override bool PointInShape(int x, int y)
        {
            int radius1 = R1 / 2;
            int radius2 = R2 / 2;
            int centerX = X + radius1;
            int centerY = Y + radius2;
            if ((double)(radius2 * radius2 * System.Math.Pow(x - centerX, 2) + radius1 * radius1 * System.Math.Pow(y - centerY, 2)) < (double)(radius1) * radius1 * radius2 * radius2)
                return true;
            else
                return false;
        }
        #endregion

        #region Section3 method
        public override void DrawForCreation(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(Color.FromArgb(128, FillColor));
            g.FillEllipse(sBrush, X, Y, R1, R2);

            Pen myPen = new Pen(PenColor, PenWidth);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawEllipse(myPen, X, Y, R1,R2);
        }

        #endregion

        #endregion

    }
}
