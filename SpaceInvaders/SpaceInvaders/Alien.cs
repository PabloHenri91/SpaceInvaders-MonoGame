using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hydra.SpaceInvaders
{
    class Alien : SKSpriteNode
    {
        internal static List<Alien> list = new List<Alien>();

        static float speedX = 1;
        static int speedY;

        public Alien() : base("alien")
        {
            list.Add(this);
        }

        internal override void removeFromParent()
        {
            base.removeFromParent();
            list.Remove(this);
        }

        internal static void updateAll()
        {
            for (int a = list.Count - 1; a >= 0; a--)
            {
                var alien = list[a];

                for (int s = Shot.list.Count - 1; s >= 0; s--)
                {
                    var shot = Shot.list[s];

                    if ((shot.position - alien.position).LengthSquared() < 32 * 32)
                    {
                        alien.explosionEffect();
                        alien.removeFromParent();
                        shot.removeFromParent();
                        break;
                    }
                }
            }

            foreach (var alien in list)
            {
                if (Math.Abs(speedX) > 0.1)
                {
                    if (speedX > 0)
                    {
                        if (alien.position.X > SKScene.defaultSize.X / 2)
                        {
                            speedX *= -1.1f;
                            speedY = 1;
                            break;
                        }
                    }
                    else
                    {
                        if (alien.position.X < -SKScene.defaultSize.X / 2)
                        {
                            speedX *= -1.1f;
                            speedY = 1;
                            break;
                        }
                    }
                }

            }

            foreach (var alien in list)
            {
                alien.update();
            }

            speedY = 0;
        }

        internal void update()
        {
            position.X += speedX;
            position.Y += speedY * 10;
        }

        void explosionEffect()
        {
            SKEmitterNode emitterNode = new SKEmitterNode();

            emitterNode.numParticlesToEmit = 100;
            emitterNode.particleBirthRate = 12000;
            emitterNode.scale = new Vector2(0.5f, 0.5f);
            emitterNode.particleLifetime = 1;
            emitterNode.particleAlpha = 1;
            emitterNode.particleAlphaSpeed = -1;
            emitterNode.particleScaleSpeed = -1;
            emitterNode.particleColorBlendFactor = 1;
            emitterNode.color = new Color(1.0f, 0.5f, 0.25f, 0.5f);

            emitterNode.particleSpeed = 500.0f;
            emitterNode.particleSpeedRange = 1000.0f;
            emitterNode.emissionAngleRange = MathHelper.ToRadians(360);

            emitterNode.blendState = BlendState.Additive;

            emitterNode.position = position;
            parent.addChild(emitterNode);
        }
    }
}
