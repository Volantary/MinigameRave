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

namespace MinigameRave
{
    public static class gameManager
    {
        public static int currentGame; //This will hold the active game or be 0 when no games are active
        public static bool gameOver; //Will always be False unless the end of the current game has been reached
        static List<List<Button>> buttons; // Holds all the buttons for the various games. 
        static int numberOfGames; //Used to initialise the button list - 1 list per game

        public static void initialise()
        {
            currentGame = 0; // No game active
            gameOver = false;
            numberOfGames = 30; //30 minigames to start with, can change this number as and when

            buttons = new List<List<Button>>();
            int i = 0;
            while (i <= numberOfGames) //Create button lists for 30 games, 
            {
                buttons.Add(new List<Button>());
                i++;
            }

        }

        //An interface to load buttons into the game (providing there is a list there already)
        public static void buttonLoader(int game, List<Button> buttonsToLoad)
        {
            buttons[game] = buttonsToLoad;
        }

        //An interface to load buttons into the game (using a load of buttons)
        public static void buttonLoader(int game, params Button[] buttonsList)
        {
            List<Button> buttonsToLoad;
            buttonsToLoad = new List<Button>();

            for (int i = 0; i == buttonsList.Length; i++)
            {
                buttonsToLoad.Add(buttonsList[i]);
            }

            buttons[game] = buttonsToLoad;
        }
    }
}
