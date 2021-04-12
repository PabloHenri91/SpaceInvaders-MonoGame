using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Dragon;

namespace SpaceInvaders.Scenes
{
    class BattleScene : DScene
    {
        Ship ship;

        public BattleScene()
        {
            size = new Vector2(568, 320);
        }

        internal override void load()
        {
            base.load();

            DNode gameWorld = new DNode();
            gameWorld.position = new Vector2(size.X / 2.0f, size.Y / 2.0f);
            addChild(gameWorld);

            cameraNode = new DCameraNode();
            gameWorld.addChild(cameraNode);

            ship = new Ship
            {
                position = new Vector2(0, 148)
            };
            gameWorld.addChild(ship);

            for (int x = -4; x <= 4; x++)
            {
                for (int y = 0; y <= 5; y++)
                {
                    Alien alien = new Alien
                    {
                        position = new Vector2(43 * x, 29 * -y)
                    };
                    gameWorld.addChild(alien);
                }
            }
        }

        internal override void update()
        {
            base.update();
            cameraNode.position = Vector2.Lerp(cameraNode.position, Vector2.Zero, 0.1f);

            ship.update();
            Shot.updateAll();
            Alien.updateAll();
        }

        internal override void touchMoved(DTouch touch)
        {
            base.touchMoved(touch);
            ship.touchMoved(touch);
        }
    }
}
