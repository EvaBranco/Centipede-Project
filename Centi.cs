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
        int screenWidth = 1;
        int screenHeight = 1;
        int Cspeedx = 5;
        int Cspeedy = 0;

        //centipede rect.
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
        public void movement(Rectangle cageL, cageR, mushR)
        {
            if (centiR.Intersects(cageL)
               {
                 Cspeedx *= -1;
                 Cspeedy -= 1;
               }
            if (centiR.Intersects(cageR)
               { Cspeedx *= -1;
                Cspeedy -= 1;
               }
            if (centiR.Intersects(mushR))
            {
                Cspeedx *= -1;
                Cspeedy -= 1;
            }
        }

    }
}
