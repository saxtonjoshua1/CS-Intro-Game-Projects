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
    public class Boy : Enemy
    {
        public Boy(Texture2D t, Game1 g)
            : base(t,g)
        {
          
        }

        public override void Update(Vector2 playerpos)
        {
            float distancetoPlayer = Vector2.Distance(this.Position, Game1.p1.Position);

            if (distancetoPlayer <= 50)
            {
                this.X = Game1.jen.Next(0, 800);
                this.Y = Game1.jen.Next(0, 600);
            }
        }
    }
}
