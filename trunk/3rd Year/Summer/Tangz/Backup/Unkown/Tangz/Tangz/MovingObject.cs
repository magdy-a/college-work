using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tangz
{
    public class MovingObject
    {
        protected Vector2 Speed;
        protected Vector2 Position;
        protected Texture2D Picture;
        public static Game1 GameRef;

        public virtual void Draw()
        {
        }

        public virtual void Update()
        {
        }

        public bool IsCollided(MovingObject Other)
        {
            float x = Position.X, y = Position.Y, h = Picture.Height, w = Picture.Width,
                X = Other.Position.X, Y = Other.Position.Y, H = Other.Picture.Height, W = Other.Picture.Width;

            if (x >= X && x <= X + W && y >= Y && y <= Y + H)
                return true;
            if (x + w >= X && x + w <= X + W && y >= Y && y <= Y + H)
                return true;
            if (x + w >= X && x + w <= X + W && y + h >= Y && y + h <= Y + H)
                return true;
            if (x >= X && x <= X + W  && y + h >= Y && y + h <= Y + H)
                return true;

            return false;
        }
    }
}
