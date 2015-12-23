using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
//Joshua Saxton
namespace Boys_vs.Girls
{
    public class Weapon : GameObject
    {
        protected float damageFactor;

        public Weapon(Texture2D tex,Vector2 pos, Game1 g,float df)
            : base(tex,pos,g)
        {
            df = damageFactor;
            tex = this.Spritetex;
        }

        public override void Update()
        {
           
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.Spritetex,this.Position,Color.White);
        }
    }
}
