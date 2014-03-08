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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Button play, options, exit;
        Textures textures;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            globals.contentManager = this.Content;

            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            //Are we in debug mode?
            globals.debugMode = true;

            base.Initialize();

            //A constructor of sorts
            ScreenManager.initialise();
            GameManager.initialise(new simpleAddition());
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Set game time - Will be done through difficulty modes at some time
            globals.setGameLife(4);

            //Load background texture (Texture 0)
            textures = new Textures();
            textures.loadTexture("backgrounds", "titleScreen");

            //Load fonts
            globals.globalFont = Content.Load<SpriteFont>("fonts/globalFont");

           //Menu Buttons (might put these in a class one day, probably not!)
            play = new Button(Content.Load<Texture2D>("buttons/playButton"), new Vector2(50, 50));
            play.Clicked += new EventHandler(play_Clicked);

            options = new Button(Content.Load<Texture2D>("buttons/options"), new Vector2(150, 50));
            options.Clicked += new EventHandler(options_Clicked);

            exit = new Button(Content.Load<Texture2D>("buttons/exitButton"), new Vector2(250, 50));
            exit.Clicked += new EventHandler(exit_Clicked);

            //Sounds for titleScreen etc
            globals.soundEffect = Content.Load<SoundEffect>("sound/titleScreenMusic");
            globals.titleScreenMusic = globals.soundEffect.CreateInstance();
            globals.titleScreenMusic.IsLooped = true;
            globals.titleScreenMusic.Play();
            
        }

        //EVENT HANDLERS
        protected void play_Clicked(Object sender, EventArgs e)
        {
            ScreenManager.screen = 3;
        }

        protected void options_Clicked(Object sender, EventArgs e)
        {
            ScreenManager.screen = 2;
        }

        protected void exit_Clicked(Object sender, EventArgs e)
        {
            ScreenManager.screen = 9;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (ScreenManager.screen == 0)
            {
                //Title Screen
                play.Update(gameTime);
                options.Update(gameTime);
                exit.Update(gameTime);
            }

            if (ScreenManager.screen == 1)
            {
                //Main Menu
            }

            if (ScreenManager.screen == 2)
            {
                //Options Screen
            }

            if (ScreenManager.screen == 3)
            {
                GameManager.Update(gameTime);
            }

            if (ScreenManager.screen == 9)
            {
                //Game Over
                this.Exit();
            }



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Spritebatch begins here - no need to begin/end in individual draw functions
            spriteBatch.Begin();

            if (ScreenManager.screen == 0)
            {
                spriteBatch.Draw(textures.getTexture(0), new Vector2(0, 0), Color.White);
                play.Draw(spriteBatch);
                options.Draw(spriteBatch);
                exit.Draw(spriteBatch);
            }

            if (ScreenManager.screen == 1)
            {
                //Main Menu
            }

            if (ScreenManager.screen == 2)
            {
                //Options Screen
            }

            if (ScreenManager.screen == 3)
            {
                GameManager.Draw(spriteBatch);
            }

            if (ScreenManager.screen == 9)
            {
                //Game Over
            }


            base.Draw(gameTime);

            //Spritebatch ends here, no need to end it in indvididual draw functions
            spriteBatch.End();
        }
    }
}
