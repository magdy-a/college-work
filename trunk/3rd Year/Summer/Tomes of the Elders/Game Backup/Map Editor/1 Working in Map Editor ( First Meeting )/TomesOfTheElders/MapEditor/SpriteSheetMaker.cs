using System;
using System.Drawing;

namespace MapEditor
{
    class SpriteSheetMaker
    {
        Bitmap bitmap;
        Size TextureSize = new Size(32, 32);

        int SpriteSheetWidth = 10;
        int SpriteSheetHight = 10;

        Color BackgroundColor = Color.FromArgb(255, 0, 255);
        Point NextEditingPosition;

        public Bitmap Bitmap
        {
            get { return bitmap; }
            set { bitmap = value; }
        }

        public SpriteSheetMaker()
        {
            bitmap = new Bitmap(320, 320);
            ClearAll();
            this.NextEditingPosition = new Point(0, 0);
        }

        public void ClearAll()
        {
            for (int i = 0; i < 320; i++)
                for (int j = 0; j < 320; j++)
                    bitmap.SetPixel(j, i, BackgroundColor);
        }

        public void AddSprite(Bitmap newSprite)
        {
            for (int x = 0; x < TextureSize.Width; x++)
                for (int y = 0; y < TextureSize.Height; y++)
                    bitmap.SetPixel(NextEditingPosition.X + x, NextEditingPosition.Y + y, newSprite.GetPixel(x, y));

            NextEditingPosition.X += TextureSize.Width;//increase Next

            if (NextEditingPosition.X >= (TextureSize.Width * SpriteSheetWidth) - 1)//Check if Line is Full
            {
                NextEditingPosition.X = 0;
                NextEditingPosition.Y += TextureSize.Height;
            }
        }
        public void DeleteSprite(int X, int Y)
        {
            if (X > SpriteSheetWidth - 1 || Y > SpriteSheetHight - 1 || (NextEditingPosition.X == 0 && NextEditingPosition.Y == 0))//Out of Borders
                throw new Exception("Out of Borders !");

            //Set the NextEditingPosition to its Previous
            if (NextEditingPosition.X == 0)//if First in Row
            {
                NextEditingPosition.X = TextureSize.Width * (SpriteSheetWidth - 1);
                NextEditingPosition.Y -= TextureSize.Height;
            }
            else
            {
                NextEditingPosition.X -= TextureSize.Width;
            }

            for (int x = 0; x < TextureSize.Width; x++)//Copy Last & Delete it
            {
                for (int y = 0; y < TextureSize.Height; y++)
                {
                    bitmap.SetPixel(X * TextureSize.Width + x, Y * TextureSize.Height + y, bitmap.GetPixel(NextEditingPosition.X + x, NextEditingPosition.Y + y));//Copy
                    bitmap.SetPixel(NextEditingPosition.X + x, NextEditingPosition.Y + y, BackgroundColor);//Delete
                }
            }
        }
    }
}
