using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace Hydra.SpaceInvaders
{
    class Ship : SKSpriteNode
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
                if (SKScene.currentTime - lastShot >= 0.2f)
                {
                    lastShot = SKScene.currentTime;
                    parent.addChild(new Shot(this));
                }
            }
        }

        internal void touchMoved(Touch touch)
        {
            var x = touch.locationIn(parent).X;

            if (x > SKScene.defaultSize.X / 2.0f)
            {
                x = SKScene.defaultSize.X / 2.0f;
            }
            else
            {
                if (x < -SKScene.defaultSize.X / 2.0f)
                {
                    x = -SKScene.defaultSize.X / 2.0f;
                }
            }

            position = Vector2.Lerp(position, new Vector2(x, position.Y), 0.1f);
        }
    }
}
