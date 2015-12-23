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
    /// <summary>
    /// Provides template for all objects except rooms on the game screen
    /// </summary>
    public abstract class GameObject
    {
        private Vector2 position;
        private Vector2 origin;
        private Rectangle spriterect;
        private Texture2D spritetex;
        private float rotation;
        private Game1 bvggame;
        private Vector2 velocity;
        
        /// <summary>
        /// Texture, Position, Game 
        /// </summary>
        /// <param name="tex"></param>
        /// <param name="pos"></param>
        /// <param name="g"></param>
        public GameObject(Texture2D tex,Vector2 pos,Game1 g)
        {
            spritetex = tex;
            position = pos;
            spriterect = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
            origin = new Vector2(tex.Width / 2, tex.Height / 2);
            velocity = new Vector2(0, 0);
            bvggame = g;
        }

        /// <summary>
        /// Texture Property: returns sprite's texture
        /// </summary>
        public Texture2D Spritetex
        {
            get { return spritetex; }
            set { spritetex = value; }
        }
        /// <summary>
        /// Position property
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public float X
        {
            get { return position.X; }
            set { position.X = value;
            spriterect.X = (int) value;
            }
        }
        public float Y
        {
            get { return position.Y; }
            set { position.Y = value;
            spriterect.Y = (int)value; 
            }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        /// <summary>
        /// Rectangle attribute property
        /// </summary>
        public Rectangle Spriterect
        {
            get { return new Rectangle((int)position.X, (int)position.Y, spritetex.Width, spritetex.Height); }
        }

        /// <summary>
        /// Property for origin attribute
        /// </summary>
        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Game1 Bvggame
        {
            get { return bvggame; }
            set { bvggame = value; }
        }

        public abstract void Update();

        public abstract void Draw(SpriteBatch spritebatch);
    }
}
