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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Random rand;
        
        int screenWidth = 1;
        int screenHeight = 1;
        int bugspeedx = 5;
        int bugspeedy = 5;
        int countdown = 30;

        Rectangle playerR;
        Texture2D player;
        Rectangle centiR;
        Texture2D centi;
        Rectangle spiderR;
        Texture2D spider;
        Rectangle mushR;
        Texture2D mush;
        Rectangle cageT;
        Rectangle cageB;
        Rectangle cageL;
        Rectangle cageR;
        Rectangle bulletR;

        bool flag;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screenWidth = graphics.GraphicsDevice.Viewport.Width;
            screenHeight = graphics.GraphicsDevice.Viewport.Height;

            playerR = new Rectangle(500, 500, 20, 20);
            centiR = new Rectangle(100, 500, 50, 50);
            spiderR = new Rectangle(400, 100, 30, 30);
            mushR = new Rectangle(450, 450, 10, 10);
            cageT = new Rectangle(0,screenHeight/4,screenWidth,5);
            cageB = new Rectangle(0, screenHeight, screenWidth, 0);
            cageR = new Rectangle(0, 0, 0, screenHeight);
            cageL = new Rectangle(800, 0, 0, screenHeight);
            bulletR = new Rectangle(500, 500, 10, 5);

            rand = new Random();

            flag = false;

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

            player = Content.Load<Texture2D>("playerCenti");
            centi = Content.Load<Texture2D>("centiCir");
            spider = Content.Load<Texture2D>("bug");
            mush = Content.Load<Texture2D>("blueBox");

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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            //int timer = countdown;
            
            //Bullet Damages
            if (spiderR.Intersects(bulletR))
            {
            }

            //Spider Movements
            spiderR.X += bugspeedx;
            spiderR.Y += bugspeedy;
            //Spider Constraints to bottom of screen
            if (spiderR.Intersects(cageL))
            {
                spiderR.X = screenWidth / 2;
            }
            if (spiderR.Intersects(cageR))
            {
                spiderR.X = screenWidth / 2;
            }
            if (spiderR.Intersects(cageB))
            {
                spiderR.Y *= -1;
            }
            if (spiderR.Intersects(cageT))
            {
                spiderR.X *= -1;
            }
            
            //Mushroom Blocks Player
            if(playerR.Intersects(mushR))
                flag = true;
            else
                flag = false; 
            if (!flag)
            {
                playerR.X += 5;
                playerR.Y += 5;
            }

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
            spriteBatch.Draw(player, playerR, Color.White);
            spriteBatch.Draw(centi, centiR, Color.White);
            spriteBatch.Draw(spider, spiderR, Color.White);
            spriteBatch.Draw(mush, mushR, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
