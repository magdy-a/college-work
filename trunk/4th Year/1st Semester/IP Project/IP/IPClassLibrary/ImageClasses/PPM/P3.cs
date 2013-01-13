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
    /// P3 Class, is Specialized in Opening & Saving PPM with the Encoding P3
    /// </summary>
    public class P3 : PPM, ICloneable
    {
        /// <summary>
        /// String Array to Split Strings
        /// </summary>
        private List<string> tokens;

        /// <summary>
        /// Char Array to read file with
        /// </summary>
        private char[] buffer;

        /// <summary>
        /// BigBuffer to accumulate the reading buffer in it
        /// </summary>
        private List<char> bigBuffer;

        /// <summary>
        /// Initializes a new instance of the P3 class
        /// </summary>
        public P3()
        {
        }

        #region Properties

        /// <summary>
        /// Gets or sets String Array to Split Strings
        /// </summary>
        protected List<string> Tokens
        {
            get { return this.tokens; }
            set { this.tokens = value; }
        }

        #endregion

        /// <summary>
        /// Opens the PPM Image
        /// </summary>
        /// <param name="filePath">FilePath of the Image</param>
        public override void OpenImage(string filePath)
        {
            // Set ImageType
            Type = ImageType.P3;

            // Set Path
            Path = filePath;

            BytesPerSeek = 50000;

            try
            {
                // Open FileStream & StreamReader
                FS = new FileStream(Path, FileMode.Open);
                SR = new StreamReader(FS);

                // Neglect the Type
                SR.ReadLine();

                // Read NextLine
                this.tokens = SR.ReadLine().Split(Separator).ToList();

                // If the Line was a Comment, Neglect it and read the Size
                if (this.tokens[0] == CommentedLine.ToString())
                {
                    this.tokens = SR.ReadLine().Split(Separator).ToList();
                }

                // Set Image Size
                Size = new Size(int.Parse(this.tokens[0]), int.Parse(this.tokens[1]));

                // If file is not Complete
                if (FS.Length < Size.Width * Size.Height * 6)
                {
                    // Why *6: 3 for r, g and b, and 2 for at least one char in the value, and the Space Or NewLine
                    throw PPMCorrupted;
                }

                // Neglect the MaxColour
                SR.ReadLine();

                // Reset the Tmp Coordinates
                TmpXAxis = TmpYAxis = 0;

                this.buffer = new char[BytesPerSeek];
                this.bigBuffer = new List<char>();
                this.tokens = new List<string>();

                // Create the ByteMap & Bitmap
                ByteMap = new MyColor[Size.Width, Size.Height];
                BitMap = new Bitmap(Size.Width, Size.Height);

                int i;

                while (SR.Peek() != -1)
                {
                    LengthRead = SR.Read(this.buffer, 0, this.buffer.Length);

                    if (LengthRead == 0)
                    {
                        break;
                    }

                    this.bigBuffer.AddRange(this.buffer.Take(LengthRead));

                    LengthRead = this.bigBuffer.Count;

                    while (this.bigBuffer[--LengthRead] != Separator && this.bigBuffer[LengthRead] != NewLineN && this.bigBuffer[LengthRead] != NewLineR)
                    {
                    }

                    this.tokens.AddRange(new string(this.bigBuffer.ToArray(), 0, LengthRead + 1).Split(new char[] { Separator, NewLineN, NewLineR }, StringSplitOptions.RemoveEmptyEntries));
                    this.bigBuffer.RemoveRange(0, LengthRead + 1);

                    // Set Image
                    for (i = 0; i < this.tokens.Count;)
                    {
                        if (this.tokens.Count - i < 3)
                        {
                            break;
                        }

                        // Set R, G, B in the ByteMap
                        ByteMap[TmpXAxis, TmpYAxis].SetColor(byte.Parse(this.tokens[i++]), byte.Parse(this.tokens[i++]), byte.Parse(this.tokens[i++]));

                        // Set R, G, B in the BitMap
                        BitMap.SetPixel(TmpXAxis, TmpYAxis, ByteMap[TmpXAxis, TmpYAxis].GetColor());

                        // If Line is Done, SWitch To Next Line
                        if (++TmpXAxis % Size.Width == 0)
                        {
                            TmpXAxis = 0;
                            TmpYAxis++;
                        }
                    }

                    this.tokens.RemoveRange(0, i);
                }

                // Read Image in a string, then split it into Colors of each Pixel
                // this.tokens = SR.ReadToEnd().Split(new char[] { Separator, NewLineN }, StringSplitOptions.RemoveEmptyEntries).ToList();

                // Close the StreamReader & FileStream
                SR.Close();
                FS.Close();
            }
            catch (Exception ex)
            {
                this.Type = ImageType.Corrupted;

                Logger.LogException(ex);
            }

            // Remove Streams
            SR = null;
            FS = null;

            // Delete the StringArr & Buffers used to read the Image
            this.buffer = null;
            this.bigBuffer = null;
            this.tokens = null;

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
                this.SW.Flush();

                TmpXAxis = 0;

                // Write Every Pixel to the File
                for (int j = 0; j < this.Size.Height; j++)
                {
                    for (int i = 0; i < this.Size.Width; i++)
                    {
                        this.SW.Write(
                            this.ByteMap[i, j].R.ToString() + Separator.ToString() +
                            this.ByteMap[i, j].G.ToString() + Separator.ToString() +
                            this.ByteMap[i, j].B.ToString());

                        if (++TmpXAxis % 6 != 0)
                        {
                            this.SW.Write(Separator);
                        }
                        else
                        {
                            this.SW.Write(NewLineN);
                        }
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
