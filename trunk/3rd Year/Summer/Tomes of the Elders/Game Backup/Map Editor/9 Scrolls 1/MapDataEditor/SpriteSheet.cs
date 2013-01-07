using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataEditor
{
    /// <summary>
    /// Used to do all operations on the Sprite Sheet.
    /// </summary>
    [Serializable]
    public class SpriteSheet
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
        public static Size SpriteSize = new Size(32, 32);
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
        /// Returns the height and width of the sheet represented in sprites.
        /// </summary>
        public Size SheetSize { get { return sheetSize; } }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of SpriteSheetMaker.
        /// </summary>
        /// <param name="Ref">Reference to the picturebox to be updated.</param>
        /// <param name="Height">Height of the spritesheet.</param>
        /// <param name="Width">Width of the spritesheet.</param>
        public SpriteSheet(ref PictureBox Ref, int Height, int Width)
        {
            sheetSize = new Size(Width, Height);
            bitmap = new Bitmap(sheetSize.Width * SpriteSize.Width, sheetSize.Height * SpriteSize.Height);
            NextInsertionPosition = new Point(0, 0);
            PictureRef = Ref;
            PictureRef.Image = bitmap;
            spritesCount = 0;
            ClearAll();
        }
        #endregion

        #region Sheet Wide Methods
        /// <summary>
        /// Sets every pixel in the sheet with BackgroundColor.
        /// </summary>
        public void ClearAll()
        {
            for (int i = 0; i < sheetSize.Height * SpriteSize.Height; i++)
                for (int j = 0; j < sheetSize.Width * SpriteSize.Width; j++)
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
            for (int x = 0; x < SpriteSize.Width; x++)
                for (int y = 0; y < SpriteSize.Height; y++)
                    bitmap.SetPixel(NextInsertionPosition.X + x, NextInsertionPosition.Y + y, newSprite.GetPixel(x, y));

            NextInsertionPosition.X += SpriteSize.Width;

            if (NextInsertionPosition.X == SpriteSize.Width * sheetSize.Width)
            {
                NextInsertionPosition.X = 0;
                NextInsertionPosition.Y += SpriteSize.Height;
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
                NextInsertionPosition.X = SpriteSize.Width * (sheetSize.Width - 1);
                NextInsertionPosition.Y -= SpriteSize.Height;
            }
            else
            {
                NextInsertionPosition.X -= SpriteSize.Width;
            }

            for (int x = 0; x < SpriteSize.Width; x++)
            {
                for (int y = 0; y < SpriteSize.Height; y++)
                {
                    bitmap.SetPixel(X * SpriteSize.Width + x, Y * SpriteSize.Height + y,
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
            for ( int i = 0 ; i < SpriteSize.Height ; i ++ )
                for (int j = 0; j < SpriteSize.Width; j++)
                {
                    Color temp = bitmap.GetPixel(FromTile.X + j, FromTile.Y + i);
                    bitmap.SetPixel(FromTile.X + j, FromTile.Y + i,
                        bitmap.GetPixel(ToTile.X + j, ToTile.Y + i));
                    bitmap.SetPixel(ToTile.X + j, ToTile.Y + i, temp);
                }
            PictureRef.Image = bitmap;
        }

        /// <summary>
        /// Gets a specific sprite from the sprite sheet.
        /// </summary>
        /// <param name="x">Horizontal position of the sprite.</param>
        /// <param name="y">Vertical position of the sprite.</param>
        /// <returns>The requested sprite.</returns>
        public Bitmap GetSprite(int x, int y)
        {
            Bitmap sprite = new Bitmap(SpriteSize.Width, SpriteSize.Height);
            Point sourcePixel = new Point(x * SpriteSize.Width, y * SpriteSize.Height);

            for (int i = sourcePixel.Y; i < sourcePixel.Y + SpriteSize.Height; i++)
                for (int j = sourcePixel.X; j < sourcePixel.X + SpriteSize.Width; j++)
                    sprite.SetPixel(j - sourcePixel.X, i - sourcePixel.Y, bitmap.GetPixel(j, i));
            
            return sprite;
        }

        /// <summary>
        /// Saves a sprite to the specific position in the sprite sheet.
        /// </summary>
        /// <param name="x">Horizontal position of the sprite.</param>
        /// <param name="y">Vertical position of the sprite.</param>
        /// <param name="sprite">The sprite to be put.</param>
        public void SetSprite(int x, int y, Bitmap sprite)
        {
            Point targetPixel = new Point(x * SpriteSize.Width, y * SpriteSize.Height);

            for (int i = targetPixel.Y; i < targetPixel.Y + SpriteSize.Height; i++)
                for (int j = targetPixel.X; j < targetPixel.X + SpriteSize.Width; j++)
                    bitmap.SetPixel(j, i, sprite.GetPixel(j - targetPixel.X, i - targetPixel.Y));
        }

        /// <summary>
        /// Creates Array of Bitmaps of the Sprite it contains
        /// </summary>
        /// <returns>Linear Array of Sprites</returns>
        public Bitmap[] SheetBitmaps()
        {
            Bitmap[] SheetBitmap = new Bitmap[spritesCount];
            int X = 0, Y = 0;
            for (int i = 0; i < spritesCount; i++)
            {
                GetTextureDimensions(i,sheetSize.Width,ref Y,ref X);
                SheetBitmap[i] = GetSprite(X, Y);
            }
            return SheetBitmap;
        }

        /// <summary>
        /// takes the number of Sprite and returns the Row&Column Number of, ( It's X&Y )
        /// </summary>
        /// <param name="Number">The Number of the Sprite</param>
        /// <param name="Width">The Width of the Sheet contains Sprites</param>
        /// <param name="RowNumber">(ref) Returns the Row Number</param>
        /// <param name="ColumnNumber">(ref) Returns the Column Number</param>
        static public void GetTextureDimensions(int Number, int Width, ref int RowNumber, ref int ColumnNumber)
        {
            if (Number == 0)
            {
                RowNumber = ColumnNumber = 0;
                return;
            }
            RowNumber = Number / Width;
            ColumnNumber = Number - (RowNumber * Width);
        }
        
        /// <summary>
        /// Gets the Number of the Texture starting from Zero.
        /// </summary>
        /// <param name="Width">Width of the Sheet</param>
        /// <param name="RowNumber">Texture's RowNumber</param>
        /// <param name="ColumnNumber">Texture's ColumnNumber</param>
        /// <returns>Number of the Texture, count starts from Zero</returns>
        static public int GetTextureNumber(int Width, int RowNumber, int ColumnNumber)
        {
            return (Width * RowNumber) + ColumnNumber;
        }
        #endregion
    }
}
