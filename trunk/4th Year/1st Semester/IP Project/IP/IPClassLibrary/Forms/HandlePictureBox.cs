namespace IPClassLibrary.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
using IPClassLibrary.ImageClasses;

    /// <summary>
    /// Handles the MDI PictureBox Form
    /// </summary>
    public partial class HandlePictureBox : Form
    {
        /// <summary>
        /// The Original Title of this Object
        /// </summary>
        private string originalText;

        /// <summary>
        /// The HandleImage Object
        /// </summary>
        private HandleImage myImage;

        /// <summary>
        /// The last Location for the Mouse, before Dragging
        /// </summary>
        private Point mouseDownLocation;

        /// <summary>
        /// The Move Happened with mouseDrag on the PictureBox
        /// </summary>
        private Point tmpAxisMove;

        private delegate void g();

        /// <summary>
        /// Initializes a new instance of the HandlePictureBox class
        /// </summary>
        /// <param name="title">Title of the Form</param>
        public HandlePictureBox(string title)
        {
            this.InitializeComponent();

            this.originalText = title;

            this.myImage = new HandleImage();

            this.pbMain.SizeMode = PictureBoxSizeMode.Normal;

            this.HandlePictureBox_SizeChanged(null, null);

            tmpAxisMove = new Point();


            //Bitmap b = new Bitmap(Image.BitMap);
            //b = b.GetThumbnailImage(50, 50, new g(functionfadya), IntPtr.Zero);

            //this.tlpMain.Controls.Container.ToString();
            ////this.tlpMain.BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\Ahmad\Desktop\267608_10150262132668970_505313969_7725208_430355_n.jpg");
            //this.tlpMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
        }

        private void functionfadya()
        {

        }

        /// <summary>
        /// Gets or sets the HandleImage Object of this form
        /// </summary>
        public HandleImage Image
        {
            get { return this.myImage; }
            set { this.myImage = value; }
        }

        /// <summary>
        /// Updates the Image of the Form with the Image in this filePath
        /// </summary>
        /// <param name="filePath">The FilePath of the File</param>
        public void OpenImage(string filePath)
        {
            if (filePath == string.Empty)
            {
                return;
            }

            this.myImage.OpenImage(filePath);

            // Bitmap x = (Bitmap) this.myImage.BitMap.GetThumbnailImage(100, 100, new Image.GetThumbnailImageAbort(blabla), System.IntPtr.Zero);

            if (this.myImage.Type == ImageType.Corrupted)
            {
                return;
            }

            AfterOpenOperations();
        }

        /// <summary>
        /// Updates the Image to the PictureBox, and it's corresponds
        /// </summary>
        /// <param name="newImage">The NewImage to set the Form with</param>
        public void UpdateImage(HandleImage newImage)
        {
            if (newImage == null)
            {
                return;
            }

            this.myImage = newImage;

            AfterOpenOperations();
        }

        private void AfterOpenOperations()
        {
            this.pbMain.Size = this.myImage.Size;

            this.pbMain.Image = this.myImage.BitMap;

            MaximumSize = new Size(this.myImage.Size.Width + (this.pnlMain.Location.X - Location.X) + ((Location.X + Width) - (this.pnlMain.Location.X + this.pnlMain.Width)), this.myImage.Size.Height + (this.pnlMain.Location.Y - Location.Y) + ((Location.Y + Height) - (this.pnlMain.Location.Y + this.pnlMain.Height)));

            this.pnlMain.BackColor = Color.Black;

            this.pnlMain.BringToFront();

            this.HandlePictureBox_SizeChanged(null, null);
        }

        /// <summary>
        /// Form Size Changed Event
        /// </summary>
        /// <param name="sender">The caller to this function</param>
        /// <param name="e">The EventArguments to use</param>
        private void HandlePictureBox_SizeChanged(object sender, EventArgs e)
        {
            if (this.pbMain.Image != null)
            {
                // Text = "(" + this.pbMain.Image.Width + ", " + this.pbMain.Image.Height + ")=>(" + this.pbMain.Size.Width + ", " + this.pbMain.Size.Height + ") " + this.pbMain.SizeMode.ToString() + "View as " + this.originalText;
                //Text = "(" + this.pbMain.Image.Width + ", " + this.pbMain.Image.Height + ")=>(" + this.pnlMain.Size.Width + ", " + this.pnlMain.Size.Height + ") " + this.originalText;
                this.pbMain.Location = this.pnlMain.Location;
            }
        }

        /// <summary>
        /// Mouse Enter Event
        /// </summary>
        /// <param name="sender">The caller to this function</param>
        /// <param name="e">The EventArguments to use</param>
        private void PbMain_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeAll;
        }

        /// <summary>
        /// Mouse Leave Event
        /// </summary>
        /// <param name="sender">The caller to this function</param>
        /// <param name="e">The EventArguments to use</param>
        private void pbMain_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Mouse Down Event
        /// </summary>
        /// <param name="sender">The Caller to this function</param>
        /// <param name="e">The MouseEventArguments to use</param>
        private void HandlePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLocation = e.Location;
        }

        /// <summary>
        /// Mouse Move Event
        /// </summary>
        /// <param name="sender">The Caller to this function</param>
        /// <param name="e">The MouseEventArguments to use</param>
        private void HandlePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            // Set Permissions to move in the four Directions
            // moveRight = (pbMain.Location.X < 0) ? true : false;
            // moveLeft = (pbMain.Location.X + pbMain.Width > pnlMain.Width) ? true : false;
            // moveUp = (pbMain.Location.Y + pbMain.Height > pnlMain.Height) ? true : false;
            // moveDown = (pbMain.Location.Y < 0) ? true : false;

            // Text = e.Location.X.ToString() + " " + e.Location.Y.ToString() + "..." + lastLocation.X.ToString() + " " + lastLocation.Y.ToString();

            tmpAxisMove.X = e.Location.X - mouseDownLocation.X;

            // Move according to the Permissions at X axis
            // Left
            if ((tmpAxisMove.X < 0) && (pbMain.Location.X + pbMain.Width > pnlMain.Width))
            {
                // If value to move will get the Image outside my bounds, normalize it
                if (Math.Abs(tmpAxisMove.X) > Math.Abs((pbMain.Location.X + pbMain.Width) - pnlMain.Width))
                {
                    tmpAxisMove.X = -1 * (pbMain.Location.X + pbMain.Width - pnlMain.Width);
                }
            } // Right
            else if ((tmpAxisMove.X > 0) && (pbMain.Location.X < 0))
            {
                // If value to move will get the Image outside my bounds, normalize it
                if (tmpAxisMove.X > Math.Abs(pbMain.Location.X))
                {
                    tmpAxisMove.X = pnlMain.Location.X - pbMain.Location.X;
                }
            }
            else
            {
                tmpAxisMove.X = 0;
            }

            tmpAxisMove.Y = e.Location.Y - mouseDownLocation.Y;

            // Move according to the Permissions at Y axis
            // Up
            if ((tmpAxisMove.Y < 0) && (pbMain.Location.Y + pbMain.Height > pnlMain.Height))
            {
                // If value to move will get the Image outside my bounds, normalize it
                if (Math.Abs(tmpAxisMove.Y) > (pbMain.Location.Y + pbMain.Height - pnlMain.Height))
                {
                    tmpAxisMove.Y = -1 * (pbMain.Location.Y + pbMain.Height - pnlMain.Height);
                }
            } // Down
            else if ((tmpAxisMove.Y > 0) && (pbMain.Location.Y < 0))
            {
                // If value to move will get the Image outside my bounds, normalize it
                if (tmpAxisMove.Y > Math.Abs(pbMain.Location.Y))
                {
                    tmpAxisMove.Y = pnlMain.Location.Y - pbMain.Location.Y;
                }
            }
            else
            {
                tmpAxisMove.Y = 0;
            }

            pbMain.Location = new Point(pbMain.Location.X + tmpAxisMove.X, pbMain.Location.Y + tmpAxisMove.Y);

            //pbMain.Update();
        }
    }
}
