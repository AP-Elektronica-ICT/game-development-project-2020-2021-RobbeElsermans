using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Attack;
using Pigit.Objects.Interfaces;
using Pigit.SpriteBuild.Enums;
using Pigit.Text.Enums;
using Pigit.Text.PlayerTexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects.Abstracts
{
    class ANPCObject: INPCObject
    {
        protected double timer;
        protected bool isSetTimer;
        protected HeroText text;
        protected int beginHearts;
        protected int beginAttackDamage;

        public Rectangle Rectangle { get; set; }
        public bool Direction { get; set; }
        public Vector2 Positie { get; set; }
        public Vector2 Velocity { get; set; }
        public AnimatieTypes Type { get; set; }
        private int hearts;
        public int Hearts { get { return hearts; } set { hearts = value; if (hearts < 0) hearts = 0; } }
        public int AttackDamage { get; set; }
        public Dictionary<AnimatieTypes, SpriteDefine> Sprites { get; set; }
        public SpriteDefine CurrentSprite { get; private set; }
        public bool Dead { get; protected set; }
        public bool IsHit { get; set; }
        public bool IsAttacking { get; set; }
        public AttackCommand Attack { get; set; }

        public ANPCObject(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition, Dictionary<TextTypes, SpriteFont> spriteFonts, int hearts = 10, int attackDamage = 1)
        {
            beginHearts = hearts;
            beginAttackDamage = attackDamage;
            text = new HeroText(spriteFonts);
            Attack = new AttackCommand();
            Hearts = hearts;
            AttackDamage = attackDamage;
            Sprites = spriteOpbouw;
            Positie = beginPosition;
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
        //private void Move(Vector2 verplaatsing)
        //{
        //    Positie += verplaatsing;
        //    Positie += Versnelling;
        //}
        //private Vector2 limit(Vector2 v, float max)
        //{
        //    if (v.Length() > max)
        //    {
        //        var ratio = max / v.Length();
        //        v.X *= ratio;
        //        v.Y *= ratio;
        //    }
        //    return v;
        //}
        public virtual void Update(GameTime gameTime)
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

        private void CheckSprites()
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

        protected virtual void RectBuild()
        {
            Rectangle = new Rectangle((int)Positie.X, (int)Positie.Y, CurrentSprite.AnimatieL.CurrentFrame.SourceRect.Width, CurrentSprite.AnimatieL.CurrentFrame.SourceRect.Height);
        }
        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            Texture2D tempTexture = null;

            if (!Direction)
            {
                tempTexture = CurrentSprite.TextureR;
            }
            else
            {
                tempTexture = CurrentSprite.TextureL;
            }

            _spriteBatch.Draw(tempTexture, Positie, CurrentSprite.AnimatieL.CurrentFrame.SourceRect, Color.White);

            text.Draw(_spriteBatch);
        }
    }
}
