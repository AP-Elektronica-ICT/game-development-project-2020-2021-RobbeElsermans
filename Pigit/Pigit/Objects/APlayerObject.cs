using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects
{
    abstract class APlayerObject : IPlayerObject
    {

        public bool Direction { get; set; } = false; //rechts
        public Vector2 Positie { get; set; }
        public Vector2 Versnelling { get; set; }

        protected SpriteOpbouw opbouwSprites;
        SpriteDefine currentSprite;

        public APlayerObject(SpriteOpbouw spriteOpbouw)
        {
            opbouwSprites = spriteOpbouw;
        }
        public AnimatieTypes Type { get; set; } = AnimatieTypes.Idle;


        private void CheckType()
        {
            foreach (var sprites in opbouwSprites.SpriteHuman)
            {
                if(sprites.Key == Type)
                {
                    currentSprite = sprites.Value;
                }
            }
        }
        private void Move(Vector2 verplaatsing)
        {
            Positie += verplaatsing;
            Positie += Versnelling;
        }

        private Vector2 limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

        public void Update(GameTime gameTime, Vector2 verplaatsing)
        {
                this.Move(verplaatsing);
                CheckType();
                currentSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
                //if (!Direction)
                //{
                //    _spriteBatch.Draw(currentSprite.TextureR, currentSprite.AnimatieR.CurrentFrame.SourceRect, Color.White);
                //}
                //else
                //{
                //    _spriteBatch.Draw(currentSprite.TextureL, currentSprite.AnimatieL.CurrentFrame.SourceRect, Color.White);
                //}

                _spriteBatch.Draw(currentSprite.TextureR, currentSprite.AnimatieR.CurrentFrame.SourceRect, Color.White);
        }
    }
}
