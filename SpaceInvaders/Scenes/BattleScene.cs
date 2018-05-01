using System;
using System.Collections.Generic;
using System.Text;

using Hydra.SpaceInvaders;

using Microsoft.Xna.Framework;

namespace Hydra.Scenes
{
    class BattleScene : SKScene
    {
        Ship ship;

		internal override void load()
		{
		    base.load();

		    camera = new CameraNode();
		    gameWorld.addChild(camera);

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
		    camera.position = Vector2.Lerp(camera.position, Vector2.Zero, 0.1f);

		    ship.update();
		    Shot.updateAll();
		    Alien.updateAll();
		}

		internal override void touchMoved(Touch touch)
		{
		    base.touchMoved(touch);
		    ship.touchMoved(touch);
		}
	}
}
