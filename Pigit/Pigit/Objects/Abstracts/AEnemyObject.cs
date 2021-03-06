﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Attack;
using Pigit.Movement.Enums;
using Pigit.Objects.Interfaces;
using Pigit.SpriteBuild.Enums;
using Pigit.SpriteBuild.Generator;
using Pigit.Text.Enums;
using System.Collections.Generic;

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

        public AEnemyObject(PigTypes pigType, SpriteGenerator sprites, Vector2 beginPosition, Dictionary<TextTypes, SpriteFont> spriteFonts, int hearts, int attackDamage, MoveTypes moveTypes): base(pigType,sprites, beginPosition,spriteFonts, moveTypes)
        {
            beginHearts = hearts;
            beginAttackDamage = attackDamage;
            Attack = new AttackCommand();
            Hearts = hearts;
            AttackDamage = attackDamage;
            CheckSprites();
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
            base.CheckType();
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
