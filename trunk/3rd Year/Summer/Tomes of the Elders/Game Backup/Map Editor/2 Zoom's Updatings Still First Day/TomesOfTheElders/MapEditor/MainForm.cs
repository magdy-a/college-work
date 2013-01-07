using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class MainForm : Form
    {
        #region Members
        SpriteSheetMaker spriteSheetMaker;
        int spritesCount;
        Point FromTile, ToTile;
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            spriteSheetMaker = new SpriteSheetMaker();
            pictureBox.Image = spriteSheetMaker.Bitmap;
            spritesCount = 0;
        }
        #endregion

        #region Sheet Wide Events
        private void CreateNewSheetBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear existing sheet?", "Create New Sheet", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                spriteSheetMaker.ClearAll();
                pictureBox.Image = spriteSheetMaker.Bitmap;
                spritesCount = 0;
                toolStripLabel.Text = "Created New Sheet";
            }
        }
        private void OpenSheetBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Overwrite existing sheet?", "Open Sheet", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap newSheet = new Bitmap(dialog.FileName);
                    if (newSheet.Width != 320 || newSheet.Height != 320)
                    {
                        MessageBox.Show("Sheet Dimensions are not correct!");
                    }
                    else
                    {
                        pictureBox.Image = newSheet; ;
                        spritesCount = spriteSheetMaker.LoadSheet(newSheet);
                        toolStripLabel.Text = "Opened Existing Sheet";
                    }
                }
            }
        }
        private void SaveSheetBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = dialog.FileName;
                if (filepath.Split('.').Length == 1)
                    filepath += ".png";

                spriteSheetMaker.Bitmap.Save(filepath);
                toolStripLabel.Text = "Saved Sheet to File";
            }
        }
        #endregion

        #region Sprite Specific Methods
        private void AddNewSpriteBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap newSprite = new Bitmap(dialog.FileName);
                if (newSprite.Width != 32 || newSprite.Height != 32)
                {
                    MessageBox.Show("Sprite Dimensions are not correct!");
                }
                else if (spritesCount == 100)
                {
                    MessageBox.Show("Sprite sheet is full!");
                }
                else
                {
                    spriteSheetMaker.AddSprite(newSprite);
                    pictureBox.Image = spriteSheetMaker.Bitmap;
                    spritesCount++;
                    toolStripLabel.Text = "Added new Sprite";
                }
            }
        }
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int X = e.X / 32;
                int Y = e.Y / 32;
                if (spritesCount == 0 || Y * 10 + X >= spritesCount)
                {
                    MessageBox.Show("Not a valid Sprite!");
                }
                else if (MessageBox.Show("Delete sprite at X=" + X + ",Y=" + Y + " ?", "Delete Sprite", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    spriteSheetMaker.DeleteSprite(X, Y);
                    pictureBox.Image = spriteSheetMaker.Bitmap;
                    spritesCount--;
                    toolStripLabel.Text = "Deleted the Sprite";
                }
            }
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FromTile = new Point(e.X - e.X % 32, e.Y - e.Y % 32);
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToTile = new Point(e.X - e.X % 32, e.Y - e.Y % 32);
                if (FromTile.X / 32 + FromTile.Y * 10 / 32 >= spritesCount ||
                    ToTile.X / 32 + ToTile.Y * 10 / 32 >= spritesCount)
                {
                    MessageBox.Show("Invalid Swapping Positions!");
                }
                else
                {
                    spriteSheetMaker.ExchangeTiles(FromTile, ToTile);
                    pictureBox.Image = spriteSheetMaker.Bitmap;
                    toolStripLabel.Text = "Exchanged the Sprites";
                }
            }
        }
        #endregion
    }
}