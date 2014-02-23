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
    public enum ButtonStatus
    {
        Normal,
        Pressed,
        MouseOver,
    }

    public class Button : Sprite
    {
        // Store the MouseState of the last frame.
        public MouseState previousState;

        // A rectangle that covers the button.
        public Rectangle bounds;

        // Store the current state of the button.
        public ButtonStatus state = ButtonStatus.Normal;

        public event EventHandler Clicked;
        public event EventHandler Released;
        public event EventHandler Held;

        public bool active;

        public Button(Texture2D texture, int x, int y, Vector2 Position) : base(texture,x,y)
        {
                this.bounds = new Rectangle((int)position.X, (int)position.Y,
                texture.Width, texture.Height);
                active = true;
        }

        public override void Update(GameTime gameTime)
        {
            // Determine if the mouse if over the button.
            MouseState mouseState = Mouse.GetState();

            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;

            bool isMouseOver = bounds.Contains(mouseX, mouseY);

            // Update the button state.
            if (isMouseOver && state != ButtonStatus.Pressed)
            {
                state = ButtonStatus.MouseOver;
            }
            else if (isMouseOver == false && state != ButtonStatus.Pressed)
            {
                state = ButtonStatus.Normal;
                if (Released != null)
                    Released(this, EventArgs.Empty);
            }

            // Check if the player holds down the button.
            if (mouseState.LeftButton == ButtonState.Pressed &&
                previousState.LeftButton == ButtonState.Released)
            {
                if (isMouseOver == true)
                {
                    // Update the button state.
                    state = ButtonStatus.Pressed;
                }
            }

            if (mouseState.LeftButton == ButtonState.Pressed &&
                previousState.LeftButton == ButtonState.Pressed)
            {
                if (isMouseOver == true)
                {
                    // Update the button state.
                    //Held(this, EventArgs.Empty);
                }
            }

            // Check if the player releases the button.
            if (mouseState.LeftButton == ButtonState.Released &&
                previousState.LeftButton == ButtonState.Pressed)
            {
                if (isMouseOver == true)
                {
                    // update the button state.
                    state = ButtonStatus.MouseOver;

                    if (Clicked != null)
                    {
                        // Fire the clicked event.
                        Clicked(this, EventArgs.Empty);
                    }
                }

                else if (state == ButtonStatus.Pressed)
                {
                    state = ButtonStatus.Normal;
                }
            }

            previousState = mouseState;
            this.bounds = new Rectangle((int)position.X, (int)position.Y,
                texture.Width, texture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (state)
            {
                case ButtonStatus.Normal:
                    spriteBatch.Draw(texture, bounds, Color.White);
                    break;
                case ButtonStatus.Pressed:
                    spriteBatch.Draw(texture, bounds, Color.Gray);
                    break;
                default:
                    spriteBatch.Draw(texture, bounds, Color.White);
                    break;
            }
        }


    }

}
