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

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        KeyboardState oldKB;
        List<Bullet> list;
        Texture2D bulletText;
        Rectangle top;
        int bulletNum;

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

            oldKB = Keyboard.GetState();
            list = new List<Bullet>();
            top = new Rectangle( 0,0,graphics.GraphicsDevice.Viewport.Width,1);
            bulletNum = 0;

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

            // TODO: use this.Content to load your game content here

            //loads in content for the bullet rectangles
            bulletText = Content.Load<Texture2D>("White Square");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || kb.IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            

            //this adds a new Bullet object for every time the Space button is pressed
            if (kb.IsKeyDown(Keys.Space) && oldKB.IsKeyDown(Keys.Space))
            {
                //list.Add(new Bullet( playerRectangle.X, playerRectangle.Y));
                bulletNum++;
            }
            if(bulletNum>15)
            {
                list.RemoveAt(bulletNum-15);
            }

            //this one makes sure that every bullet object is moving until it hits the top
            //this needs to be edited so that it stops after it encounters an object
            foreach (Bullet bullet in list)
                bullet.changeRect(top);

            oldKB = kb;

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
            //this foreach loop draws every bullet contained in List
            foreach (Bullet bullet in list)
            {
                spriteBatch.Draw(bulletText, bullet.getRect(), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
