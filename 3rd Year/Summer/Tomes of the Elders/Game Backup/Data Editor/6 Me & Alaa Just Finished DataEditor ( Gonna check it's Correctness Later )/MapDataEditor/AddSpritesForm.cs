using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MapDataEditor.Data;

namespace MapDataEditor
{
    /// <summary>
    /// Form to view current items and add new ones.
    /// </summary>
    public partial class AddSpritesForm : Form
    {
        #region Data Members
        /// <summary>
        /// A pointer to the Main Form executed from.
        /// </summary>
        MainForm myParent;
        /// <summary>
        /// The item being added to the collection.
        /// </summary>
        ParentDataObject NewItem;
        /// <summary>
        /// Type of item being added to the collection.
        /// </summary>
        AdditionType myType;
        /// <summary>
        /// Class used for operating on the sprite sheet.
        /// </summary>
        SpriteSheetMaker spriteSheetMaker;
        /// <summary>
        /// From Tile used when exchanging tiles.
        /// </summary>
        Point FromTile;
        /// <summary>
        /// To Tile used when exchanging tiles.
        /// </summary>
        Point ToTile;
        /// <summary>
        /// True if help page is opened, false otherwise.
        /// </summary>
        bool HelpOpened = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the Add Sprites Form.
        /// </summary>
        /// <param name="myParent">A pointer to the Main Form executed from.</param>
        /// <param name="myType">Type of item being added to the collection.</param>
        /// <param name="NewItem">The item being added to the collection.</param>
        public AddSpritesForm(MainForm myParent, AdditionType myType, Data.ParentDataObject NewItem, Size SpriteSheetSize)
        {
            InitializeComponent();
            this.myParent = myParent;
            this.myType = myType;
            this.NewItem = NewItem;
            spriteSheetMaker = new SpriteSheetMaker(ref pictureBox, SpriteSheetSize.Height, SpriteSheetSize.Width);
        }
        #endregion

        #region Form Buttons
        /// <summary>
        /// Event executed when user presses the cancel button.
        /// </summary>
        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            myParent.Enabled = true;
            this.Dispose();
        }
        /// <summary>
        /// Event executed when user presses the add item button.
        /// </summary>
        private void AddItembutton_Click(object sender, EventArgs e)
        {
            if (spriteSheetMaker.SpritesCount == NewItem.Length)
            {
                myParent.CurrentProject.AddItem(NewItem, spriteSheetMaker);
                myParent.Enabled = true;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Invalid number of sprites entered.");
            }
        }
        /// <summary>
        /// Event executed when user presses the add sprites button.
        /// </summary>
        private void AddSpritesbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PNG Files (*.png)|*.png";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filepath in dialog.FileNames)
                {
                    Bitmap newSprite = new Bitmap(filepath);
                    if (newSprite.Width != spriteSheetMaker.SpriteSize.Width || newSprite.Height != spriteSheetMaker.SpriteSize.Height)
                    {
                        MessageBox.Show("Sprite Dimensions are not correct! Sprite is skipped.");
                    }
                    else if (spriteSheetMaker.SpritesCount == spriteSheetMaker.SheetSize.Height * spriteSheetMaker.SheetSize.Width)
                    {
                        MessageBox.Show("Sprite sheet is full!");
                        break;
                    }
                    else
                    {
                        spriteSheetMaker.AddSprite(newSprite);
                    }
                }
            }
        }
        /// <summary>
        /// Event executed when user presses the help button.
        /// </summary>
        private void Helpbutton_Click(object sender, EventArgs e)
        {
            if (HelpOpened)
            {
                this.Width = 345;
                Helpbutton.Text = "Show Help";
            }
            else
            {
                this.Width = 638;
                Helpbutton.Text = "Hide Help";
            }
            HelpOpened = !HelpOpened;
        }
        #endregion

        #region Picture Box Events
        /// <summary>
        /// Event executed when user clicks the picture box.
        /// </summary>
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int X = e.X / 32;
                int Y = e.Y / 32;
                if (spriteSheetMaker.SpritesCount == 0 || Y * 10 + X >= spriteSheetMaker.SpritesCount)
                {
                    MessageBox.Show("Not a valid Sprite!");
                }
                else if (MessageBox.Show("Delete sprite at X=" + X + ",Y=" + Y + " ?", "Delete Sprite", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    spriteSheetMaker.DeleteSprite(X, Y);
                }
            }
        }
        /// <summary>
        /// Event executed when user holds the mouse over the picture box.
        /// </summary>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FromTile = new Point(e.X - e.X % 32, e.Y - e.Y % 32);
            }
        }
        /// <summary>
        /// Event executed when user releases the mouse over the picture box.
        /// </summary>
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToTile = new Point(e.X - e.X % 32, e.Y - e.Y % 32);
                if (FromTile.X / 32 + FromTile.Y * 10 / 32 >= spriteSheetMaker.SpritesCount ||
                    ToTile.X / 32 + ToTile.Y * 10 / 32 >= spriteSheetMaker.SpritesCount)
                {
                    MessageBox.Show("Invalid Swapping Positions!");
                }
                else
                {
                    spriteSheetMaker.ExchangeTiles(FromTile, ToTile);
                }
            }
        }
        #endregion

        #region Form Events
        /// <summary>
        /// Event executed when the form closes.
        /// </summary>
        private void AddSpritesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myParent.Enabled = true;
            this.Dispose();
        }
        #endregion
    }
}
