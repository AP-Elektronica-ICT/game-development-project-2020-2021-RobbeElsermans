using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Attack;
using Pigit.Global.Enums;
using Pigit.Movement;
using Pigit.Objects.Interfaces;
using Pigit.SpriteBuild.Enums;
using Pigit.Text.Enums;
using Pigit.Text.PlayerTexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects.Abstracts
{
    abstract class AEnemyObject : ANPCObject, IAttacker, IAttackAble
    {
        protected int hearts;
        public int Hearts { get { return hearts; } set { hearts = value; if (hearts < 0) hearts = 0; } }
        public int AttackDamage { get; protected set; }

        public bool Dead { get; protected set; }
        public bool IsHit { get; set; }
        public bool IsAttacking { get; set; }
        public AttackCommand Attack { get; protected set; }

        public AEnemyObject(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition, Dictionary<TextTypes, SpriteFont> spriteFonts, int hearts, int attackDamage, MoveTypes moveTypes): base(spriteOpbouw, beginPosition,spriteFonts, moveTypes)
        {
            beginHearts = hearts;
            beginAttackDamage = attackDamage;
            Attack = new AttackCommand();
            Hearts = hearts;
            AttackDamage = attackDamage;
            CheckSprites();
        }
        private void CheckType()
        {
            foreach (var sprites in sprites)
            {
                if (sprites.Key == type)
                {
                    currentSprite = sprites.Value;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            type = AnimatieTypes.Idle;
            CheckSprites();

            if (type == AnimatieTypes.Hit)
            {
                if (!isSetTimer)
                {
                    timer = gameTime.TotalGameTime.TotalSeconds;
                    isSetTimer = true;
                }

                if ((gameTime.TotalGameTime.TotalSeconds - timer > 0.5))
                {
                    isSetTimer = false;
                    IsHit = false;
                }
            }

            if (type != AnimatieTypes.Dead)
            {
                Positie += Velocity;
                RectBuild();
                currentSprite.Update(gameTime);
            }
            else
            {
                if (currentSprite.AnimatieL.Counter == currentSprite.AmountFrames - 1)
                {
                    Dead = true;
                }
                else
                {
                    currentSprite.Update(gameTime);
                }
            }
        }

        protected override void CheckSprites()
        {
            if (Velocity.X < 0 || Velocity.X > 0)
            {
                type = AnimatieTypes.Run;
            }
            else
            {
                type = AnimatieTypes.Idle;
            }
            if (IsAttacking)
            {
                type = AnimatieTypes.Attack;
                IsAttacking = false;
            }

            if (Velocity.Y + 0.2f < 0)
            {
                type = AnimatieTypes.Jump;
            }
            if (Velocity.Y - 0.2f > 0)
            {
                type = AnimatieTypes.Fall;
            }
            CheckAttack();
            CheckType();
        }

        private void CheckAttack()
        {
            if (IsHit)
            {
                type = AnimatieTypes.Hit;
            }
            if (Hearts <= 0)
            {
                type = AnimatieTypes.Dead;
            }
        }
    }
}
