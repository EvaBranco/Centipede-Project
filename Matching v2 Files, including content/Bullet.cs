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

public class Bullet
{
    //Instance Variables
    private Rectangle bullet;

    public Bullet(int spawnX, int spawnY)
	{
        bullet = new Rectangle(spawnX, spawnY, 5, 10);
    }

    public Rectangle getRect()
    {
        return bullet;
    }

    public void changeRect(Rectangle other)
    {
        {
            int y = 5;
            if (bullet.Intersects(other))
                y = 0;
            bullet.Y -= y;
        }
    }

}
