using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tangz
{
    public class PlayerTank : Tank
    {
        bool SpaceDown = false;
        public PlayerTank(Vector2 Pos, Vector2 Spd, Texture2D Tnk, Texture2D blt)
            : base(Pos,Spd,Tnk,blt)
        {
            
        }


        public override void Draw()
        {
            float angle = MathHelper.ToRadians((float)((int)Direction * 90));
            GameRef.spriteBatch.Draw(Picture, Position, null, Color.Red, angle, new Vector2(Picture.Width / 2, Picture.Height / 2), (float)1.0, SpriteEffects.None, (float)0.0);
        }
        public override void Update()
        {
            KeyboardState KeyState = Keyboard.GetState();
            if (KeyState.IsKeyDown(Keys.Up))
            {
                if (Direction != Directions.Up)
                    Direction = Directions.Up;
                else
                    Position.Y -= Speed.Y;
            }
            else if (KeyState.IsKeyDown(Keys.Right))
            {
                if (Direction != Directions.Right)
                    Direction = Directions.Right;
                else
                    Position.X += Speed.X;
            }
            else if (KeyState.IsKeyDown(Keys.Left))
            {
                if (Direction != Directions.Left)
                    Direction = Directions.Left;
                else
                    Position.X -= Speed.X;
            }
            else if (KeyState.IsKeyDown(Keys.Down))
            {
                if (Direction != Directions.Down)
                    Direction = Directions.Down;
                else
                    Position.Y += Speed.Y;
            }


            if (KeyState.IsKeyDown(Keys.Space))
            {
                //Fire();
                this.SpaceDown = true;
            }

            if (KeyState.IsKeyUp(Keys.Space) && SpaceDown)
            {
                Fire();
                SpaceDown = false;
            }

            base.Update();
        }
    }
}