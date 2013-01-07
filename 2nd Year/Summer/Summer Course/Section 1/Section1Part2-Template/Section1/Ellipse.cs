using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Section1
{
    class Ellipse:Shape
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
        public int R1;
        public int R2;
        #endregion

        #region Methods
        public override void Draw(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(FillColor);
            g.FillEllipse(sBrush, X, Y, R1, R2);
        }
        #endregion
    }
}
