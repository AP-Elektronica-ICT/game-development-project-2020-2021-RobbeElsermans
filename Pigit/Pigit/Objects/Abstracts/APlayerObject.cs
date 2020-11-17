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
        public bool Direction { get; set; }
        public Vector2 Positie { get; set; }
        public Vector2 Versnelling { get; set; }
        protected SpriteOpbouw opbouwSprites;
        public AnimatieTypes Type { get; set; }
        public Rectangle Border { get; set; }

        private SpriteDefine currentSprite;

        public APlayerObject(SpriteOpbouw spriteOpbouw)
        {
            opbouwSprites = spriteOpbouw;
        }
        private void CheckType()
        {
            foreach (var sprites in opbouwSprites.SpriteHuman)
            {
                if (sprites.Key == Type)
                {
                    currentSprite = sprites.Value;
                }
            }
        }
        private void Move(Vector2 verplaatsing)
        {
            Positie += verplaatsing;
            Positie += Versnelling;

            Border = new Rectangle((int)Positie.X, (int)Positie.Y, currentSprite.TextureR.Width, currentSprite.TextureR.Height-13);
        }
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
        public void Update(GameTime gameTime, Vector2 verplaatsing)
        {
            CheckType();

            
            this.Move(verplaatsing);
            currentSprite.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
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

        }
    }
}
