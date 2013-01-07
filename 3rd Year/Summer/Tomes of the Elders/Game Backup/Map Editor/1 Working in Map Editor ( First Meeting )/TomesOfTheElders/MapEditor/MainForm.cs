using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class MainForm : Form
    {
        SpriteSheetMaker spriteSheetMaker;
        int spritesCount;

        public MainForm()
        {
            InitializeComponent();
            spriteSheetMaker = new SpriteSheetMaker();
            pictureBox.Image = spriteSheetMaker.Bitmap;
            spritesCount = 0;
        }

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
                        spriteSheetMaker.Bitmap = newSheet;
                        pictureBox.Image = newSheet; ;
                        spritesCount = 0;
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
            int X = e.X / 32;
            int Y = e.Y / 32;
            if (MessageBox.Show("Delete sprite at X=" + X + ",Y=" + Y + " ?", "Delete Sprite", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (spritesCount == 0 || Y * 10 + X >= spritesCount)
                {
                    MessageBox.Show("Not a valid Sprite!");
                }
                else
                {
                    spriteSheetMaker.DeleteSprite(X, Y);
                    pictureBox.Image = spriteSheetMaker.Bitmap;
                    spritesCount--;
                    toolStripLabel.Text = "Deleted the Sprite";
                }
            }
        }
    }
}