using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Collections;

namespace Tangz
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Texture2D tank, bullet;
        public int WindowWidth,WindowHeight;

        Tank MyTank;
        ArrayList Enemies = new ArrayList();
        public ArrayList Bullets = new ArrayList();
        int EnemiesCount;

        public Game1()
        {
            MovingObject.GameRef = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = WindowWidth = 1000;
            graphics.PreferredBackBufferHeight = WindowHeight = 800;
            Tank.rnd = new Random();
            EnemiesCount = 5;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bullet = Content.Load<Texture2D>(@"Images/Bullet");
            tank = Content.Load<Texture2D>(@"Images/Tank");
            MyTank = new PlayerTank(new Vector2(WindowWidth / 2, WindowHeight / 2),
                                    new Vector2(3, 3),
                                    tank,
                                    bullet);
            for (int i = 0; i < EnemiesCount; i++)
            {
                Enemies.Add(new EnemyTank(new Vector2(Tank.rnd.Next(WindowWidth), Tank.rnd.Next(WindowHeight)),
                                          new Vector2(2, 2),
                                          tank,
                                          bullet));
            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            MyTank.Update();
            foreach (Bullet B in Bullets)
                B.Update();
            foreach (EnemyTank E in Enemies)
                E.Update();



            for (int i = 0; i < Bullets.Count; i++)
            {
                for (int j = 0; j< Enemies.Count; j++)
                {
                    if (((Bullet)Bullets[i]).IsCollided((EnemyTank)Enemies[j]))
                    {
                        Enemies.Remove(Enemies[j]);
                        Bullets.Remove(Bullets[i]);
                        i--;
                        break;
                    }
                }
            }

            for (int i = 0; i < Bullets.Count; i++)
            {
                if (((Bullet)Bullets[i]).IsCollided((PlayerTank)MyTank))
                {
                    this.Exit();
                }
            }

            while (Enemies.Count < EnemiesCount )
            {
                Enemies.Add(new EnemyTank(new Vector2(Tank.rnd.Next(WindowWidth), Tank.rnd.Next(WindowHeight)),
                                      new Vector2(2, 2),
                                      tank,
                                      bullet));
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            MyTank.Draw();
            foreach (Bullet B in Bullets)
                B.Draw();
            foreach (EnemyTank E in Enemies)
                E.Draw();

            spriteBatch.End();
    
            base.Draw(gameTime);
        }
    }
}
