using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Section4
{
    abstract class GDIShape
    {
        public abstract void Draw(Graphics g);
        public abstract void DrawForCreation(Graphics g);
    }
}
