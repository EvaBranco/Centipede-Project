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

namespace Centipede
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font1;

        Texture2D playerTex;
        Rectangle playerRect;

        Rectangle bottom;
        Rectangle top;
        Rectangle left;
        Rectangle right;

        int playerSpeedX;
        int playerSpeedY;
//use from below in main code
        int screenWidth;
        int screenHeight;

        int lives;
        bool playerHit;

        int score1;
        string nowString1;
        int X;

        enum GameState : int
        {
            start = 1,
            play = 2,
            gameOver = 3
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            playerRect = new Rectangle(50, 50, 30, 30);

            screenWidth = graphics.GraphicsDevice.Viewport.Width;

            screenHeight = graphics.GraphicsDevice.Viewport.Height;

            bottom = new Rectangle(0, screenHeight, screenWidth, 0);

            top = new Rectangle(0, 0, screenWidth, 0);

            left = new Rectangle(800, 0, 0, screenHeight);

            right = new Rectangle(0, 0, 0, screenHeight);
//use from below in main code
            nowString1 = "" + score1;

            score1 = 0;

            lives = 3;

            X = (int)GameState.start;

            playerHit = false;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
//use the sprite font
            spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTex = Content.Load<Texture2D>("Spider");

            font1 = Content.Load<SpriteFont>("SpriteFont1");

            // TODO: use this.Content to load your game content here
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
        /// 

        protected override void Update(GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || kb.IsKeyDown(Keys.Escape))
                this.Exit();
            // TODO: Add your update logic here
            //<transfer to main code>
            
            //=======================================================================================
            // GAME STATE CODE
            //=======================================================================================

            // The game life code/damage
            if (playerHit == true && lives != 0)
            {
                lives -= 1;
            }
            if(playerHit == true && lives >= 0)
            {
               X = (int)GameState.gameOver;
            }


            // Start page code
            if(X == (int)GameState.start)
                {
                nowString1 = "CENTIPEDE \n\n\n\n By: \n Kenny \n Mykala \n Eva \n Press Q to play";
                playerRect = new Rectangle(0, 0, 0, 0);
            }
            // code to start game
            if (kb.IsKeyDown(Keys.Q) && X == (int)GameState.start)
            {
                X = (int)GameState.play;
                playerRect = new Rectangle(150, 150, 30, 30);
                nowString1 = " " + score1;
            }

            if (kb.IsKeyDown(Keys.E) && X == (int)GameState.play)
            {
                X = (int)GameState.gameOver;
            }



            // Play game code, ALL CENTIPEDE CODE GOES IN HERE  
            if (X == (int)GameState.play)
                {
                    


                    //=================SCORE CARD====================================================
                    //if(bullet.Intersects(centipedeRect))
                    //{
                    //    score1 += 100;
                    //    nowString1 = "" + score1;
                    //}
                    //if(bullet.Intersects(spiderRect) && isSpiderDead == true)
                    //{
                    //    score1 += 500;
                    //    nowString1 = "" + score1;
                    //}
                    //==============================================================================

                    //===============MOVEMENT CODE==================================================
                    if (kb.IsKeyDown(Keys.Up) && !playerRect.Intersects(top))
                    {
                        playerRect.Y -= 3;

                    }
                    if (kb.IsKeyDown(Keys.Down) && !playerRect.Intersects(bottom))
                    {
                        playerRect.Y += 3;

                    }

                    if (kb.IsKeyDown(Keys.Left) && !playerRect.Intersects(right))
                    {
                        playerRect.X -= 3;

                    }
                    if (kb.IsKeyDown(Keys.Right) && !playerRect.Intersects(left))
                    {
                        playerRect.X += 3;

                    }
                }
            //gameover code
            if(X == (int)GameState.gameOver)
                {
                nowString1 = " GAME OVER \n PRESS W TO RETURN TO THE START MENU";
                playerRect = new Rectangle(0, 0, 0, 0);

            }
            if (kb.IsKeyDown(Keys.W) && X == (int)GameState.gameOver)
            {
                X = (int)GameState.start;
            }
            
            //=======================================================================================

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //use drawstring 
            spriteBatch.DrawString(font1, nowString1, new Vector2(250, 50), Color.White);
            //ignore rest of code
            spriteBatch.Draw(playerTex, playerRect, Color.White);
            //spriteBatch.Draw(spiderTex, spiderRect, Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
