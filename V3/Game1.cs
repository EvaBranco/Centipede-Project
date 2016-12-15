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

namespace Merged_cs_v1_Compilable
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //use the font
        SpriteFont font1;
        //stop transfer
        Texture2D playerTex;
        Rectangle playerRect;

        Rectangle bottom;
        Rectangle top;
        Rectangle left;
        Rectangle right;

        int playerSpeedX;
        int playerSpeedY;
        //use from below in main code

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


        Random rand;
        Random rand1;
        int timer = 600;

        KeyboardState oldKB;

        int screenWidth = 1;
        int screenHeight = 1;

        //Player Sprites
        Rectangle playerR;
        Texture2D player;

        //Centipede Sprites
        Rectangle centiR;
        Texture2D centi;


        // Cage Rectangle
        Rectangle cageR;

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

        int mushNum;

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

            oldKB = Keyboard.GetState();

            rand = new Random();
            rand1 = new Random();

            playerR = new Rectangle(500, 500, 20, 20);
            centiR = new Rectangle(100, 500, 50, 50);


            //Bullet Object Instantiation
            bList = new List<Bullet>();
            bulletNum = 0;

            //Spider Object Instantiation
            sList = new List<Spider>();
            
            //Mushroom Object Instantiation
            mList = new List<Mushroom>();

            flag = false;

            timer += rand.Next(120);

            bottom = new Rectangle(0, screenHeight, screenWidth, 0);

            top = new Rectangle(0, 0, screenWidth, 0);

            left = new Rectangle(800, 0, 0, screenHeight);

            right = new Rectangle(0, 0, 0, screenHeight);

            //Cage Object Instantiation
            Rectangle cageR = new Rectangle(150,150,150,150);

            //use from below in main code
            nowString1 = "" + score1;

            score1 = 0;

            lives = 3;

            X = (int)GameState.start;

            mushNum = 0;

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
            //playerTex = Content.Load<Texture2D>("Spider");
            font1 = Content.Load<SpriteFont>("SpriteFont1");
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
            if (playerHit == true && lives >= 0)
            {
                X = (int)GameState.gameOver;
            }


            // Start page code
            if (X == (int)GameState.start)
            {
                nowString1 = "CENTIPEDE \n\n\n\n By: \n Kenny \n Mykala \n Eva \n Press Q to play";
                playerR = new Rectangle(500, 500, 20, 20);
            }
            // code to start game
            if (kb.IsKeyDown(Keys.Q) && X == (int)GameState.start)
            {
                X = (int)GameState.play;
                playerR = new Rectangle(200, 200, 20, 20);
                nowString1 = " " + score1;
            }

            if (kb.IsKeyDown(Keys.E) && X == (int)GameState.play)
            {
                X = (int)GameState.gameOver;
            }



            // Play game code, ALL CENTIPEDE CODE GOES IN HERE  
            if (X == (int)GameState.play)
            {

                //Spider Spawn Logic
                timer--;
                if (timer == 0)
                    sList.Add(new Spider(800, 800));
                else if (sList.Count == 0 && timer == 0)
                    timer = 600 + rand.Next(120);
                if(timer == 0)
                    timer = 600 + rand.Next(120);

                // Mushroom Spawn Logic
                if (timer<600 && mushNum<= 100)
                {
                    mList.Add(new Mushroom());
                    mushNum++;
                }


                //Bullet Damages
                foreach (Spider spider in sList)
                {
                    foreach (Bullet bullet in bList)
                    {
                        if (spider.getRect().Intersects(bullet.getRect()))
                            sList.RemoveAt(sList.Count-sList.Count);
                    }
                }
                int getRid = 0;
                /*foreach (Mushroom mush in mList)
                {
                    switch (mush.damaged())
                    {
                        case "destroyed": mList.RemoveAt(getRid); break;
                        case "damaged: break;
                        case "safe": break;
                    }
                    getRid++;
                }*/

                //Mushroom Blocks Player
                foreach (Mushroom mushR in mList)
                {
                    if (playerR.Intersects(mushR.getRect()))
                        flag = true;
                    else
                        flag = false;
                }

                if (flag == true)
                {
                    playerR.X -= 5;
                    playerR.Y -= 5;
                }

                //ADD SPIDER KILLS PLAYER LOGIC

                //this adds a new Bullet object for every time the Space button is pressed
                if (kb.IsKeyDown(Keys.Space) && !oldKB.IsKeyDown(Keys.Space))
                {
                    bList.Add(new Bullet(playerR.X, playerR.Y));
                    bulletNum++;
                }
                if (bulletNum >= 15)
                {
                    for (int p = 1; p < 15; p++)
                    {
                        bList.RemoveAt(bulletNum - 15);
                    }
                        bulletNum = 0;
                }

                //this one makes sure that every bullet object is moving until it hits the top
                //this needs to be edited so that it stops after it encounters an object
                foreach (Bullet bullet in bList)
                    bullet.changeRect(top);

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
                if (kb.IsKeyDown(Keys.W) && !playerR.Intersects(top))
                {
                    playerR.Y -= 3;

                }
                if (kb.IsKeyDown(Keys.S) && !playerR.Intersects(bottom))
                {
                    playerR.Y += 3;

                }

                if (kb.IsKeyDown(Keys.A) && !playerR.Intersects(right))
                {
                    playerR.X -= 3;

                }
                if (kb.IsKeyDown(Keys.D) && !playerR.Intersects(left))
                {
                    playerR.X += 3;

                }
            }
            //gameover code
            if (X == (int)GameState.gameOver)
            {
                nowString1 = " GAME OVER \n PRESS W TO RETURN TO THE START MENU";
                playerR = new Rectangle(0, 0, 0, 0);

            }
            if (kb.IsKeyDown(Keys.W) && X == (int)GameState.gameOver)
            {
                X = (int)GameState.start;
            }

            //=======================================================================================
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
            //use drawstring 
            //this foreach loop draws every bullet contained in bList       
            spriteBatch.DrawString(font1, nowString1, new Vector2(250, 50), Color.White);

            foreach (Bullet bullet in bList)
            {
                spriteBatch.Draw(bulletText, bullet.getRect(), Color.White);
            }
            foreach (Spider spiderR in sList)
            {
                spriteBatch.Draw(spider, spiderR.getRect(), Color.White);
            }
            
            spriteBatch.Draw(centi, centiR, Color.White);
            foreach (Mushroom mushR in mList)
            {
                spriteBatch.Draw(mush, mushR.getRect(), Color.White);
            }
            
            //ignore rest of code
            //spriteBatch.Draw(playerTex, playerRect, Color.White);
            //spriteBatch.Draw(spiderTex, spiderRect, Color.White);
            spriteBatch.Draw(player, playerR, Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}