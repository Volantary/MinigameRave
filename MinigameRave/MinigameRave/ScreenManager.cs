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
    /* Screens
     * 0 = Title
     * 1 = Menu
     * 2 = Options
     * 3 = Game
     * 9 = Game Over
     */

    public static class ScreenManager
    {
        static bool changed;
        static int currentScreen;
        static List<List<Button>> buttons;

        public static int screen
        {
            get { return currentScreen; }
            set
            {
                if (screen != value)
                {
                    changed = true;
                    currentScreen = value;
                }
            }
        }

        public static void Update(GameTime gameTime)
        {
            foreach (Button b in buttons[currentScreen])
            {
                b.Update(gameTime);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Button b in buttons[currentScreen])
            {
                b.Draw(spriteBatch);
            }
        }


        public static void initialise()
        {
            screen = 0;
            buttons = new List<List<Button>>();
            int i = 0;
            while (i != 10)
            {
                buttons.Add(new List<Button>());
                i++;
            }
        }

    }

}
