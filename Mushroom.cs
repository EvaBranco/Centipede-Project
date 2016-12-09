using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centipede
{
    class Mushroom
    {
        Rectangle mushR;

        public Mushroom()
           {

            mushR = new Rectangle(450, 450, 10, 10);
          }

        public Rectangle getRect()
        { return mushR; }

        public void block(playerR, flag)
        { flag = playerR.Intersects(mushR);

            if (!flag)
            {
                playerR.X += 5;
                playerR.Y += 5;
            }
        }
}
}
