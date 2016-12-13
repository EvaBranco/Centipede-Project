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
        
        KeyboardState oldKB;
        
        int screenWidth = 1;
        int screenHeight = 1;

        //Player Sprites
        Rectangle playerR;
        Texture2D player;
        //Centipede Sprites
        Rectangle centiR;
        Texture2D centi;
        //Spider Sprites
        Rectangle spiderR;
        Texture2D spider;
        //Mushroom Sprites
        Rectangle mushR;
        Texture2D mush;
        //Constraints for Spiders
        Rectangle cageT;
        Rectangle cageB;
        Rectangle cageL;
        Rectangle cageR;
        
        //Bullet Logic Instance Variables
        List<Bullet> list;
        Texture2D bulletText;
        int bulletNum;

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
            
            oldKB = Keyboard.GetState();
            
            rand = new Random();

            playerR = new Rectangle(500, 500, 20, 20);
            centiR = new Rectangle(100, 500, 50, 50);
            spiderR = new Rectangle(400, 100, 30, 30);
            mushR = new Rectangle(450, 450, 10, 10);
            cageT = new Rectangle(0,screenHeight/4,screenWidth,5);
            cageB = new Rectangle(0, screenHeight, screenWidth, 0);
            cageR = new Rectangle(0, 0, 0, screenHeight);
            cageL = new Rectangle(800, 0, 0, screenHeight);
            
            //Bullet Logic Instantiation
            list = new List<Bullet>();
            bulletNum = 0;
            
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
            
            bulletText = Content.Load<Texture2D>("White Square");

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || kb.IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            //int timer = countdown;
            
            //Bullet Damages
            if (spiderR.Intersects(bulletR))
            {
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

            //this adds a new Bullet object for every time the Space button is pressed
            if (kb.IsKeyDown(Keys.Space) && oldKB.IsKeyDown(Keys.Space))
            {
                list.Add(new Bullet( playerR.X, playerR.Y));
                bulletNum++;
            }
            if(bulletNum>=15)
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
            spriteBatch.Draw(player, playerR, Color.White);
            spriteBatch.Draw(centi, centiR, Color.White);
            spriteBatch.Draw(spider, spiderR, Color.White);
            spriteBatch.Draw(mush, mushR, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
