namespace IPClassLibrary.ImageClasses
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using IPClassLibrary.ObjectTypes;
    using IPClassLibrary.StaticClasses;

    /// <summary>
    /// P6 Class, is Specialized in Opening & Saving PPM with the Encoding P6
    /// </summary>
    public class P6 : PPM, ICloneable
    {
        /// <summary>
        /// Byte Array to Read the Bytes of the file in
        /// </summary>
        private byte[] image;

        /// <summary>
        /// Initializes a new instance of the P6 class
        /// </summary>
        public P6()
        {
        }

        #region Properties

        /// <summary>
        /// Gets or sets Byte Array to Read the Bytes of the file in
        /// </summary>
        protected byte[] Image
        {
            get { return this.image; }
            set { this.image = value; }
        }

        #endregion

        /// <summary>
        /// Opens the PPM Image
        /// </summary>
        /// <param name="filePath">FilePath of the Image</param>
        public override void OpenImage(string filePath)
        {
            // Set ImageType
            Type = ImageType.P6;

            // Set Path
            Path = filePath;

            BytesPerSeek = 48999;

            // Counter to know the location of the first pixel in the File
            int startPosition_File = 0;

            // Indicator of the NewLineChar length used in the file
            int lengthOfNewLineChar = NewLineN.ToString().Length;

            string tmpString;
            string[] tokens;

            try
            {
                // Open FileStream
                FS = new FileStream(filePath, FileMode.Open);

                // The DeSRiption of the Problem:
                //     In P6 I use FS to read the File, so I should know exactly the Position of the first Byte of the File
                //     Here it comes, In saving the File, the "NEWLINE" depends on the Computer or The version of VS, I don't care, but it might be '\n' or it might be "\r\n" ... '\n' is 10 '\r' is 13
                //     So I look at the 3rd Byte, if it is a '\n' or '\r' to be 1 or 2 byte(s) for the "NEWLINE"

                // Test the NewLine Char
                // Create the ByteArr file to Length 1
                this.image = new byte[1]; // Reading just One Byte

                // Set the Position to the FirstNewLineChar, just after the fileTypeCodeLength("P3 || P6") so it would be 2 (counting from 0)
                FS.Position = FileTypeCodeLength; // Counting from Zero

                // Read the Byte
                FS.Read(this.image, 0, 1);

                // If that Byte which is supposed to be the New Line Char isn't '\n' so it is "\r\n" with 2 bytes to "NEWLINE"
                if (this.image[0] != (byte)'\n')
                {
                    lengthOfNewLineChar = 2;
                }

                // Reset the Position to ZERO
                FS.Position = 0;

                // Create an instance of StreamReader
                SR = new StreamReader(FS);

                // Read ImageCode(Type) & Increase it's Length in bytes to that counter
                startPosition_File += SR.ReadLine().Length + lengthOfNewLineChar;

                // Read Next Line & Increase Length of Bytes to counter
                tmpString = SR.ReadLine();
                startPosition_File += tmpString.Length + lengthOfNewLineChar;

                // If Last Line was commentedLine
                if (tmpString[0] == CommentedLine)
                {
                    // Read Size instead, & Increase counter
                    tmpString = SR.ReadLine();
                    startPosition_File += tmpString.Length + lengthOfNewLineChar;
                }

                // Set Size, with the tmpString, I am sure now it is the String with the Size of the Image
                tokens = tmpString.Split(Separator);

                // Extract the Size
                Size = new Size(int.Parse(tokens[0]), int.Parse(tokens[1]));

                // If file is not Complete
                if (FS.Length < Size.Width * Size.Height * 3)
                {
                    // Why *3: 3 for r, g and b
                    throw PPMCorrupted;
                }

                // Read MaxColour & Increase counter
                startPosition_File += SR.ReadLine().Length + lengthOfNewLineChar;

                // Set the StartPosition of the FirstPixel in the Image
                FS.Position = startPosition_File;

                // Create Byte Array
                this.image = new byte[BytesPerSeek];

                // Create the ByteMap, Bitmap
                ByteMap = new MyColor[Size.Width, Size.Height];
                BitMap = new Bitmap(Size.Width, Size.Height);

                // Reset the Tmp Coordinates
                TmpXAxis = TmpXAxis = 0;

                int i;

                while (FS.Position != FS.Length)
                {
                    // Read the Image
                    LengthRead = FS.Read(this.image, 0, this.image.Length);

                    // Set Image
                    for (i = 0; i < LengthRead;)
                    {
                        // Set R, G, B in ByteMap
                        ByteMap[TmpXAxis, TmpYAxis].SetColor(this.image[i++], this.image[i++], this.image[i++]);

                        // Set R, G, B in BitMap
                        BitMap.SetPixel(TmpXAxis, TmpYAxis, ByteMap[TmpXAxis, TmpYAxis].GetColor());

                        // If Line is Done, SWitch To Next Line
                        if (++TmpXAxis % Size.Width == 0)
                        {
                            TmpXAxis = 0;
                            TmpYAxis++;
                        }
                    }
                }

                // Close the StreamReader & FileStream
                SR.Close();
                FS.Close();

                // Delete the Array used to read from the file
                this.image = null;
            }
            catch (Exception ex)
            {
                Type = ImageType.Corrupted;

                Logger.LogException(ex);
            }

            SR = null;
            FS = null;

            this.image = null;

            // Collect Garbage
            GarbageCollector.CollectGarbage();
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

            // Save the data related the .ppm regardless it is Type
            base.SaveImage(filePath);

            if (Type == ImageType.Corrupted)
            {
                return;
            }

            try
            {
                // Flush the Data to the File
                SW.Flush();

                // Write Every Pixel to the File
                for (int j = 0; j < Size.Height; j++)
                {
                    for (int i = 0; i < Size.Width; i++)
                    {
                        FS.Write(new byte[] { ByteMap[i, j].R, ByteMap[i, j].G, ByteMap[i, j].B }, 0, 3);
                    }
                }

                SW.Close();
                FS.Close();
            }
            catch (Exception ex)
            {
                Type = ImageType.Corrupted;

                Logger.LogException(ex);
            }

            try
            {
                // Close StreamWriter & FileStream
                SW = null;
                FS = null;
            }
            catch
            {
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