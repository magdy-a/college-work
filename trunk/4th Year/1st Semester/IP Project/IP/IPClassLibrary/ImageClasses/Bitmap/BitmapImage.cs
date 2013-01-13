namespace IPClassLibrary.ImageClasses
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using IPClassLibrary.ObjectTypes;
    using IPClassLibrary.StaticClasses;

    /// <summary>
    /// Regular Image Class, Opens & Saves Regular Images
    /// </summary>
    internal class BitmapImage : HandleImage, ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the BitmapImage class
        /// </summary>
        public BitmapImage()
        {
        }

        /// <summary>
        /// Opens Regular Images
        /// </summary>
        /// <param name="filePath">Path of the Image</param>
        public override void OpenImage(string filePath)
        {
            // Set Type
            Type = ImageType.Bitmap;

            // Set Path
            Path = filePath;

            try
            {
                // Initialize Bitmap, with the ImagePath
                BitMap = new Bitmap(filePath);

                // Set Image Size
                Size = new Size(BitMap.Width, BitMap.Height);

                // Initialize Bytemap
                ByteMap = new MyColor[BitMap.Width, BitMap.Height];

                // Set Values of Bytemap
                for (int j = 0; j < Size.Height; j++)
                {
                    for (int i = 0; i < Size.Width; i++)
                    {
                        ByteMap[i, j].SetColor(BitMap.GetPixel(i, j));
                    }
                }
            }
            catch (Exception ex)
            {
                Type = ImageType.Corrupted;

                Logger.LogException(ex);
            }
        }

        /// <summary>
        /// Saves the Regular Images
        /// </summary>
        /// <param name="filePath">Path of the Image</param>
        public override void SaveImage(string filePath)
        {
            if (Type == ImageType.Corrupted)
            {
                return;
            }

            RenewSize();

            try
            {
                BitMap.Save(filePath);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        /// <summary>
        /// Returns a Shallow Copy of this Object
        /// </summary>
        /// <returns>Shallow Copy</returns>
        public override object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
