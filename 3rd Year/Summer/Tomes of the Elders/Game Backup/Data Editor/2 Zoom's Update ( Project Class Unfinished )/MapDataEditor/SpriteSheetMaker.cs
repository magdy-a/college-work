using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapDataEditor
{
    /// <summary>
    /// Used to do all operations on the Sprite Sheet.
    /// </summary>
    class SpriteSheetMaker
    {
        #region Private Members
        /// <summary>
        /// Current bitmap holding the sprites.
        /// </summary>
        Bitmap bitmap;
        /// <summary>
        /// A reference to the picture box being used.
        /// </summary>
        PictureBox PictureRef;
        /// <summary>
        /// Sprite size represented in pixels.
        /// </summary>
        Size spriteSize = new Size(32, 32);
        /// <summary>
        /// Sheet size represented in sprites.
        /// </summary>
        Size sheetSize;
        /// <summary>
        /// Background color of the sprite sheet.
        /// </summary>
        Color BackgroundColor = Color.FromArgb(255, 0, 255);
        /// <summary>
        /// Pointer to the next empty position.
        /// </summary>
        Point NextInsertionPosition;
        /// <summary>
        /// Number of sprites in the sprite sheet.
        /// </summary>
        int spritesCount;
        #endregion

        #region Public Properties
        /// <summary>
        /// Returns a bitmap representing the current sprite sheet.
        /// </summary>
        public Bitmap Bitmap
        {
            get { return bitmap; }
            set { bitmap = value; }
        }
        /// <summary>
        /// Returns number of sprites in the current sprite sheet.
        /// </summary>
        public int SpritesCount
        {
            get { return spritesCount; }
        }
        /// <summary>
        /// Returns the height and width of each sprite in pixels.
        /// </summary>
        public Size SpriteSize { get { return spriteSize; } }
        /// <summary>
        /// Returns the height and width of the sprite sheet in pixels.
        /// </summary>
        public Size SheetSize { get { return sheetSize; } }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of SpriteSheetMaker.
        /// </summary>
        public SpriteSheetMaker(ref PictureBox Ref, int Height, int Width)
        {
            sheetSize = new Size(Height, Width);
            bitmap = new Bitmap(sheetSize.Width * spriteSize.Width, sheetSize.Height * spriteSize.Height);
            NextInsertionPosition = new Point(0, 0);
            PictureRef = Ref;
            PictureRef.Image = bitmap;
            spritesCount = 0;
            ClearAll();
        }
        #endregion

        #region Sheet Wide Methods
        /// <summary>
        /// Sets every pixel in the sheet with Color ( 255 , 0 , 255 ).
        /// </summary>
        public void ClearAll()
        {
            for (int i = 0; i < sheetSize.Height * spriteSize.Height; i++)
                for (int j = 0; j < sheetSize.Width * spriteSize.Width; j++)
                    bitmap.SetPixel(j, i, BackgroundColor);
            PictureRef.Image = bitmap;
        }
        #endregion

        #region Sprite Specific Methods
        /// <summary>
        /// Adds a new sprite to the sheet.
        /// </summary>
        /// <param name="newSprite">The new sprite to be added.</param>
        public void AddSprite(Bitmap newSprite)
        {
            for (int x = 0; x < spriteSize.Width; x++)
                for (int y = 0; y < spriteSize.Height; y++)
                    bitmap.SetPixel(NextInsertionPosition.X + x, NextInsertionPosition.Y + y, newSprite.GetPixel(x, y));

            NextInsertionPosition.X += spriteSize.Width;

            if (NextInsertionPosition.X == spriteSize.Width * sheetSize.Width)
            {
                NextInsertionPosition.X = 0;
                NextInsertionPosition.Y += spriteSize.Height;
            }
            PictureRef.Image = bitmap;
            spritesCount++;
        }

        /// <summary>
        /// Deletes a sprite from the sheet.
        /// </summary>
        /// <param name="X">Horizontal position in the sheet.</param>
        /// <param name="Y">Vertical position in the sheet.</param>
        public void DeleteSprite(int X, int Y)
        {
            if (NextInsertionPosition.X == 0)
            {
                NextInsertionPosition.X = spriteSize.Width * (sheetSize.Width - 1);
                NextInsertionPosition.Y -= spriteSize.Height;
            }
            else
            {
                NextInsertionPosition.X -= spriteSize.Width;
            }

            for (int x = 0; x < spriteSize.Width; x++)
            {
                for (int y = 0; y < spriteSize.Height; y++)
                {
                    bitmap.SetPixel(X * spriteSize.Width + x, Y * spriteSize.Height + y,
                        bitmap.GetPixel(NextInsertionPosition.X + x, NextInsertionPosition.Y + y));
                    bitmap.SetPixel(NextInsertionPosition.X + x, NextInsertionPosition.Y + y, BackgroundColor);
                }
            }
            spritesCount--;
            PictureRef.Image = bitmap;
        }

        /// <summary>
        /// Exchanges two tiles given their exact positions.
        /// </summary>
        /// <param name="FromTile">Position of first tile in pixels.</param>
        /// <param name="ToTile">Position of second tile in pixels.</param>
        public void ExchangeTiles(Point FromTile, Point ToTile)
        {
            for ( int i = 0 ; i < spriteSize.Height ; i ++ )
                for (int j = 0; j < spriteSize.Width; j++)
                {
                    Color temp = bitmap.GetPixel(FromTile.X + j, FromTile.Y + i);
                    bitmap.SetPixel(FromTile.X + j, FromTile.Y + i,
                        bitmap.GetPixel(ToTile.X + j, ToTile.Y + i));
                    bitmap.SetPixel(ToTile.X + j, ToTile.Y + i, temp);
                }
            PictureRef.Image = bitmap;
        }
        #endregion
    }
}
