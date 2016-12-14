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
    class Mushroom
    {
        Rectangle mushR;
        int damageCounter;
        private int screenWidth;
        private int screenHeight;
        private Random randX;
        private Random randY;
        private int randX1;
        private int randY1;


        public Mushroom(int height, int width)
        {
            damageCounter = 0;
            randX = new Random();
            randY = new Random();
            screenHeight = height;
            screenWidth = width;
            randX1 = randX.Next(0, screenWidth);
            randY1 = randY.Next(0, screenWidth);
            mushR = new Rectangle(450, 450, 10, 10);
        }

        public Rectangle getRect()
        {
            mushR = new Rectangle(randX1, randY1, 10, 10);
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

