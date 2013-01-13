namespace IPClassLibrary.ResizeClasses
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using IPClassLibrary.ImageClasses;
    using IPClassLibrary.ObjectTypes;
    using IPClassLibrary.StaticClasses;

    /// <summary>
    /// Bicubic Resize
    /// </summary>
    public class BiCubic : HandleResize, ICloneable
    {
        /// <summary>
        /// tmpMyColor Array
        /// </summary>
        private MyColor[] tmpMyColor;

        /// <summary>
        /// Initializes a new instance of the BiCubic class
        /// </summary>
        public BiCubic()
        {
            this.tmpMyColor = new MyColor[4]; 
        }

        /// <summary>
        /// Resizes the image using BiCubicResize
        /// </summary>
        /// <param name="newSize">Size of the new Image</param>
        public override void ResizeImage(Size newSize)
        {
            try
            {
                Resized = (HandleImage)Original.Clone();

                Resized.ByteMap = new MyColor[newSize.Width, newSize.Height];

                float wratio = (float)(Original.Size.Width - 1) / newSize.Width;
                float hratio = (float)(Original.Size.Height - 1) / newSize.Height;

                double oldX, oldY;
                int x1, y1, x2, y2;

                double xfraction, yfraction;
                MyColor newPixel;

                for (int i = 0; i < Resized.Size.Width; i++)
                {
                    for (int j = 0; j < Resized.Size.Height; j++)
                    {
                        oldX = (int)(i * wratio);
                        oldY = (int)(j * hratio);
                        x1 = (int)Math.Floor(oldX);
                        x2 = (int)(x1 + 1);
                        y1 = (int)Math.Floor(oldY);
                        y2 = (int)(y1 + 1);

                        this.tmpMyColor[0] = Original.ByteMap[x1, y1];
                        this.tmpMyColor[1] = Original.ByteMap[x2, y1];
                        this.tmpMyColor[2] = Original.ByteMap[x1, y2];
                        this.tmpMyColor[3] = Original.ByteMap[x2, y2];

                        xfraction = oldX - x1;
                        yfraction = oldY - y1;

                        newPixel = this.BiGetValue(this.tmpMyColor, xfraction, yfraction);

                        Resized.ByteMap[(int)i, (int)j] = newPixel;
                    }
                }

                Resized.RenewBitmap();
            }
            catch (Exception ex)
            {
                Resized = null;

                Logger.LogException(ex);
            }
        }

        /// <summary>
        /// Get the value with along with the MyColor p, and Double x
        /// </summary>
        /// <param name="p">Array of MyColor Object</param>
        /// <param name="x">Double 'x' the Value to Operate at</param>
        /// <returns>Value of this function</returns>
        public MyColor GetValue(MyColor[] p, double x)
        {
            MyColor w;
            w.R = (byte)(((2 * p[1].R) + (x * ((p[2].R - p[0].R) + (x * ((2.0 * p[0].R) - (5.0 * p[1].R) + (4.0 * p[2].R) - (p[3].R + (x * ((3.0 * (p[1].R - p[2].R)) + (p[3].R - p[0].R))))))))) / 2);
            w.G = (byte)(((2 * p[1].G) + (x * ((p[2].G - p[0].G) + (x * ((2.0 * p[0].G) - (5.0 * p[1].G) + (4.0 * p[2].G) - (p[3].G + (x * ((3.0 * (p[1].G - p[2].G)) + (p[3].G - p[0].G))))))))) / 2);
            w.B = (byte)(((2 * p[1].B) + (x * ((p[2].B - p[0].B) + (x * ((2.0 * p[0].B) - (5.0 * p[1].B) + (4.0 * p[2].B) - (p[3].B + (x * ((3.0 * (p[1].B - p[2].B)) + (p[3].B - p[0].B))))))))) / 2);
            return w;
        }

        /// <summary>
        /// Get the Bi_Value of the MyColor Object
        /// </summary>
        /// <param name="p">MyColor Object</param>
        /// <param name="x">Double Object x</param>
        /// <param name="y">Double Object y</param>
        /// <returns>The Value of the MyColor Object</returns>
        public MyColor BiGetValue(MyColor[] p, double x, double y)
        {
            p[0] = this.GetValue(p, y);
            p[1] = this.GetValue(p, y);
            p[2] = this.GetValue(p, y);
            p[3] = this.GetValue(p, y);

            return this.GetValue(p, x);
        }

        /// <summary>
        /// Creats a Shallow Copy of this Object
        /// </summary>
        /// <returns>Shallow Copy</returns>
        public override object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
