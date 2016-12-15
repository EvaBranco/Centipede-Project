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
    class Spider
    {
        //Instance Vriables
        private Rectangle spiderR;
        private int screenWidth;
        private int screenHeight;
        private int bugspeedx;
        private int bugspeedy;
        private Rectangle cageT;
        private Rectangle cageB;
        private Rectangle cageL;
        private Rectangle cageR;
        private Random X;
        private Random Y;
        int X1;
        int Y1;
        static Random random = new Random();

        public Spider(int height, int width)
        {

            X = new Random();
            Y = new Random();
            X1 = X.Next(400);
           // Console.WriteLine("x1:" + X1);
            Y = new Random();
            Y1 = Y.Next(400);
           // Console.WriteLine("y1:" + Y1);

            // Console.WriteLine("x1:" + X1);
            //Console.WriteLine("y1:" + Y1);
            spiderR = new Rectangle(X1, Y1, 30, 30);
            bugspeedy = 5;
            bugspeedx = 5;
            screenHeight = height;
            screenWidth = width;
            cageT = new Rectangle(0, screenHeight / 4, screenWidth, 5);
            cageB = new Rectangle(0, screenHeight, screenWidth, 0);
            cageR = new Rectangle(0, 0, 0, screenHeight);
            cageL = new Rectangle(800, 0, 0, screenHeight);

            movement();

        }
    



        public Rectangle getRect()
        {
        
                
            return spiderR;
        }

        private void movement()
        {
            //Spider Movement
            spiderR.X += bugspeedx;
            spiderR.Y += bugspeedy;
            //Spider Constraints
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
            
        }
    }
}
