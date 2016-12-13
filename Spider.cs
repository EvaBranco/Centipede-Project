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
        int screenWidth = 1;
        int screenHeight = 1;
        int bugspeedx = 5;
        int bugspeedy = 5;

        public Spider()
        {
            spiderR = new Rectangle(400, 100, 30, 30);
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
