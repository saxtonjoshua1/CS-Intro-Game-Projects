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
    public class Enemy : GameObject
    {
        private float health;

        public float Health
        {
            get { return health; }
            set { health = value; }
        }

        public Enemy(Texture2D t, Game1 g)
            : base(t, new Vector2(Game1.jen.Next(0, 500),
                         Game1.jen.Next(0, 700)),g)
        {
            
        }
        public override void Update()
        {
        }

        public virtual void Update(Vector2 playerpos)
        {

        }

        public virtual int Attack(Player p)
        {
            if (Vector2.Distance(this.Position, p.Position) < 0.5)
            {
                p.Health -= 1;
            }
            return p.Health;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.Spritetex, this.Spriterect, null, Color.White, 0.5f, this.Origin, SpriteEffects.None, 0);
        }
    }
}
