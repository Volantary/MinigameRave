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
    public class simpleAddition : MiniGame
    {

        //Buttons - rename these how you wish
        Button option1;
        Button option2;
        Button option3;

        //Numbers to add together
        int firstNumber;
        int secondNumber;
        int firstOption;
        int secondOption;
        int thirdOption;
        int answer;
        int position;
        int randomNumber;
        string stringToDraw;


        //We initialise stuff here
        public simpleAddition() : base()
        {
            miniGameName = "simpleAddition";
            textureCSV = "mathsButton";
            soundCSV = "";

            initialiseStuff(); 

            //Initialise a load of buttons here
            option1 = new Button(textures.getTexture(0), new Vector2(200, 200));
            option1.Clicked += new EventHandler(option1_Clicked);

            option2 = new Button(textures.getTexture(0), new Vector2(400, 200));
            option2.Clicked += new EventHandler(option2_Clicked);

            option3 = new Button(textures.getTexture(0), new Vector2(600, 200));
            option3.Clicked += new EventHandler(option3_Clicked);

            //Set what we should be adding together
            Random random = new Random(); 
            firstNumber = random.Next(1, 11);
            secondNumber = random.Next(1, 11);
            answer = firstNumber + secondNumber;

            //Set the options
            random = new Random();
            position = random.Next(1, 4);
            if (position == 1)
            {
                firstOption = answer;

                //Probably a more elegant way to do this, but ensures each possible answer looks random
                randomNumber = random.Next();
                if (randomNumber % 2 == 0)
                {
                    secondOption = answer - random.Next(1, 3);
                    
                }
                else
                {
                    secondOption = answer + random.Next(1, 3);
                }
                randomNumber = random.Next();
                do
                {
                    if (randomNumber % 2 == 0)
                    {
                        thirdOption = answer + random.Next(1, 3);

                    }
                    else
                    {
                        thirdOption = answer - random.Next(1, 3);
                    }
                } while (thirdOption == answer || thirdOption == secondOption);

            }
            else if (position == 2)
            {
                secondOption = answer;
                randomNumber = random.Next();
                if (randomNumber % 2 == 0)
                {
                    firstOption = answer - random.Next(1, 3);

                }
                else
                {
                    firstOption = answer + random.Next(1, 3);
                }

                randomNumber = random.Next();
                do
                {
                    if (randomNumber % 2 == 0)
                    {
                        thirdOption = answer + random.Next(1, 3);

                    }
                    else
                    {
                        thirdOption = answer - random.Next(1, 3);
                    }
                } while (thirdOption == answer || thirdOption == firstOption);
            }
            else
            {
                thirdOption = answer;
                if (randomNumber % 2 == 0)
                {
                    secondOption = answer - random.Next(1, 3);

                }
                else
                {
                    secondOption = answer + random.Next(1, 3);
                }

                randomNumber = random.Next();
                do
                {
                    if (randomNumber % 2 == 0)
                    {
                        firstOption = answer + random.Next(1, 3);

                    }
                    else
                    {
                        firstOption = answer - random.Next(1, 3);
                    }
                } while (firstOption == answer || firstOption == thirdOption);
            }

            stringToDraw = "What is " + firstNumber.ToString() + " + " + secondNumber.ToString() + " ? ";
        }

        public override void update(GameTime gameTime)
        {
            option1.Update(gameTime);
            option2.Update(gameTime);
            option3.Update(gameTime);
            base.update(gameTime);
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(globals.globalFont, stringToDraw, new Vector2(275, 100), Color.White); 
            option1.Draw(spriteBatch);
            spriteBatch.DrawString(globals.globalFont, firstOption.ToString(), new Vector2(240, 240), Color.Black); 
            option2.Draw(spriteBatch);
            spriteBatch.DrawString(globals.globalFont, secondOption.ToString(), new Vector2(440, 240), Color.Black); 
            option3.Draw(spriteBatch);
            spriteBatch.DrawString(globals.globalFont, thirdOption.ToString(), new Vector2(640, 240), Color.Black);
            base.draw(spriteBatch);
        }

        // /\/\/\/\/\/\/\/\/\/\/\/\ EVENT HANDLERS /\/\/\/\/\/\/\/\/\/\/\
        // Make your buttons do shiz
        // 
        // /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
        private void option1_Clicked(object sender, EventArgs e)
        {
            gameOver = true;

            if (firstOption == answer)
            {             
                success = true;
            }
            else
            {
                success = false;
            }
        }

        private void option2_Clicked(object sender, EventArgs e)
        {
            gameOver = true;

            if (secondOption == answer)
            {
                success = true;
            }
            else
            {
                success = false;
            }
        }

        private void option3_Clicked(object sender, EventArgs e)
        {
            gameOver = true;

            if (thirdOption == answer)
            {
                success = true;
            }
            else
            {
                success = false;
            }
        }

        // /\/\/\/\/\/\/\/\/\/\ END OF EVENT HANDLERS /\/\/\/\/\/\/\/\/\/\
        // /\ Make your buttons do shiz
        // /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
    }
}
