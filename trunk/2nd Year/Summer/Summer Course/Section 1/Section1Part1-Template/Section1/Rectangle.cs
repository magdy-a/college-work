using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Section1
{
    public class Rectangle
    {
        #region constructor(s)
        
        public Rectangle(int x,int y,int width,int height )
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            FillColor = Color.Red; //Red is a static member of class Color
        }
        
        #endregion

        #region Members

        public int X;
        public int Y; 
        public int Width;
        public int Height;


        public Color FillColor;       
        #endregion

        #region Methods
        public void Draw(Graphics g)
        {
            SolidBrush sBrush = new SolidBrush(FillColor);
            g.FillRectangle(sBrush, X, Y, Width, Height);
        }
        #endregion
    }
}
