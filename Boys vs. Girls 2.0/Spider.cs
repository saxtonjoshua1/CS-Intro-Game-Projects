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
    public class Spider : Enemy
    {
        public Spider(Texture2D t,Game1 g)
            : base(t, g)
        {
            t = this.Spritetex;   
        }

        public override void Update(Vector2 playpos)
        {
            //this.Y += .334f;
            //this.X -= .334f;

            double angle = Math.Atan2(playpos.Y - this.Y, playpos.X - this.X);

            Velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            Position += Velocity * 0.2f;
        }

        private int Bite(Player p)
        {
            return p.Health--;
        }
    }
}
