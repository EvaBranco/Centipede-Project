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
        private Random X;
        private Random Y;
        private Random Z;
        int X1;
        int Y1;
        bool impact = false;
        public Mushroom()
        {
            damageCounter = 0;
            X = new Random();
            Y = new Random();
            X1 = X.Next(400);
            // Console.WriteLine("x1:" + X1);
            Y = new Random();
            Y1 = Y.Next(400);
            // Console.WriteLine("y1:" + Y1);

            // Console.WriteLine("x1:" + X1);
            //Console.WriteLine("y1:" + Y1);
            mushR = new Rectangle(X1, Y1, 10, 10);
            //mushR = new Rectangle(450, 450, 10, 10);
        }

        public Rectangle getRect()
        {
            return mushR; 
        }
       
        //public String damaged(Rectangle bullet)
        //{
            //if(bullet.Intersects(mushR))
            //    damageCounter++;
            //if(damageCounter==3)
            //    impact = true;
            //if(impact == true)
            //{
                
            //}
        //}
        
        }
    }

