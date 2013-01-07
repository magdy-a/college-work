using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Section1
{
    class Rectangle:Shape
    {
        #region constructor(s)
        
        public Rectangle(int x,int y,int width,int height )
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            FillColor = Color.Red; //Orange is a static member of class Color
        }
        
        #endregion

        #region Members

        public int Width;
        public int Height;        

        #endregion

        #region Methods
        public override void Draw(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(FillColor);
            g.FillRectangle(sBrush, X, Y, Width, Height);
        }
        #endregion
    }
}
