namespace IPClassLibrary.ImageClasses
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using IPClassLibrary.ImageClasses;
    using IPClassLibrary.ObjectTypes;
    using IPClassLibrary.StaticClasses;

    /// <summary>
    /// Handles any type of Images (Open & Save)
    /// </summary>
    public class HandleImage : ICloneable
    {
        #region Attributes

        /// <summary>
        /// Type of the Image
        /// </summary>
        private ImageType itype;

        /// <summary>
        /// Extension of the Image
        /// </summary>
        private ImageExtension iextension;

        /// <summary>
        /// Path of the Image
        /// </summary>
        private string ipath;

        /// <summary>
        /// Size of the File
        /// </summary>
        private Size isize;

        /// <summary>
        /// ByteMap is the buffer to make changes in, save, cause of easy Acess
        /// </summary>
        private MyColor[,] ibyteMap;

        /// <summary>
        /// Bitmap of the buffer, to Represent of Form
        /// </summary>
        private Bitmap ibitMap;

        /// <summary>
        /// Tmp Objects to Loop Pixels
        /// </summary>
        private int tmpXAxis, tmpYAxis;

        /// <summary>
        /// TmpObject of HandleClass
        /// </summary>
        private HandleImage tmpImage;

        #endregion

        /// <summary>
        /// Initializes a new instance of the HandleImage class
        /// </summary>
        public HandleImage()
        {
        }

        #region Properties

        /// <summary>
        /// Gets or sets Type of the Image
        /// </summary>
        public ImageType Type
        {
            get { return this.itype; }
            protected set { this.itype = value; }
        }

        /// <summary>
        /// Gets or sets Path of the Image
        /// </summary>
        public string Path
        {
            get { return this.ipath; }
            protected set { this.ipath = value; }
        }

        /// <summary>
        /// Gets Name of the Image
        /// </summary>
        public string Name
        {
            get { return System.IO.Path.GetFileName(this.ipath); }
        }

        /// <summary>
        /// Gets Extension of the Image
        /// </summary>
        public string Extension
        {
            get { return System.IO.Path.GetExtension(this.ipath); }
        }

        /// <summary>
        /// Gets or sets Size of the File
        /// </summary>
        public Size Size
        {
            get { return this.isize; }
            protected set { this.isize = value; }
        }

        /// <summary>
        /// Gets or sets the Bytemap of this Object, You should renew the Bitmap after changing in the ByteMap
        /// </summary>
        public MyColor[,] ByteMap
        {
            get
            {
                return this.ibyteMap;
            }

            set
            {
                this.ibyteMap = value;
                this.RenewSize();
            }
        }

        /// <summary>
        /// Gets or sets Bitmap of the buffer, to Represent on Form
        /// </summary>
        public Bitmap BitMap
        {
            get { return this.ibitMap; }
            protected set { this.ibitMap = value; }
        }

        /// <summary>
        /// Gets or sets a tmp Int which is used to track Pixels in Images in X dir
        /// </summary>
        protected int TmpXAxis
        {
            get { return this.tmpXAxis; }
            set { this.tmpXAxis = value; }
        }

        /// <summary>
        /// Gets or sets a tmp Int which is used to track Pixels in Images in Y dir
        /// </summary>
        protected int TmpYAxis
        {
            get { return this.tmpYAxis; }
            set { this.tmpYAxis = value; }
        }

        /// <summary>
        /// Gets or sets a tmp Image which used in Opening Image
        /// </summary>
        protected HandleImage TmpImage
        {
            get { return this.tmpImage; }
            set { this.tmpImage = value; }
        }

        #endregion

        /// <summary>
        /// Opens any type of Images
        /// </summary>
        /// <param name="filePath">Path of the Image</param>
        public virtual void OpenImage(string filePath)
        {
            // Set the Extension of this Object
            this.SetExtension(filePath);

            // If PPM File
            if (this.iextension == ImageExtension.PPM)
            {
                this.tmpImage = new PPM();
            }
            else
            {
                this.tmpImage = new BitmapImage();
            }

            // Open Image
            this.tmpImage.OpenImage(filePath);

            // Check if the Open Image Failed
            if (this.tmpImage.itype == ImageType.Corrupted)
            {
                this.itype = ImageType.Corrupted;

                return;
            }

            // If Opened Image was Valid, setData to this Object
            this.SetData(this.tmpImage);

            this.tmpImage = null;
        }

        /// <summary>
        /// Save the Image with the Type to save with
        /// </summary>
        /// <param name="filePath">Path of the File to save</param>
        /// <param name="type">Type to save to</param>
        public void Save(string filePath, ImageType type)
        {
            if (filePath == string.Empty || this.itype == ImageType.Corrupted)
            {
                return;
            }

            this.RenewSize();

            switch (type)
            {
                case ImageType.P3:
                    this.tmpImage = new P3();
                    break;
                case ImageType.P6:
                    this.tmpImage = new P6();
                    break;
                case ImageType.Bitmap:
                    this.tmpImage = new BitmapImage();
                    break;
            }

            this.tmpImage.SetData(this);

            this.tmpImage.itype = type;

            this.tmpImage.SaveImage(filePath);

            this.tmpImage = null;
        }

        /// <summary>
        /// Saves any type of Images
        /// </summary>
        /// <param name="filePath">FilePath to save the Image to</param>
        public virtual void SaveImage(string filePath)
        {
        }

        /// <summary>
        /// Generates a new BitMap, according to the ByteMap
        /// </summary>
        public void RenewBitmap()
        {
            this.RenewSize();

            try
            {
                this.ibitMap = new Bitmap(this.isize.Width, this.isize.Height);

                for (int j = 0; j < this.isize.Height; j++)
                {
                    for (int i = 0; i < this.isize.Width; i++)
                    {
                        this.ibitMap.SetPixel(i, j, this.ibyteMap[i, j].GetColor());
                    }
                }
            }
            catch (Exception ex)
            {
                this.Type = ImageType.Corrupted;

                Logger.LogException(ex);
            }
        }

        /// <summary>
        /// Returns a Shallow Copy of this Object
        /// </summary>
        /// <returns>Shallow Copy</returns>
        public virtual object Clone()
        {
            HandleImage newObject = (HandleImage)this.MemberwiseClone();

            return newObject;
        }

        /// <summary>
        /// Set the Data from an Image to another
        /// </summary>
        /// <param name="handleImage">Image to Copy From</param>
        protected void SetData(HandleImage handleImage)
        {
            // Set FilePath
            this.ipath = handleImage.ipath;

            // Set Type
            this.itype = handleImage.itype;

            // Set Size
            this.isize = handleImage.isize;

            // Set ByteArr & Bitmap
            this.ibyteMap = handleImage.ibyteMap;
            this.ibitMap = handleImage.ibitMap;
        }

        /// <summary>
        /// ReGenerates the Size according to the ByteMap
        /// </summary>
        protected void RenewSize()
        {
            if (this.ibyteMap == null)
            {
                return;
            }

            if (this.isize == null)
            {
                this.isize = new Size();
            }

            this.isize.Width = this.ibyteMap.GetLength(0);
            this.isize.Height = this.ibyteMap.GetLength(1);
        }

        /// <summary>
        /// Sets the Extension & Type of the Image
        /// </summary>
        /// <param name="filePath">Path of the File</param>
        private void SetExtension(string filePath)
        {
            filePath = System.IO.Path.GetExtension(filePath);
            filePath = filePath.Remove(0, 1);

            if (filePath.Equals(ImageExtension.PPM.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                this.iextension = ImageExtension.PPM;
            }
            else if (filePath.Equals(ImageExtension.BMP.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                this.iextension = ImageExtension.BMP;
            }
            else if (filePath.Equals(ImageExtension.JPG.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                this.iextension = ImageExtension.JPG;
            }
            else if (filePath.Equals(ImageExtension.JPEG.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                this.iextension = ImageExtension.JPEG;
            }
            else if (filePath.Equals(ImageExtension.GIF.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                this.iextension = ImageExtension.GIF;
            }
            else if (filePath.Equals(ImageExtension.PNG.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                this.iextension = ImageExtension.PNG;
            }
            else
            {
                this.iextension = ImageExtension.ICO;
            }
        }
    }
}
