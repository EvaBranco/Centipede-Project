using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centipede
{
    class Mushroom
    {
        Rectangle mushR;
        int damageCounter;
        public Mushroom()
        {
            damageCounter = 0;
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
        public String damaged(Rectangle bullet)
        {
            if(bullet.Intersects(mushR))
            {
                damageCounter++;
                return "damaged";
            }
            if(damageCounter==3)
            {
                return "destroyed";
            }
            return "safe";
        }
        
        }
    }
}
