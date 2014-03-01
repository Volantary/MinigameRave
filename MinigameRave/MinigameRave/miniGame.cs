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

/////////////////////////////////////////// Minigame Template ///////////////////////////////////////////////////
// Use this as a starting point for your game  
// Save a copy of this code as yourgame.cs 
// Rename your class and constructor
// The main code will call your draw and update subs, all logic happens in those
// Do not change the arguments for those subs or terrible things will happen
// You can declare as many helper functions and stuff as you want, just keep them private
// You will be given a sound manager to work with, use it all you like
// When you think you're done, use the unit tester to play it to fuck and try and break it as much as possible
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////// Sounds list /////////////////////////////////////////////////////////
// 0 - Music 1
// 1 - Music 2
// 2 - Music 3
// etc
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

///////////////////////////////////////// Texture list /////////////////////////////////////////////////////////
// 0 - Sound 1
// 1 - Sound 2
// 2 - Sound 3
// etc
////////////////////////////////////////////////////////////////////////////////////////////////////////////////




namespace MinigameRave
{
    public class MiniGame
    {

        //Managers - leave these alone!
        protected SoundManager sm;
        protected Textures textures;

        //Important variables - leave these alone!
        public bool gameOver;
        public bool success;
        protected string miniGameName; //set this in the constructor
        protected String textureCSV; //set this to contain the name of all textures
        protected String soundCSV; //set this to contain the name of all sounds

        //Buttons - rename these how you wish
        Button button1;
        Button button2;
        Sprite sprite1;
        Sprite sprite2;

        //We initialise stuff here
        public MiniGame()
        {
            
            

        }

        protected void initialiseStuff()
        {
            textures = new Textures();
            //Pass in a comma separated list of texture names. You only need the asset name.
            textures.loadTextures(miniGameName, textureCSV.Split(','));

            sm = new SoundManager();
            //Pass in a comma separated list of sound names. You only need the asset name.           
            sm.loadSound(miniGameName, soundCSV.Split(','));

            gameOver = false;
        }
    

        public virtual void update(GameTime gameTime)
        {
            //UPDATE LOGIC GOES HERE
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            //DRAW LOGIC GOES HERE
        }

        // /\/\/\/\/\/\/\/\/\/\/\/\ EVENT HANDLERS /\/\/\/\/\/\/\/\/\/\/\
        // Make your buttons do shiz
        // 
        // /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
        private void button1_Clicked(object sender, EventArgs e)
        {
            //WHAT'S BUTTON1 GONNADO?
        }

        private void button2_Clicked(object sender, EventArgs e)
        {
            //WHAT'S BUTTON2 GONNADO?
        }

        // /\/\/\/\/\/\/\/\/\/\ END OF EVENT HANDLERS /\/\/\/\/\/\/\/\/\/\
        // /\ Make your buttons do shiz
        // /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
    }
}
