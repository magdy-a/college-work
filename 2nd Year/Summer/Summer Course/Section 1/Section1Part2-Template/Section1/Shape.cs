using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Section1
{
    abstract class Shape
    {
        public Color FillColor;
        public int X;
        public int Y;

        public abstract void Draw(Graphics g);
    }
}
