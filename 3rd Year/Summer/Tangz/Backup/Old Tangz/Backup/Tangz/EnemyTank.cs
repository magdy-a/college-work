using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tangz
{
    public class EnemyTank : Tank
    {

        int Counter;
        int distance;

        public EnemyTank(Vector2 Pos, Vector2 Spd, Texture2D Tnk, Texture2D blt)
            : base(Pos, Spd, Tnk, blt)
        {
            Counter = 0;
            distance = Tank.rnd.Next(Math.Min(GameRef.WindowHeight,GameRef.WindowWidth)/2);
        }

        public override void Update()
        {
            if (++Counter > distance)
            {
                distance = Tank.rnd.Next(Math.Min(GameRef.WindowHeight, GameRef.WindowWidth)/2);
                Counter = 0;
                Direction = GetRandomDirection();
            }

            switch (Direction)
            {
                case Directions.Up:
                    Position.Y -= Speed.Y;
                    break;
                case Directions.Right:
                    Position.X += Speed.X;
                    break;
                case Directions.Down:
                    Position.Y += Speed.Y;
                    break;
                case Directions.Left:
                    Position.X -= Speed.X;
                    break;
            }

            if (Tank.rnd.Next(150) == 1)
                Fire();

            base.Update();
        }
    }
}