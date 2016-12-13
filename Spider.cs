using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centipede
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
        

        public Spider(int height, int width)
        {
            spiderR = new Rectangle(400, 100, 30, 30);
            bugspeedy = 5;
            bugspeedx = 5;
            screenHeight = height;
            screenWidth = width;
            cageT = new Rectangle(0,screenHeight/4,screenWidth,5);
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
