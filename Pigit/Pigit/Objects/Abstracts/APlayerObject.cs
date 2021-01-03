using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using System;
using System.Collections.Generic;
using System.Text;

using Pigit.SpriteBuild.Enums;
using System.Diagnostics;
using Pigit.Attack;
using Pigit.Objects.Interfaces;
using Pigit.Text.PlayerTexts;
using Pigit.Text.Enums;
using Pigit.Global.Enums;

namespace Pigit.Objects.Abstracts
{
    abstract class APlayerObject : IPlayerObject
    {
        protected double timer;
        protected bool isSetTimer;
        protected HeroText text;
        protected int beginHearts;
        protected int beginAttackDamage;
        private int hearts;
        protected Dictionary<AnimatieTypes, SpriteDefine> sprites;
        protected SpriteDefine currentSprite;
        protected AnimatieTypes type;

        public int Points { get; set; }
        public Rectangle Rectangle { get; protected set; }
        public bool Direction { get; set; }
        public Vector2 Positie { get; set; }
        public Vector2 Velocity { get; set; }
        public int Hearts { get { return hearts; } set { hearts = value; if (hearts < 0) hearts = 0; } }
        public int AttackDamage { get; private set; }
        public bool Dead { get; private set; }
        public bool IsHit { get; set; }
        public bool IsAttacking { get; set; }
        public bool HasAttacked { get; private set; }
        public AttackCommand Attack { get; private set; }

        public APlayerObject(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition, Dictionary<TextTypes, SpriteFont> spriteFonts, int hearts = 10, int attackDamage = 1)
        {
            beginHearts = hearts;
            beginAttackDamage = attackDamage;
            text = new HeroText(spriteFonts);
            Attack = new AttackCommand();
            Hearts = hearts;
            AttackDamage = attackDamage;
            sprites = spriteOpbouw;
            Positie = beginPosition;
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
                else
                {
                    sprites.Value.AnimatieL.Counter = 0;
                    sprites.Value.AnimatieR.Counter = 0;
                }
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            CheckSprites();

            if (type == AnimatieTypes.Dead)
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
            else
            {
                if (Points > 100)
                {
                    AttackDamage = beginAttackDamage * Points / 100;
                }

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

                if (type ==  AnimatieTypes.Attack)
                {
                    if (currentSprite.AnimatieL.Counter == currentSprite.AmountFrames - 1)
                    {
                        HasAttacked = true;
                    }
                }

                Positie += Velocity;
                RectBuild();
                currentSprite.Update(gameTime);
            }

            if (Dead && Game1.currGameState == GameLoop.Play)
            {
                Game1.currGameState = GameLoop.Dead;
                Positie = new Vector2(Game1.ScreenWidth, Game1.ScreenHeight);
            }
        }

        private void CheckSprites()
        {
            if (Velocity.X < 0 || Velocity.X > 0)
            {
                type = AnimatieTypes.Run;
            }
            else
            {
                type = AnimatieTypes.Idle;
            }

            if (IsAttacking && !HasAttacked)
            {
                type = AnimatieTypes.Attack;

            }
            else if(!IsAttacking && HasAttacked)
            {
                HasAttacked = false;
            }

            if (Velocity.Y < 0)
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

        protected virtual void RectBuild()
        {
            Rectangle = new Rectangle((int)Positie.X, (int)Positie.Y, currentSprite.AnimatieL.CurrentFrame.SourceRect.Width, currentSprite.AnimatieL.CurrentFrame.SourceRect.Height);
        }
        public virtual void Draw(SpriteBatch _spriteBatch)
        {
                Texture2D tempTexture = null;

                if (!Direction)
                {
                    tempTexture = currentSprite.TextureR;
                }
                else
                {
                    tempTexture = currentSprite.TextureL;
                }

                _spriteBatch.Draw(tempTexture, Positie, currentSprite.AnimatieL.CurrentFrame.SourceRect, Color.White);

                text.Draw(_spriteBatch);
        }

        public virtual void Reset()
        {
            Hearts = beginHearts;
            AttackDamage = beginAttackDamage;
            Points = 0;
            Dead = false;
        }
    }
}
