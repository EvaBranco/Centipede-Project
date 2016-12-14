using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Merged_cs_v1_Compilable
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

        public Rectangle getRect(Rectangle mushR)
        {
            return mushR;
        }

        /// <summary>
        ///  actual code for centipede movement. moves left to right until it hits an obstacle or a wall,
        ///  and then goes down one level and heads in the opposite direction.
        /// </summary>
        public void movement(Rectangle cageL, Rectangle cageR, Rectangle mushR)
        {
            if (centiR.Intersects(cageL))
               {
                 Cspeedx *= -1;
                 Cspeedy -= 1;
               }
            if (centiR.Intersects(cageR))
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
