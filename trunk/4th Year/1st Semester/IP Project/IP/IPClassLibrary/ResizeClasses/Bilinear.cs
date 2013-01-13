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
    /// Bilinear Class
    /// </summary>
    public class Bilinear : HandleResize, ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the Bilinear class
        /// </summary>
        public Bilinear()
        {
        }

        /// <summary>
        /// Resizes the image using BilinearResize
        /// </summary>
        /// <param name="newSize">Size of the new Image</param>
        public override void ResizeImage(Size newSize)
        {
            try
            {
                Resized = (HandleImage)Original.Clone();

                this.Resized.ByteMap = new MyColor[newSize.Width, newSize.Height];

                float oldX, oldY,
                    wratio, hratio,
                    xfraction, yfraction,
                    z1, z2;

                int x1, x2, y1, y2;

                MyColor p1, p2, p3, p4,
                    newPixel = new MyColor();

                wratio = (float)Original.Size.Width / newSize.Width;
                hratio = (float)Original.Size.Height / newSize.Height;

                for (int newX = 0; newX < newSize.Width; newX++)
                {
                    for (int newY = 0; newY < newSize.Height; newY++)
                    {
                        oldX = newX * wratio;
                        oldY = newY * hratio;

                        x2 = (x1 = (int)Math.Floor(oldX)) + 1;

                        y2 = (y1 = (int)Math.Floor(oldY)) + 1;

                        if (x2 == Original.Size.Width)
                        {
                            x2--;
                        }

                        if (y2 == Original.Size.Height)
                        {
                            y2--;
                        }

                        p1 = Original.ByteMap[x1, y1];
                        p2 = Original.ByteMap[x2, y1];
                        p3 = Original.ByteMap[x1, y2];
                        p4 = Original.ByteMap[x2, y2];

                        xfraction = oldX - x1;
                        yfraction = oldY - y1;

                        z1 = (float)((p1.R * (1 - xfraction)) + (p2.R * xfraction));
                        z2 = (float)((p3.R * (1 - xfraction)) + (p4.R * xfraction));
                        newPixel.R = (byte)((z1 * (1 - yfraction)) + (z2 * yfraction));

                        z1 = (float)((p1.G * (1 - xfraction)) + (p2.G * xfraction));
                        z2 = (float)((p3.G * (1 - xfraction)) + (p4.G * xfraction));
                        newPixel.G = (byte)((z1 * (1 - yfraction)) + (z2 * yfraction));

                        z1 = (float)((p1.B * (1 - xfraction)) + (p2.B * xfraction));
                        z2 = (float)((p3.B * (1 - xfraction)) + (p4.B * xfraction));
                        newPixel.B = (byte)((z1 * (1 - yfraction)) + (z2 * yfraction));

                        Resized.ByteMap[newX, newY] = newPixel;
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
        /// Creats a Shallow Copy of this Object
        /// </summary>
        /// <returns>Shallow Copy</returns>
        public override object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
