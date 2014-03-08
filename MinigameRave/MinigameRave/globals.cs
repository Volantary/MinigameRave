using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace MinigameRave
{
    public static class globals
    {
        public static ContentManager contentManager;
        public static SoundEffectInstance titleScreenMusic;
        public static SoundEffect soundEffect;
        public static SpriteFont globalFont;
        public static bool debugMode;
        static int gameLife;
  
        public static void setGameLife(int number)
        {
            gameLife = number;
        }

        public static int getGameLife()
        {
            return gameLife;
        }
   
    }

}
