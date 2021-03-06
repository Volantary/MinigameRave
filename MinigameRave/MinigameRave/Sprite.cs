﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MinigameRave
{
    public class Sprite
    {
        protected Texture2D texture;

        public Vector2 position;

        protected Vector2 center;
        protected Vector2 origin;

        public float rotation;
        public bool draggable, visible;

        public Vector2 Center
        {
            get { return center; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Sprite(Texture2D tex, Vector2 position)
        {
            texture = tex;
            this.position = position;
                     
        }

        
        public virtual void Update(GameTime gameTime)
        {


            this.center = new Vector2(
                position.X + texture.Width / 2,
            position.Y + texture.Height / 2
            );
            
            center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, position,null, Color.White, rotation, origin,1,SpriteEffects.None,0);
            spriteBatch.Draw(texture, position, Color.White);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(texture, position, color);
        }

        public virtual void Draw(SpriteBatch spriteBatch, float setRotation, Color color)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height), null, Color.White, setRotation, origin, SpriteEffects.None, 0f);
        }

        public virtual void setOrigin(Vector2 origin)
        {
            this.origin = origin;
        }


        //Move the sprite around
        public void moveRight(int amount)
        {
            position.X += amount;
        }

        public void moveLeft(int amount)
        {
            position.X -= amount;
        }

        public void moveUp(int amount)
        {
            position.Y += amount;
        }

        public void moveDown(int amount)
        {
            position.Y -= amount;
        }


    }
}

