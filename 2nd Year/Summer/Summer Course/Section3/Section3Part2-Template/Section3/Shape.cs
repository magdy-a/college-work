using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Section3
{
    abstract class Shape
    {
        #region Members
        public Color FillColor;
        private int _x;
        private int _y;
        #endregion

        #region Properities
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        #endregion

        #region Methods
        public abstract void Draw(Graphics g);
        public abstract void Scale(double factor);
        
        #region Section2
        public abstract bool PointInShape(int X, int Y);
        #endregion
        #endregion
    }
}
