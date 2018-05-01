using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace Hydra.SpaceInvaders
{
    class Shot : SKSpriteNode
    {
        internal static List<Shot> list = new List<Shot>();

        Ship shooter;

        float rangeSquared = 320 * 320;
        double speed = 5;
        Vector2 startingPosition;

        public Shot(Ship shooter) : base("shot")
        {
            this.shooter = shooter;
            position = shooter.position;
            startingPosition = position;
            zRotation = shooter.zRotation;
            list.Add(this);
            shooter.canShoot = false;
        }

        internal override void removeFromParent()
        {
            base.removeFromParent();
            list.Remove(this);
            shooter.canShoot = true;
        }

        internal void update()
        {
            if ((position - startingPosition).LengthSquared() > rangeSquared)
            {
                removeFromParent();
            }
            else
            {
                position = position - new Vector2((float)(-Math.Sin(zRotation) * speed), (float)(Math.Cos(zRotation) * speed));
            }
        }

        internal static void updateAll()
        {
            for (int s = list.Count - 1; s >= 0; s--)
            {
                list[s].update();
            }
        }
    }
}
