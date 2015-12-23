using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//Joshua Saxton
namespace Boys_vs.Girls
{
    public class Bullet : Weapon
    {
        private int weaponPower = 2; 

        public Bullet(Vector2 velocity, Vector2 position, Texture2D tex, Game1 g,float df)
           : base(tex,position,g,df)
        {
            Velocity = velocity;
            df = 0.0f;
        }

        public override void Update()
        {
            X += Velocity.X * weaponPower;
            Y += Velocity.Y * weaponPower;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);   
        }
    }
}
