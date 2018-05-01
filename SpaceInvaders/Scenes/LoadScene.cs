using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace Hydra.Scenes
{
    class GameScene : SKScene
    {
        ServerManager serverManager = new ServerManager("SpaceInvaders");

        public GameScene()
        {
            defaultSize = new Vector2(568, 320);
        }

        internal override void load()
        {
            base.load();
            Control pressanykey = new Control("pressanykey", 184, 123);
            pressanykey.setAlignment(HorizontalAlignment.center, VerticalAlignment.center);
            addChild(pressanykey);
        }

        internal override void update()
        {
            base.update();
        }

        internal override void touchUp(Touch touch)
        {
            base.touchUp(touch);
            presentScene(new BattleScene());
            serverManager.startAdvertisingPeer(); // Look for a server to connet
        }
    }
}
