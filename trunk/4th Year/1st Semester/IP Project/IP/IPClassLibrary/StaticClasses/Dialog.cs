namespace IPClassLibrary.StaticClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Static Form Functions
    /// </summary>
    public class Dialog
    {
        #region Attributes

        /// <summary>
        /// OpenFileDialog, to be assigned once
        /// </summary>
        private OpenFileDialog openFile;

        /// <summary>
        /// SaveFileDialog, to be assigned once
        /// </summary>
        private SaveFileDialog saveFile;

        /// <summary>
        /// The Type of the Image
        /// </summary>
        private ImageType type;

        /// <summary>
        /// The Extension of the Image
        /// </summary>
        private ImageExtension extension;

        #endregion

        /// <summary>
        /// Initializes a new instance of the FormFunctions class
        /// </summary>
        public Dialog()
        {
            // Create OpenFileDialog Object
            this.openFile = new OpenFileDialog();

            this.openFile.Title = "Open Image";

            this.openFile.Filter = "Images (*.ppm;*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.ico)|*.ppm;*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.ico|All Files (*.*)|*.*";

            // Create SaveFileDialog Object
            this.saveFile = new SaveFileDialog();

            this.saveFile.Title = "Save Image";

            this.saveFile.Filter = "p3 Files *.ppm|*.ppm|P6 Files *.ppm|*.ppm|Bitmap Files *.bmp|*.bmp|JPEG Files *.jpg,*.jpeg|*.jpg|GIF Files *.gif|*.gif|PNG Files *.png|*.png|Icons *.ico|*.ico|All Files *.*|*.*";
        }

        #region Properties

        /// <summary>
        /// Gets The Type of the Image
        /// </summary>
        public ImageType Type
        {
            get { return this.type; }
        }

        /// <summary>
        /// Gets The Extension of the Image
        /// </summary>
        public ImageExtension Extension
        {
            get { return this.extension; }
        }

        #endregion

        /// <summary>
        /// Show File Dialog to Open the File
        /// </summary>
        /// <returns>Path of the Chosen File</returns>
        public string Get_OpenFile_Path()
        {
            // If Not OK, return from Function
            if (this.openFile.ShowDialog() != DialogResult.OK)
            {
                return string.Empty;
            }

            return this.openFile.FileName;
        }

        /// <summary>
        /// Show Save Dialog to Save the File, with the Same Name & Extension
        /// </summary>
        /// <param name="name">Name of the File</param>
        /// <returns>File Path</returns>
        public string Get_SaveFile_Path(string name)
        {
            if (name == string.Empty)
            {
                return name;
            }

            // Set the Initial Name by the Original Abstract Name
            this.saveFile.FileName = System.IO.Path.GetFileNameWithoutExtension(name);

            if (this.saveFile.ShowDialog() != DialogResult.OK)
            {
                return string.Empty;
            }

            switch (this.saveFile.FilterIndex)
            {
                case 1:
                    this.type = ImageType.P3;
                    this.extension = ImageExtension.PPM;
                    break;
                case 2:
                    this.type = ImageType.P6;
                    this.extension = ImageExtension.PPM;
                    break;
                case 3:
                    this.type = ImageType.Bitmap;
                    this.extension = ImageExtension.BMP;
                    break;
                case 4:
                    this.type = ImageType.Bitmap;
                    this.extension = ImageExtension.JPG;
                    break;
                case 5:
                    this.type = ImageType.Bitmap;
                    this.extension = ImageExtension.GIF;
                    break;
                case 6:
                    this.type = ImageType.Bitmap;
                    this.extension = ImageExtension.PNG;
                    break;
                case 7:
                    this.type = ImageType.Bitmap;
                    this.extension = ImageExtension.ICO;
                    break;
                default:
                    this.type = ImageType.Bitmap;
                    this.extension = ImageExtension.PNG;
                    break;
            }

            // If FileName was Selected, return File Path
            return this.saveFile.FileName;
        }
    }
}