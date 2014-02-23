using System;
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
        protected int gridX;
        protected int gridY;

        protected Vector2 center;
        protected Vector2 origin;

        public float rotation;
        public bool draggable, visible;

        public Vector2 Center
        {
            get { return center; }
        }


        public int GridX
        {
            get { return gridX; }
        }


        public int GridY
        {
            get { return gridY; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Sprite(Texture2D tex, int x, int y)
        {
            texture = tex;
            gridX = x;
            gridY = y;

            center = new Vector2(0,0);
            
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

        public void setPosition(float x, float y)
        {
            gridX = (int)x;
            gridY = (int)y;
        }

        public void setPosition(int x, int y)
        {
            gridX = x;
            gridY = y;
        }


        //Move the sprite around
        public void moveRight()
        {
            gridX++;
        }

        public void moveLeft()
        {
            gridX--;
        }

        public void moveUp()
        {
            gridY--;
        }

        public void moveDown()
        {
            gridY++;
        }


    }
}

