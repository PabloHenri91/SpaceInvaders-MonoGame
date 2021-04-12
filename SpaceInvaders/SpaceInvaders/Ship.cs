using System;
using System.Collections.Generic;
using System.Text;
using Dragon;
using Microsoft.Xna.Framework;

namespace SpaceInvaders
{
    class Ship : DSpriteNode
    {
        internal bool canShoot = true;
        double lastShot;

        public Ship() : base("ship")
        {

        }

        internal void update()
        {
            if (canShoot)
            {
                if (DGame.current.currentTime - lastShot >= 0.2f)
                {
                    lastShot = DGame.current.currentTime;
                    parent.addChild(new Shot(this));
                }
            }
        }

        internal void touchMoved(DTouch touch)
        {
            var x = touch.locationIn(parent).X;

            if (x > DScene.current.size.X / 2.0f)
            {
                x = DScene.current.size.X / 2.0f;
            }
            else
            {
                if (x < -DScene.current.size.X / 2.0f)
                {
                    x = -DScene.current.size.X / 2.0f;
                }
            }

            position = Vector2.Lerp(position, new Vector2(x, position.Y), 0.1f);
        }
    }
}
