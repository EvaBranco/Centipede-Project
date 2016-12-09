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
        {
            return mushR; 
        }

        //Need to be moved to main code
        //public void block(Rectangle playerR, Bool flag)
        //{ 
          //  if(playerR.Intersects(mushR))
            //   flag=true;
            //else
              //  flag=false;
            
           // if (!flag)
            //{
              //  playerR.X += 5;
                //playerR.Y += 5;
            //}
        }
    }
}
