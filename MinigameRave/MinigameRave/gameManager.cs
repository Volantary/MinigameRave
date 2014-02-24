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

//   GAME MANAGER
//   In the same way that screenManager handles the screens of the game, this class will handle the games themselves

////////////////////////////////////////////// GAME LIST /////////////////////////////////////
// 0 - Demo Game
// 1 - Demo Game
// 2 - Demo Game
//////////////////////////////////////////////////////////////////////////////////////////////

namespace MinigameRave
{
    public static class GameManager
    {
        static int currentGame; //This will hold the active game or be 0 when no games are active
        public static bool gameOver; //Will always be False unless the end of the current game has been reached
        static List<MiniGame> miniGameList;

        public static void initialise(params MiniGame[] mgl)
        {
            currentGame = 0; // No game active
            gameOver = false;

            miniGameList = new List<MiniGame>();
            foreach (MiniGame m in mgl)
            {
                miniGameList.Add(m);
            }

        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            miniGameList[currentGame].draw(spriteBatch);
        }

        public static void Update(GameTime gameTime)
        {
            if (checkForGameOver() == 0)
            {
                miniGameList[currentGame].update(gameTime);
            }
            else
            {
                currentGame = 0;
            }

        }

        static int checkForGameOver()
        {
            if (miniGameList[currentGame].gameOver == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
