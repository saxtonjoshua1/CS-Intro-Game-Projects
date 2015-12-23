using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
//Joshua Saxton
namespace Boys_vs.Girls
{
    public class Monkey : Enemy
    {
        public Monkey(Texture2D t, Game1 g)
            : base(t, g)
        {
        }

        public override void Update(Vector2 playerpos)
        {
            if (Vector2.Distance(playerpos, this.Position) < 40)
            {
                double angle = Math.Atan2(playerpos.Y - this.Y, playerpos.X - this.X);
                Velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                Position += Velocity * 0.5f;
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.Spritetex, this.Spriterect, null, Color.White, 0.5f, this.Origin, SpriteEffects.None, 0);
        }
    }
}
