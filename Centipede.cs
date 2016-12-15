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
        int timer = 600;
        
        KeyboardState oldKB;
        
        int screenWidth = 1;
        int screenHeight = 1;

        //Player Sprites
        Rectangle playerR;
        Texture2D player;
        
        //Centipede Object Instance Variables
        List<Centi> cList;
        Texture2D centi;
        int centiNum;
        
        //Spider Object Instance Variables
        List<Spider> sList;
        Texture2D spider;
        
        //Mushroom Object Instance Variables
        List<Mushroom> mList;
        Texture2D mush;
        
        //Bullet Onject Instance Variables
        List<Bullet> bList;
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
            
            //Centipede Instantiation
            cList = new List<Centi>();
            centiNum = 0;
            
            //Bullet Object Instantiation
            bList = new List<Bullet>();
            bulletNum = 0;
            
            //Spider Object Instantiation
            sList = new List<Spider>();
            
            //Mushroom Object Instantiation
            mList = new List<Mushroom>();
                
            flag = false;
            
            timer += rand.nextInt(120);


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
            
            //Spider Spawn Logic
            timer--;
            if(timer==0)
                sList.Add(new Spider(screenHeight,screenWidth));
            if(sList.Count==0)
                timer = 600 + rand.nextInt(120);
            //Mushroom Spawn Logic

            //Bullet Damages
            foreach(Spider spider in sList)
            {
                foreach(Bullet bullet in bList)
                {
                    if(spider.getRect().Intersects(bullet.getRect()))
                        sList.RemoveAt(0);
                }
            }
            
            int getRid = 0;
            foreach(Mushroom mush in mList)
            {
                switch(mush.damaged())
                {
                    case "destroyed": mList.RemoveAt(getRid); break;
                    case "damaged": break;
                    case "safe": break;
                }
                getRid++;
                if(getRid>mList.Count-1)
                    getRid=0;
            }
            
            //Mushroom Blocks Player
            foreach(Mushroom mushR in mList)
            {
                if(playerR.Intersects(mushR.getRect()))
                    flag = true;
                else
                    flag = false;
            }
            
            if (!flag)
            {
                playerR.X += 5;
                playerR.Y += 5;
            }

            //ADD SPIDER KILLS PLAYER LOGIC
            
            //this adds a new Bullet object for every time the Space button is pressed
            if (kb.IsKeyDown(Keys.Space) && oldKB.IsKeyDown(Keys.Space))
            {
                bList.Add(new Bullet( playerR.X, playerR.Y));
                bulletNum++;
            }
            if(bulletNum>=15)
            {
                bList.RemoveAt(bulletNum-15);
            }

            //this one makes sure that every bullet object is moving until it hits the top
            //this needs to be edited so that it stops after it encounters an object
            foreach (Bullet bullet in bList)
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
            //this foreach loop draws every bullet contained in bList
            foreach (Bullet bullet in bList)
            {
                spriteBatch.Draw(bulletText, bullet.getRect(), Color.White);
            }
            foreach (Spider spiderR in sList)
            {
                spriteBatch.Draw(spider, spiderR.getRect(), Color.White);
            }
            spriteBatch.Draw(player, playerR, Color.White);
            foreach(Centi centiR in cList)
            {
                spriteBatch.Draw(centi, centiR.getRect(), Color.White);
            }
            foreach(Mushroom mushR in mList)
            {
                spriteBatch.Draw(mush, mushR.getRect(), Color.White);
            }            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
