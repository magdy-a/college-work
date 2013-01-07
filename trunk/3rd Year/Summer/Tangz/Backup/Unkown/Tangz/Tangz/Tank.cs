using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tangz
{
    public class Tank : MovingObject
    {

        protected Directions Direction;
        private Texture2D bulletTex;
        private int BulletSpeed;
        public static Random rnd;

        public Tank()
        {

        }
        public Tank(Vector2 Pos, Vector2 Spd, Texture2D Tnk, Texture2D blt)
        {
            Position = Pos;
            Speed = Spd;
            Picture = Tnk;
            bulletTex = blt;
            Direction = GetRandomDirection();
            BulletSpeed = 5;
        }

        public void SetBulletSpeed(int Spd)
        {
            BulletSpeed = Spd;
        }

        public override void Draw()
        {
            //GameRef.spriteBatch.Draw(Picture, Position, Color.White);
            //GameRef.spriteBatch.Draw(Picture, Position, null, Color.White, MathHelper.ToRadians((float)((int)Direction * 90)),Vector2.Zero,0.0, SpriteEffects.None, 0);
            float angle= MathHelper.ToRadians((float)((int)Direction * 90));
            GameRef.spriteBatch.Draw(Picture, Position, null, Color.White, angle, new Vector2(Picture.Width/2,Picture.Height/2), (float)1.0, SpriteEffects.None, (float)0.0);
            
        }

        public override void Update()
        {
            if (Direction == Directions.Right && Position.X + Picture.Width > GameRef.WindowWidth)
                Position.X -= GameRef.WindowWidth;
            else if (Direction == Directions.Left && Position.X < 0)
                Position.X += GameRef.WindowWidth;
            else if (Direction == Directions.Up && Position.Y < 0)
                Position.Y += GameRef.WindowHeight;
            else if (Direction == Directions.Down && Position.Y + Picture.Height > GameRef.WindowHeight)
                Position.Y -= GameRef.WindowHeight;
        }

        protected void Fire()
        {
            Bullet New = null;
            int distanceAway = 20;
            switch (Direction)
            {
                case Directions.Up:
                    New = new Bullet(new Vector2(Position.X + Picture.Width / 2, Position.Y - distanceAway),
                                    new Vector2(0, -BulletSpeed),
                                    bulletTex);
                    break;
                case Directions.Right:
                    New = new Bullet(new Vector2(Position.X + Picture.Width + distanceAway, Position.Y + Picture.Height / 2),
                                    new Vector2(BulletSpeed, 0),
                                    bulletTex);
                    break;
                case Directions.Down:
                    New = new Bullet(new Vector2(Position.X + Picture.Width / 2, Position.Y + Picture.Height + distanceAway),
                                    new Vector2(0, BulletSpeed),
                                    bulletTex);
                    break;
                case Directions.Left:
                    New = new Bullet(new Vector2(Position.X - distanceAway, Position.Y + Picture.Height / 2),
                                    new Vector2(-BulletSpeed, 0),
                                    bulletTex);
                    break;
            }
            GameRef.Bullets.Add(New);
        }

        protected Directions GetRandomDirection()
        {
            return (Directions)rnd.Next(4);//***************************

            //switch (rnd.Next(4))
            //{
            //    case 0:
            //        return Directions.Up;
            //    case 1:
            //        return Directions.Right;
            //    case 2:
            //        return Directions.Down;
            //    case 3:
            //        return Directions.Left;
            //    default:
            //        return Directions.Up;
            //}
        }
    }
}
