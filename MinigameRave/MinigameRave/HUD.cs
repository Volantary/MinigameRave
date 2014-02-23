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
    class HUD
    {
        public static SpriteFont font;
        public static SpriteFont highScoresFont;
        public static int score;
        public static int level;
        public static String scoreText = "Score: ";
        public static String levelText = "Level: ";
        public static String difficultyText = "Difficulty: ";
        public static String mazeText = "Maze: ";
        public static  float[] speeds = new float[]{100,50,12.5f,2,1};
        public static String[] difficulties = new String[] { "Easy", "Normal", "Difficult", "Rock Solid", "Colin" };
        public static ContentManager Content;

        public static void reset()
        {

        }

        public static void update()
        {
        }

        public static void draw()
        {
        }
    }
}
