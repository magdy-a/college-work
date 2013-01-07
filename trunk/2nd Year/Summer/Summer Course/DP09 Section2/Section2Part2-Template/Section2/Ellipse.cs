using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Section2
{
    class Ellipse : Shape
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
            g.FillEllipse(sBrush, X, Y, R1, R2);
        }
        public override void Scale(double factor)
        {
            R1 = (int)((double)R1 * factor);
            R2 = (int)((double)R2 * factor);
        }

        
        #endregion

    }
}
