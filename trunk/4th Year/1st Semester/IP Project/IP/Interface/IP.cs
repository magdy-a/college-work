namespace PhotoLab
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using IPClassLibrary.Forms;
    using IPClassLibrary.ImageClasses;
    using IPClassLibrary.ResizeClasses;
    using IPClassLibrary.StaticClasses;

    /// <summary>
    /// BilinearResize Form
    /// </summary>
    public partial class IPForm : Form
    {
        #region Attributes

        /// <summary>
        /// Resize Handler
        /// </summary>
        private HandleResize main;

        /// <summary>
        /// Object of FormFunctions
        /// </summary>
        private Dialog frmFunctions;

        /// <summary>
        /// A tmp Form
        /// </summary>
        private HandlePictureBox tmpForm;

        /// <summary>
        /// A Tmp Object of the NewSize of the Image
        /// </summary>
        private Size newSize;

        #endregion

        /// <summary>
        /// Initializes a new instance of the IPForm class
        /// </summary>
        public IPForm()
        {
            this.InitializeComponent();

            this.main = new HandleResize();

            this.frmFunctions = new Dialog();

            StartPosition = FormStartPosition.CenterScreen;

            this.cmbResizeType.Items.AddRange(Enum.GetNames(typeof(ResizeType)));

            this.cmbResizeType.SelectedIndex = 0;

            MdiChildActivate += new EventHandler(this.IPForm_MdiChildActivate);

            // Test
            //HandlePictureBox HPB = new HandlePictureBox("Test Form");
            //HPB.OpenImage(@"C:\Users\Ahmad\Desktop\267608_10150262132668970_505313969_7725208_430355_n.jpg");
            //HPB.MdiParent = this;
            //HPB.Show();
        }

        /// <summary>
        /// Opening an Image
        /// </summary>
        /// <param name="sender">Sender to this Function</param>
        /// <param name="e">The EventArguments to use</param>
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            // Open My Image
            string fileName = this.frmFunctions.Get_OpenFile_Path();

            if (fileName == string.Empty)
            {
                return;
            }

            this.OpenMyImage(fileName);
        }

        /// <summary>
        /// Opens an Image and Handle it's apperance on the form
        /// </summary>
        /// <param name="filePath">Path of the Image</param>
        private void OpenMyImage(string filePath)
        {
            HandlePictureBox hpd = new HandlePictureBox(filePath + ":Original");
            hpd.MdiParent = this;

            if (hpd.Image == null)
            {
                hpd.Image = new HandleImage();
            }

            hpd.BringToFront();
            
            hpd.OpenImage(filePath);

            if (hpd.Image.Type == ImageType.Corrupted)
            {
                this.CheckForException();

                return;
            }

            hpd.Show();

            this.IPForm_MdiChildActivate(null, null);

            this.txtNewWidth.Text = this.main.Original.Size.Width.ToString();
            this.txtNewHeight.Text = this.main.Original.Size.Height.ToString();

            this.CheckForException();
        }

        /// <summary>
        /// Start Resizing
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The EventArguments to use</param>
        private void BtnResize_Click(object sender, EventArgs e)
        {
            if (this.main == null)
            {
                this.main = new HandleResize();
            }

            this.tmpForm = (HandlePictureBox)this.ActiveMdiChild;

            if (this.tmpForm == null || this.tmpForm.IsDisposed)
            {
                return;
            }

            this.main.Original = this.tmpForm.Image;

            try
            {
                this.newSize = new Size(int.Parse(this.txtNewWidth.Text), int.Parse(this.txtNewHeight.Text));

                if (this.newSize.Width <= 0 || this.newSize.Height <= 0)
                {
                    MessageBox.Show("You Should Enter Positive Parameters");

                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);

                return;
            }

            this.main.Resize(new Size(this.newSize.Width, this.newSize.Height), (ResizeType)this.cmbResizeType.SelectedIndex);

            if (this.main.Resized == null || this.main.Resized.Type == ImageType.Corrupted)
            {
                this.CheckForException();

                return;
            }

            this.tmpForm = new HandlePictureBox(Path.GetFileName(this.main.Original.Path) + ":Resized");
            this.tmpForm.MdiParent = this;

            this.tmpForm.UpdateImage(this.main.Resized);

            this.tmpForm.Show();

            this.IPForm_MdiChildActivate(null, null);

            this.CheckForException();
        }

        /// <summary>
        /// Saves the Original Image
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The EventArguments to use</param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.tmpForm = (HandlePictureBox)this.ActiveMdiChild;

            if (this.tmpForm == null || this.tmpForm.IsDisposed)
            {
                return;
            }

            this.tmpForm.Image.Save(this.frmFunctions.Get_SaveFile_Path(this.main.Original.Name), this.frmFunctions.Type);

            if (this.tmpForm == null || this.tmpForm.Image.Type == ImageType.Corrupted)
            {
                this.CheckForException();

                return;
            }

            this.CheckForException();
        }

        #region Events

        /// <summary>
        /// Resizes the Image
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The EventArguments to use</param>
        private void IPForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BtnResize_Click(null, null);
            }
        }

        /// <summary>
        /// Prepares for DragDrop
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The DragEventArguments to use</param>
        private void IPForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        /// <summary>
        /// Receive Droped Files
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The DragEventArguments to uset</param>
        private void IPForm_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string s in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                this.OpenMyImage(s);
            }
        }

        /// <summary>
        /// MDI Child Activated
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">Then Event</param>
        private void IPForm_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                this.lblOriginalSize.Text = string.Empty;
                return;
            }

            if (this.ActiveMdiChild.IsDisposed == false)
            {
                this.lblOriginalSize.Text = this.ActiveMdiChild.Text;
            }

            this.lblErrorMessage.Text = string.Empty;
        }

        /// <summary>
        /// Show the Exception (is exists) on the Form
        /// </summary>
        private void CheckForException()
        {
            if (Logger.IsNewException)
            {
                this.lblErrorMessage.Text = Logger.Exception.Message;
            }
        }

        #endregion
    }
}
