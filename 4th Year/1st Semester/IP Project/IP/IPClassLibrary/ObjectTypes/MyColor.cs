namespace IPClassLibrary.ObjectTypes
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 3 Bytes with Set And Get Function, Optimizing Space
    /// </summary>
    public struct MyColor
    {
        /// <summary>
        /// Byte R, means Red, range(0,255)
        /// </summary>
        public byte R;

        /// <summary>
        /// Byte G, means Green, range(0,255)
        /// </summary>
        public byte G;

        /// <summary>
        /// Byte B, means Blue, range(0,255)
        /// </summary>
        public byte B;

        /// <summary>
        /// Set Color with the 3 Bytes
        /// </summary>
        /// <param name="r">Byte Red Value</param>
        /// <param name="g">Byte Green Value</param>
        /// <param name="b">Byte Blue Value</param>
        public void SetColor(byte r, byte g, byte b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        /// <summary>
        /// Sets the Color with System.Color Object
        /// </summary>
        /// <param name="c">System.Color Object</param>
        public void SetColor(Color c)
        {
            this.R = (byte)c.R;
            this.G = (byte)c.G;
            this.B = (byte)c.B;
        }

        /// <summary>
        /// If you want a System Color
        /// </summary>
        /// <returns>Returns a System.Drawing.Color Object to be Used somewhere else</returns>
        public Color GetColor()
        {
            return Color.FromArgb((int)this.R, (int)this.G, (int)this.B);
        }
    }
}
