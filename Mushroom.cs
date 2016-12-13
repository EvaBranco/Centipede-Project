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
       
        public String damaged(Rectangle bullet)
        {
            if(bullet.Intersects(mushR))
                damageCounter++;
            if(damageCounter==3)
                return "destroyed";
            return "safe";
        }
        
        }
    }
}
