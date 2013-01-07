using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tangz
{
    public class Bullet : MovingObject
    {
        public Bullet(Vector2 Pos,Vector2 Spd,Texture2D Tex)
        {
            Position = Pos;
            Speed = Spd;
            Picture = Tex;
        }

        public override void Draw()
        {
            GameRef.spriteBatch.Draw(Picture, Position, Color.White);
        }

        public override void Update()
        {
            Position += Speed;
        }
    }
}
