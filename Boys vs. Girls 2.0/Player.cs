using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class Player : GameObject
    {
        private string name;
        private int score;
        private bool gender; //true = male
        private int health;
        private int index;

        private List<Weapon> weaponlist;
        private List<Bullet> bulletlist = new List<Bullet>();
        private Weapon currweapon;
        private int weaponindex;
        private int shotdelay;
        private int shotcount;

        public List<Weapon> Weaponlist
        {
            get { return weaponlist; }
            set { weaponlist = value; }
        }
        public List<Bullet> Bulletlist
        {
            get { return bulletlist; }
            set { bulletlist = value; }
        }
        public Weapon Currweapon
        {
            get{return currweapon;}
        }

        public Player(string n, int s, bool a,Texture2D tex,Vector2 pos,Game1 g,int ind)
            : base(tex,pos,g)
        {
            n = "my name";
            s = 0;
            a = false;
            shotdelay = 15;
            shotcount = 0;
            Bvggame = g;
            index = ind;
            weaponlist = new List<Weapon>();
            weaponindex = -1;
        }

        public Player(string n, int a, Texture2D tex, Vector2 pos,Game1 g, int ind)
            : base(tex,pos,g)
        {
            n = "";
            Spritetex = tex;
            a = 0;
            shotdelay = 15;
            health = 100;
            shotcount = 0;
            g = Bvggame;
            index = ind;
            weaponlist = new List<Weapon>();
            weaponindex = -1;
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public int Health
        {
            get{return health;}
            set{health = value;}
        }

        public float RotationAngle
        {
            get;
            set;
        }

        public override void Update()
        {
            Move();
            shotcount++;
            foreach (Bullet b in bulletlist)
            {
                b.Update();
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.Spritetex, this.Position, null, Color.White, this.RotationAngle, this.Origin, 1.0f, SpriteEffects.None, 0);
            for (int i = 0; i < bulletlist.Count; i++)
            {
                bulletlist[i].Draw(spritebatch);
            }
            //spritebatch.Draw(currweapon.Spritetex, this.Origin, Color.White);
        }
        /// <summary>
        /// Move Method
        /// </summary>
        private void Move()
        {
                if (index == 1)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.M))
                        this.PickupWeapon(this, Game1.onscreenWeapons);
                    if (Keyboard.GetState().IsKeyDown(Keys.J))
                        this.PreviousWeapon();
                    if (Keyboard.GetState().IsKeyDown(Keys.L))
                        this.NextWeapon();
                    if (Keyboard.GetState().IsKeyDown(Keys.RightControl))
                    {
                        Shoot();
                    }
                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0 || Keyboard.GetState().IsKeyDown(Keys.Down))
                    {
                        Y -= (float)Math.Sin(RotationAngle);
                        X -= (float)Math.Cos(RotationAngle);
                    }

                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0 || Keyboard.GetState().IsKeyDown(Keys.Up))
                    {
                        Y += (float)Math.Sin(RotationAngle);
                        X += (float)Math.Cos(RotationAngle);
                    }

                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X < 0 || Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        RotationAngle -= 0.05f;
                    }

                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X > 0 || Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        RotationAngle += 0.05f;
                    }
                }
                else if (index == 2)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.C))
                        this.PickupWeapon(this, Game1.onscreenWeapons);
                    if (Keyboard.GetState().IsKeyDown(Keys.Q))
                        this.PreviousWeapon();
                    if (Keyboard.GetState().IsKeyDown(Keys.E))
                        this.NextWeapon();
                    if (Keyboard.GetState().IsKeyDown(Keys.F))
                    {
                        Shoot();
                    }
                    if (GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left.Y < 0 || Keyboard.GetState().IsKeyDown(Keys.S))
                    {
                        Y -= (float)Math.Sin(RotationAngle);
                        X -= (float)Math.Cos(RotationAngle);
                    }

                    if (GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left.Y > 0 || Keyboard.GetState().IsKeyDown(Keys.W))
                    {
                        Y += (float)Math.Sin(RotationAngle);
                        X += (float)Math.Cos(RotationAngle);
                    }

                    if (GamePad.GetState(PlayerIndex.Two).ThumbSticks.Right.X < 0 || Keyboard.GetState().IsKeyDown(Keys.A))
                    {
                        RotationAngle -= 0.05f;
                    }

                    if (GamePad.GetState(PlayerIndex.Two).ThumbSticks.Right.X > 0 || Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        RotationAngle += 0.05f;
                    }
                }
                KeepOnScreen();
        }

        private void PickupWeapon(Player p, List<Weapon> wl)
        {
            for (int i = wl.Count - 1; i >= 0; i--)
            {
                if (Vector2.Distance(p.Origin, wl[i].Origin) < 5)
                {
                    p.AddWeapon(wl[i]);
                    wl.RemoveAt(i);
                }
            }
        }

        private void AddWeapon(Weapon weapon)
        {
            weaponlist.Add(weapon);
            if (weaponlist.Count == 1)
            {
                weaponindex = 0;
                currweapon = weaponlist[weaponindex];
            }
        }

        private void SetWeapon(int k)
        {
            if (k < weaponlist.Count)
            {
                currweapon = weaponlist[k];
                weaponindex = k;
            }
        }

        private void DropWeapon(int i)
        {
            if (i < weaponlist.Count)
            {
                weaponlist.RemoveAt(i);
            }
            if (weaponlist.Count <= weaponindex)
            {
                if (weaponlist.Count == 0)
                {
                    currweapon = null;
                    weaponindex = -1;
                }
                else
                {
                    weaponindex = 0;
                    currweapon = weaponlist[weaponindex];
                }
            }
        }
        private void NextWeapon()
        {
            if (weaponindex != -1)
            {
                weaponindex++;

                if (weaponindex >= weaponlist.Count)
                {
                    weaponindex = 0;
                }
                currweapon = weaponlist[weaponindex];
            }
        }
        private void PreviousWeapon()
        {
            if (weaponindex != -1)
            {
                weaponindex--;

                if (weaponindex < 0)
                {
                    weaponindex = weaponlist.Count - 1;
                }
                currweapon = weaponlist[weaponindex];
            }
        }

        private void KeepOnScreen()
        {
            if (Position.X < 0)
            {
                this.X = 1;
            }
            else if (Position.X > 800)
            {
                this.X = 799;
            }
            else if (Position.Y < 0)
            {
                this.Y = 1;
            }
            else if (Position.Y > 800)
            {
                this.Y = 799;
            }
        }
                
        private void Shoot()
        {
            if (shotcount > shotdelay)
            {
                Vector2 bulletvelocity = new Vector2();
                bulletvelocity.X = (float)Math.Cos(RotationAngle) * 2;
                bulletvelocity.Y = (float)Math.Sin(RotationAngle) * 2;
                Bullet temp = new Bullet(bulletvelocity, this.Position, SelectBulleTexture(), Bvggame, 0.0f);
                bulletlist.Add(temp);
                shotcount = 0;
            }
        }

        private Texture2D SelectBulleTexture()  
        {
            Random jen1 = new Random();
            int bnum = jen1.Next(1, 4);
            if (bnum == 1)
            {
               return Bvggame.bulletHeart;
            }
            else if (bnum == 2)
            {
                return Bvggame.lipstick;
            }
            else if (bnum == 3)
            {
                return Bvggame.missilePod;
            }
            else
            {
                return Bvggame.bulletHeart;
            }
        }
    }
}

       
