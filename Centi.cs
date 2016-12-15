using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centipede
{
    class Centi
    {
        //instance variables
        private Rectangle centiR;
        private int screenWidth;
        private int screenHeight;
        private int cSpeedX = 5;
        private int cSpeedY = 0;
        private Rectangle cageR;
        private Rectangle cageL;

        //centipede constructor
        public Centi(int height, int width)
        {
            centiR = new Rectangle(0, 0, 50, 50);
            screenHeight = height;
            screenWidth = width;
            cageR = new Rectangle(0, 0, 0, screenHeight);
            cageL = new Rectangle(800, 0, 0, screenHeight);
        }

        public Rectangle getRect()
        {
            return centiR;
        }

        /// <summary>
        ///  actual code for centipede movement. moves left to right until it hits an obstacle or a wall,
        ///  and then goes down one level and heads in the opposite direction.
        /// </summary>
        public void movement(Rectangle cageL, Rectangle cageR, Rectangle mushR)
        {
            if (centiR.Intersects(cageL)
            {
                cSpeedX *= -1;
                cSpeedY *= -1;
            }
            if (centiR.Intersects(cageR)
            { 
                cSpeedX *= -1;
                cSpeedY *= -1;
            }
            if (centiR.Intersects(mushR))
            {
                cSpeedX *= -1;
                cSpeedY *= -1;
            }
        }

    }
}
