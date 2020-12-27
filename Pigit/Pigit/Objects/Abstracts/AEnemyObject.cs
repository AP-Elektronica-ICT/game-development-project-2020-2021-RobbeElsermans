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
        private int hearts;
        public int Hearts { get { return hearts; } set { hearts = value; if (hearts < 0) hearts = 0; } }
        public int AttackDamage { get; set; }

        public bool Dead { get; protected set; }
        public bool IsHit { get; set; }
        public bool IsAttacking { get; set; }
        public AttackCommand Attack { get; set; }

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
            foreach (var sprites in Sprites)
            {
                if (sprites.Key == Type)
                {
                    CurrentSprite = sprites.Value;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            CheckSprites();

            if (Type == AnimatieTypes.Hit)
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

            if (Type != AnimatieTypes.Dead)
            {
                Positie += Velocity;
                RectBuild();
                CurrentSprite.Update(gameTime);
            }
            else
            {
                if (CurrentSprite.AnimatieL.Counter == CurrentSprite.AmountFrames - 1)
                {
                    Dead = true;
                }
                else
                {
                    CurrentSprite.Update(gameTime);
                }
            }
        }

        protected override void CheckSprites()
        {
            if (Velocity.X < 0 || Velocity.X > 0)
            {
                Type = AnimatieTypes.Run;
            }
            else
            {
                Type = AnimatieTypes.Idle;
            }
            if (IsAttacking)
            {
                Type = AnimatieTypes.Attack;
            }

            if (Velocity.Y + 0.2f < 0)
            {
                Type = AnimatieTypes.Jump;
            }
            if (Velocity.Y - 0.2f > 0)
            {
                Type = AnimatieTypes.Fall;
            }
            CheckAttack();
            CheckType();
        }

        private void CheckAttack()
        {
            if (IsHit)
            {
                Type = AnimatieTypes.Hit;
            }
            if (Hearts <= 0)
            {
                Type = AnimatieTypes.Dead;
            }
        }
    }
}
