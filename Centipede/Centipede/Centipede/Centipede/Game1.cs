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

        int screenWidth;
        int screenHeight;

        int score1;
        string nowString1;

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

            nowString1 = "" + score1;
            score1 = 0;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
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
        protected override void Update(GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || kb.IsKeyDown(Keys.Escape))
                this.Exit();
            // TODO: Add your update logic here
            
//=================SCORE CARD====================================================
            //if(bullet.Intersects(mushroomRect))
            //{
            //    score1 += 100;
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
//==============================================================================
            
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
            spriteBatch.DrawString(font1, nowString1, new Vector2(250, 50), Color.White);
            spriteBatch.Draw(playerTex, playerRect, Color.White);
            //spriteBatch.Draw(spiderTex, spiderRect, Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
