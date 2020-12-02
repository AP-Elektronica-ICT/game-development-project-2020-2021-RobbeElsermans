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
        public SpriteDefine CurrentSprite { get; set; }

        public APlayerObject(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw)
        {
            Sprites = spriteOpbouw;
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
            //if (Direction)
            //{
            //    RectangleL = new Rectangle((int)Positie.X + 30, (int)Positie.Y + 14, 40, 34);
            //}
            //else
            //{
            //    RectangleR = new Rectangle((int)Positie.X + 8, (int)Positie.Y + 14, 40, 34);
            //}
            CheckType();
            RectBuild();
            CurrentSprite.Update(gameTime);
        }
        protected virtual void RectBuild()
        {
            Rectangle = new Rectangle((int)Positie.X, (int)Positie.Y, CurrentSprite.AnimatieL.CurrentFrame.SourceRect.Width, CurrentSprite.AnimatieL.CurrentFrame.SourceRect.Height);
        }
        public void Draw(SpriteBatch _spriteBatch)
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
