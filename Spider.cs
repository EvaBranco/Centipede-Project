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

        public Spider(int height, int width)
        {
            spiderR = new Rectangle(400, 100, 30, 30);
            bugspeedy = 5;
            bugspeedx = 5;
            screenHeight = height;
            screenWidth = width;
        }

        public Rectangle getRect()
        {
            return spiderR;
        }

        public void movement(Rectangle cageL, cageR, cageT, cageB)
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
