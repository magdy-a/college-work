namespace IPClassLibrary.ImageClasses
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using IPClassLibrary.StaticClasses;

    /// <summary>
    /// PPM Class, Handles the Opening And Saving of .ppm Files
    /// </summary>
    public class PPM : HandleImage, ICloneable
    {
        #region Attributes

        /// <summary>
        /// Const Chars, for the sake of Globalization
        /// </summary>
        protected const char Separator = ' ', NewLineN = '\n', NewLineR = '\r', CommentedLine = '#';

        /// <summary>
        /// Const Strings, in the sake of Globaliztion
        /// </summary>
        protected const string PPMExtension = "ppm", PThree = "P3", PSix = "P6", Signature = "# Created By Photo Pro Labs";

        /// <summary>
        /// Const Bytes, in the Sake of Globalization
        /// </summary>
        protected const byte FileTypeCodeLength = 2, MaxColour = 255;

        /// <summary>
        /// Exception of PPM Image
        /// </summary>
        private static Exception ppmCorrupted = new Exception("PPM Image is corrupted");

        /// <summary>
        /// Bytes to read in one Seek
        /// </summary>
        private static int readBytesNumber;

        /// <summary>
        /// The Length was read in the Buffer
        /// </summary>
        private int lengthRead;

        /// <summary>
        /// FileStream to Read & Write Bytes in Files
        /// </summary>
        private FileStream fs;

        /// <summary>
        /// StreamReader to Read Strings in Files
        /// </summary>
        private StreamReader sr;

        /// <summary>
        /// StreamWriter to Write Strings in Files
        /// </summary>
        private StreamWriter sw;

        #endregion

        /// <summary>
        /// Initializes a new instance of the PPM class
        /// </summary>
        public PPM()
        {
        }

        #region Properties

        /// <summary>
        /// Gets The Extension of PPM Images
        /// </summary>
        public static string Extension_PPMFiles
        {
            get { return PPMExtension; }
        }

        /// <summary>
        /// Gets the Exception about PPM Files that are corrupted
        /// </summary>
        protected static Exception PPMCorrupted
        {
            get { return ppmCorrupted; }
        }

        /// <summary>
        /// Gets or sets Tmp LengthRead Object
        /// </summary>
        protected int LengthRead
        {
            get { return this.lengthRead; }
            set { this.lengthRead = value; }
        }

        /// <summary>
        /// Gets or sets the readBytesNumber / Seek Operation
        /// </summary>
        protected int BytesPerSeek
        {
            get { return readBytesNumber; }
            set { readBytesNumber = value; }
        }

        /// <summary>
        /// Gets or sets the FileStream Object
        /// </summary>
        protected FileStream FS
        {
            get { return this.fs; }
            set { this.fs = value; }
        }

        /// <summary>
        /// Gets or sets the StreamReader Object
        /// </summary>
        protected StreamReader SR
        {
            get { return this.sr; }
            set { this.sr = value; }
        }

        /// <summary>
        /// Gets or sets the StreamWriter Object
        /// </summary>
        protected StreamWriter SW
        {
            get { return this.sw; }
            set { this.sw = value; }
        }

        #endregion

        /// <summary>
        /// Opens the PPM Image
        /// </summary>
        /// <param name="filePath">FilePath of the Image</param>
        public override void OpenImage(string filePath)
        {
            TmpImage = new PPM();

            ((PPM)TmpImage).ReadType(filePath);

            switch (TmpImage.Type)
            {
                case ImageType.P3:
                    TmpImage = new P3();
                    break;
                case ImageType.P6:
                    TmpImage = new P6();
                    break;
                default:
                    return;
            }

            TmpImage.OpenImage(filePath);

            if (TmpImage.Type == ImageType.Corrupted)
            {
                return;
            }

            SetData(TmpImage);

            TmpImage = null;
        }

        /// <summary>
        /// Saves the PPM Image
        /// </summary>
        /// <param name="filePath">FilePath to save the Image to</param>
        public override void SaveImage(string filePath)
        {
            if (Type == ImageType.Corrupted)
            {
                return;
            }

            RenewSize();

            try
            {
                // Open the FileStream & StreamWriter
                this.fs = new FileStream(filePath, FileMode.OpenOrCreate);
                this.sw = new StreamWriter(this.fs);

                // Here I'll write the ImageProperties of all .ppm Images

                // Keep in mind that the Default newLine of your computer could be '\r\n'
                // So write the newLineN in the Write, stay away from the WriteLine Function

                // Write Type
                this.sw.Write(Type.ToString() + NewLineN);

                // Write Our Signature in a commented line
                this.sw.Write(Signature + NewLineN);

                // Write the Size of the Image
                this.sw.Write(Size.Width.ToString() + Separator + Size.Height.ToString() + NewLineN);

                // Write the MaxColour of any R, G Or B in Images
                this.sw.Write(MaxColour.ToString() + NewLineN);
            }
            catch (Exception ex)
            {
                Type = ImageType.Corrupted;

                Logger.LogException(ex);

                try
                {
                    // Close StreamWriter & FileStream
                    this.fs.Close();
                    this.sw.Close();
                }
                catch
                {
                }

                this.sw = null;
                this.fs = null;
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

        /// <summary>
        /// Reads the Type of the File, by reading the First two bytes of the File
        /// </summary>
        /// <param name="filePath">Path of the Image</param>
        /// <returns>Type of the Image</returns>
        private ImageType ReadType(string filePath)
        {
            try
            {
                // Open FileStream
                this.fs = new FileStream(filePath, FileMode.Open);

                // If File is not Complete
                if (this.fs.Length < FileTypeCodeLength)
                {
                    throw ppmCorrupted;
                }

                // Read the ImageType
                byte[] byteType = new byte[FileTypeCodeLength];
                this.fs.Read(byteType, 0, byteType.Length);

                string t = Encoding.ASCII.GetString(byteType).ToLower();

                // Check Image Type
                if (t == PThree.ToLower())
                {
                    Type = ImageType.P3;
                }
                else if (t == PSix.ToLower())
                {
                    Type = ImageType.P6;
                }
                else
                {
                    throw ppmCorrupted;
                }

                // Close the FileStream
                this.fs.Close();
            }
            catch (Exception ex)
            {
                Type = ImageType.Corrupted;

                Logger.LogException(ex);
            }

            this.fs = null;

            // Return the type you just read
            return Type;
        }        
    }
}
