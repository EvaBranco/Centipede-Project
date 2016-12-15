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
        private int cSpeedX = 5;
        private int cSpeedY = 0;

        //centipede constructor
        public Centi()
        {
            centiR = new Rectangle(0, 0, 50, 50);
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
