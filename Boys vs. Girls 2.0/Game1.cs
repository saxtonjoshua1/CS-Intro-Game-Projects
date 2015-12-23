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
//Joshua Saxton 
namespace Boys_vs.Girls
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        public static Random jen = new Random();

        public static Player p1;
        public static Player p2;

        private List<Enemy> enemylist = new List<Enemy>();
        public static List<Weapon> onscreenWeapons = new List<Weapon>(3);

        private Texture2D player_texture;

        public Texture2D bulletHeart;
        public Texture2D missilePod;
        public Texture2D lipstick;
        public Texture2D currbullet;

        public Texture2D sword;
        public Texture2D lollipop;

        private Texture2D Spring;

        public enum ScreenState
        {
            startScreen,
            playingScreen,
            highScore,
            endGame
        }
        ScreenState currstate;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            Content.RootDirectory = "Content";
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
            currstate = ScreenState.startScreen;
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

            // TODO: use this.Content to load your game content here

            player_texture = Content.Load<Texture2D>("Girl");
            p1 = new Player("Sweetie", 0, player_texture, new Vector2(100.0f, 100.0f), this, 1);
            p2 = new Player("Honey", 0, player_texture, new Vector2(500.0f, 500.0f), this, 2);

            font = Content.Load<SpriteFont>("font");

            for (int i = 0; i < 20; i++)
            {
                enemylist.Add(new Spider(Content.Load<Texture2D>("Spider"), this));
                enemylist.Add(new Boy(Content.Load<Texture2D>("Boy"), this));
                enemylist.Add(new Monkey(Content.Load<Texture2D>("monkey"), this));
            }

            //Bullet loading
            bulletHeart = Content.Load<Texture2D>("BulletHeart");
            missilePod = Content.Load<Texture2D>("Missilepod");
            lipstick = Content.Load<Texture2D>("Lipstick");

            //Weapon loading
            sword = Content.Load<Texture2D>("Sword");
            onscreenWeapons.Add(new Sword(sword, this, 10.0f));
            lollipop = Content.Load<Texture2D>("Lollipop");
            onscreenWeapons.Add(new Lollipop(lollipop, this, 30.0f));

            Spring = Content.Load<Texture2D>("Spring room");
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
        /// Allows the game to run logic such as updating the Room,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            switch (currstate)
            {
                case ScreenState.playingScreen:
                    if (p1.Health <= 0 && p2.Health <= 0 || enemylist.Count == 0)
                    {
                        currstate = ScreenState.endGame;
                    }

                    p1.Update();
                    p2.Update();

                    foreach (Enemy e in enemylist)
                    {
                        e.Update(p1.Position);
                        e.Update(p2.Position);
                        e.Attack(p1);
                        e.Attack(p2);
                    }

                    Collisions(p1.Bulletlist, enemylist, p1);
                    Collisions(p2.Bulletlist, enemylist, p2);
                    break;

                case ScreenState.startScreen:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        currstate = ScreenState.playingScreen;
                    }
                    break;

                case ScreenState.highScore:


                case ScreenState.endGame:
                    break;

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

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            switch (currstate)
            {
                case ScreenState.playingScreen:
                    spriteBatch.Draw(Spring, new Vector2(0.0f, 0.0f), Color.White);

                    if (p1.Health >= 0)
                        p1.Draw(spriteBatch);
                    if (p2.Health >= 0)
                        p2.Draw(spriteBatch);

                    foreach (Enemy e in enemylist)
                    {
                        e.Draw(spriteBatch);
                    }
                    foreach (Weapon w in onscreenWeapons)
                    {
                        w.Draw(spriteBatch);
                    }
                    spriteBatch.DrawString(font, "Player 1 Health : " + p1.Health, Vector2.Zero, Color.LavenderBlush);
                    spriteBatch.DrawString(font, "Player 2 Score: " + p1.Score, new Vector2(0, 15), Color.LavenderBlush);
                    spriteBatch.DrawString(font, "Player 2 Health : " + p2.Health, new Vector2(600, 0), Color.Pink);
                    spriteBatch.DrawString(font, "Player 2 Score : " + p2.Score, new Vector2(600, 15), Color.Pink);
                    break;

                case ScreenState.startScreen:
                    spriteBatch.Draw(Content.Load<Texture2D>("StartScreen"), Vector2.Zero, Color.White);
                    spriteBatch.DrawString(font, "Enter = Begin Game", new Vector2(0, 600), Color.White);
                    spriteBatch.DrawString(font, "F1 to enter fullscreen", new Vector2(0, 550), Color.White);
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void Collisions(List<Bullet> bulletlist, List<Enemy> enemylist, Player p)
        {
            for (int i = enemylist.Count - 1; i >= 0; i--)
            {
                Enemy e = enemylist[i];

                for (int j = bulletlist.Count - 1; j >= 0; j--)
                {
                    Bullet b = bulletlist[j];
                    if (b.X >= 800 || b.X <= 0 || b.Y >= 600 || b.Y <= 0)
                    {
                        bulletlist.RemoveAt(j);
                        continue;
                    }
                    if (b.Spriterect.Intersects(e.Spriterect))
                    {
                        e.Health -= .005f;

                        if (e.Health <= 0)
                        {
                            enemylist.RemoveAt(i);
                            bulletlist.RemoveAt(j);
                            p.Score += 10;
                            break;
                        }
                    }
                }
            }
        }
    }
}
