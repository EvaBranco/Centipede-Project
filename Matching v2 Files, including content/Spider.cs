using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private Random randX;
        private Random randY;
        private int randX1;
        private int randY1;

        public Spider(int height, int width)
        {
            randX = new Random();
            randY = new Random();
            spiderR = new Rectangle(400, 300, 30, 30);
            bugspeedy = 5;
            bugspeedx = 5;
            screenHeight = height;
            screenWidth = width;
            cageT = new Rectangle(0,screenHeight/4,screenWidth,5);
            cageB = new Rectangle(0, screenHeight, screenWidth, 0);
            cageR = new Rectangle(0, 0, 0, screenHeight);
            cageL = new Rectangle(800, 0, 0, screenHeight);
            randX1 = randX.Next(0, screenWidth);
            randY1 = randY.Next(0, screenWidth);

            movement();
        }

        public Rectangle getRect()
        {
            
            spiderR = new Rectangle(randX1, randY1, 30, 30);
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
