using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//Joshua Saxton 


namespace Boys_vs.Girls
{
    public class Sword : Weapon
    {
        public Sword(Texture2D t, Game1 g,float df)
            : base(t, new Vector2(Game1.jen.Next(5,790),Game1.jen.Next(5,590)),g,df)
        {
            df = 10.0f;
        }

    }
}
