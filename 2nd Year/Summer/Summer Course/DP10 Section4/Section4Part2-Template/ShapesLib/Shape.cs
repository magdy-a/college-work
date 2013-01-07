using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShapesLib
{
    public abstract class Shape
    {
        #region Section3 constructor(s)
        public Shape()
        {
            PenColor = Color.Black;
            PenWidth = 1.5f;

        }
        #endregion

        #region Members
        protected Color _fillColor;
        protected int _x;
        protected int _y;
        
        #region Section3
        protected Color _penColor;
        protected float _penWidth;
        #endregion
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
        public Color FillColor
        {
            get { return _fillColor; }
            set { _fillColor = value; }
        }
        #region Section3
        public Color PenColor
        {
            get { return _penColor; }
            set { _penColor = value; }
        }

        public float PenWidth
        {
            get { return _penWidth; }
            set { _penWidth = value; }
        }
        #endregion
        #endregion

        #region Methods
        public abstract void Scale(double factor);
        
        #region Section2
        public abstract bool PointInShape(int X, int Y);
        #endregion

        #region Section3
        public virtual void Translate(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }
        #endregion
        
        #endregion
    }
}
