using System;
using System.Collections.Generic;
using System.Text;
using Dragon;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Scenes;

namespace Dragon
{
    class GameScene : DScene
    {
        public GameScene()
        {
            size = new Vector2(568, 320);
        }

        internal override void load()
        {
            base.load();
            DControl pressanykey = new DControl("pressanykey", 184, 123);
            pressanykey.setAlignment(HorizontalAlignment.center, VerticalAlignment.center);
            addChild(pressanykey);
        }

        internal override void touchUp(DTouch touch)
        {
            base.touchUp(touch);
            presentScene(new BattleScene());
        }
    }
}
