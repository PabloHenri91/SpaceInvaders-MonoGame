using System;
using System.Collections.Generic;
using System.Text;
using Dragon;
using Microsoft.Xna.Framework;

namespace SpaceInvaders
{
    class Shot : DSpriteNode
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
            rotation = shooter.rotation;
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
                position = position - new Vector2((float)(-Math.Sin(rotation) * speed), (float)(Math.Cos(rotation) * speed));
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
