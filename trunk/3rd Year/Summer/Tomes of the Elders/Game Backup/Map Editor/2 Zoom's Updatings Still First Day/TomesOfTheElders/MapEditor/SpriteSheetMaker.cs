using System;
using System.Drawing;

namespace MapEditor
{
    /// <summary>
    /// Used to do all operations on the Sprite Sheet.
    /// </summary>
    class SpriteSheetMaker
    {
        #region Private Members
        Bitmap bitmap;
        Size spriteSize = new Size(32, 32);
        Size sheetSize = new Size(10, 10);
        Color BackgroundColor = Color.FromArgb(255, 0, 255);
        Point NextEditingPosition;
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
        public SpriteSheetMaker()
        {
            bitmap = new Bitmap(sheetSize.Width * spriteSize.Width, sheetSize.Height * spriteSize.Height);
            ClearAll();
            NextEditingPosition = new Point(0, 0);
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
        }

        /// <summary>
        /// Replaces the existing sheet with a new one.
        /// </summary>
        /// <param name="newbitmap">The new sheet to be replaced.</param>
        /// <returns>Number of textures available in the new sheet.</returns>
        public int LoadSheet(Bitmap newbitmap)
        {
            bitmap = newbitmap;
            for (int i = 0; i < sheetSize.Height; i++)
                for (int j = 0; j < sheetSize.Width; j++)
                {
                    bool clear = true;
                    for (int a = 0; a < spriteSize.Height && clear; a++)
                        for (int b = 0; b < spriteSize.Width && clear; b++)
                            clear = (bitmap.GetPixel(j * spriteSize.Width + b, i * spriteSize.Height + a) == BackgroundColor);
                    if (clear)
                    {
                        NextEditingPosition = new Point(j * spriteSize.Width, i * spriteSize.Height);
                        return (i * sheetSize.Width + j);
                    }
                }
            NextEditingPosition = new Point(0, sheetSize.Height * spriteSize.Height);
            return sheetSize.Height * sheetSize.Width;
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
                    bitmap.SetPixel(NextEditingPosition.X + x, NextEditingPosition.Y + y, newSprite.GetPixel(x, y));

            NextEditingPosition.X += spriteSize.Width;

            if (NextEditingPosition.X == spriteSize.Width * sheetSize.Width)
            {
                NextEditingPosition.X = 0;
                NextEditingPosition.Y += spriteSize.Height;
            }
        }

        /// <summary>
        /// Deletes a sprite from the sheet.
        /// </summary>
        /// <param name="X">Horizontal position in the sheet.</param>
        /// <param name="Y">Vertical position in the sheet.</param>
        public void DeleteSprite(int X, int Y)
        {
            if (NextEditingPosition.X == 0)
            {
                NextEditingPosition.X = spriteSize.Width * (sheetSize.Width - 1);
                NextEditingPosition.Y -= spriteSize.Height;
            }
            else
            {
                NextEditingPosition.X -= spriteSize.Width;
            }

            for (int x = 0; x < spriteSize.Width; x++)
            {
                for (int y = 0; y < spriteSize.Height; y++)
                {
                    bitmap.SetPixel(X * spriteSize.Width + x, Y * spriteSize.Height + y,
                        bitmap.GetPixel(NextEditingPosition.X + x, NextEditingPosition.Y + y));
                    bitmap.SetPixel(NextEditingPosition.X + x, NextEditingPosition.Y + y, BackgroundColor);
                }
            }
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
        }
        #endregion
    }
}
