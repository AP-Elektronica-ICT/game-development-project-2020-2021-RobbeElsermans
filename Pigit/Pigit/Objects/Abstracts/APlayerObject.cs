using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using System;
using System.Collections.Generic;
using System.Text;

using Pigit.Movement;
using Pigit.Objects;

using Microsoft.Xna.Framework.Content;
using Pigit.SpriteBuild;
using Pigit.SpriteBuild.Enums;
using System.Diagnostics;

namespace Pigit.Objects
{
    abstract class APlayerObject : IPlayerObject
    {
        public Rectangle Rectangle { get; set; }
        public bool Direction { get; set; }
        public Vector2 Positie { get; set; }
        public Vector2 Versnelling { get; set; }
        public AnimatieTypes Type { get; set; }
        public int Hearts { get; set; }
        public int AttackDamage { get; set; }
        public Dictionary<AnimatieTypes, SpriteDefine> Sprites { get; set; }
        public SpriteDefine CurrentSprite { get; private set; }
        public bool Dead { get; private set; }

        public APlayerObject(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition, int levens = 10, int attackDamage = 1)
        {
            Hearts = levens;
            AttackDamage = attackDamage;
            Sprites = spriteOpbouw;
            Positie = beginPosition;
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
            CheckDead();
            CheckType();

            if (Type != AnimatieTypes.Dead)
            {
                Positie += Versnelling;
                RectBuild();
                CurrentSprite.Update(gameTime);
            }
            else
            {
                if(CurrentSprite.AnimatieL.Counter == CurrentSprite.AmountFrames - 1)
                {
                    //Debug.Print($"counter sprites {CurrentSprite.AnimatieL.Counter}");
                    Dead = true;
                }
                else
                {
                    CurrentSprite.Update(gameTime);
                }
            }
        }

        private void CheckDead()
        {
            if (Hearts <=0)
            {
                Type = AnimatieTypes.Dead;
            }
        }

        protected virtual void RectBuild()
        {
            Rectangle = new Rectangle((int)Positie.X, (int)Positie.Y, CurrentSprite.AnimatieL.CurrentFrame.SourceRect.Width, CurrentSprite.AnimatieL.CurrentFrame.SourceRect.Height);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (!Dead)
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
            }
        }
    }
}
