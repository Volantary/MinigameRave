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
// 0 - simpleAddition
// 1 - Demo Game
// 2 - Demo Game
//////////////////////////////////////////////////////////////////////////////////////////////

namespace MinigameRave
{
    public static class GameManager
    {
        static int currentGame; //This will hold the active game or be 0 when no games are active
        static List<MiniGame> miniGameList;
        static String gamesPlayed; //CSV list of games already played in this sitting
        static int playedCounter; //How many games have we gotten through?

        public static void initialise(params MiniGame[] mgl)
        {
            currentGame = 0; // No game active
            gamesPlayed = "";
            playedCounter = 0;

            miniGameList = new List<MiniGame>();
            foreach (MiniGame m in mgl)
            {
                miniGameList.Add(m);
            }

            chooseGame();

        }


        //DRAW
        public static void Draw(SpriteBatch spriteBatch)
        {
            miniGameList[currentGame].draw(spriteBatch);
        }


        //UPDATE
        public static void Update(GameTime gameTime)
        {
            miniGameList[currentGame].update(gameTime);

            if (checkForGameOver() == 0) //if game isn't over
            {
                miniGameList[currentGame].update(gameTime);
            }
            else //if game is over
            {
                if (checkForSuccess() == 0) //If player won
                {
                    //SHOW CONGRATS MESSAGE
                    chooseGame();
                }
                else
                {
                    //SHOW FAIL MESSAGE
                    chooseGame();
                }
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

        static int checkForSuccess()
        {
            if (miniGameList[currentGame].success == true)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        static int chooseGame()
        {
            bool carryOn;
            int newGame;
            int howManyGames = miniGameList.Count();
            String[] previousGames = gamesPlayed.Split(',');

            if (globals.debugMode == false) //Not in debug mode
            {

                if (previousGames[0] != "") //If it isn't the first time we've done this
                {

                    do  //go round until we find a nice game
                    {
                        carryOn = false; //Means the loop will break if...
                        Random random = new Random();
                        newGame = random.Next(0, howManyGames + 1);
                        foreach (String s in previousGames)
                        {
                            if (newGame == int.Parse(s) - 1) //...the new game we've selected doesn't match any previous ones
                            {
                                carryOn = true;
                            }
                        }


                    } while (carryOn);

                    resetGame(newGame);
                    playedCounter++;
                    if (gamesPlayed == "")
                    {
                        gamesPlayed += newGame.ToString();
                    }
                    else
                    {
                        gamesPlayed += "," + newGame.ToString();
                    }

                    return newGame;
                }
                else
                {
                    gamesPlayed += '0';
                    return 0;
                }
            }
            else
            {
                resetGame(0);
                return currentGame;
            }
            
        }

        static void resetGame(int currentGame)
        {
            if (currentGame == 0)
            {
                miniGameList[currentGame] = new simpleAddition();
            }
        }
    }
}
