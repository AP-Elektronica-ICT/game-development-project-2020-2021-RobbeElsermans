using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Objects.Interfaces;
using Pigit.SpriteBuild.Enums;
using System.Collections.Generic;

namespace Pigit.Objects.Abstracts
{
    class AStaticObject : IMoveableSprite, IObject
    {
        protected Vector2 positie;
        protected Dictionary<AnimatieTypes, SpriteDefine> sprites;
        protected SpriteDefine currentSprite;
        protected AnimatieTypes type;
        public bool Direction { get; set; }

        public AStaticObject(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition)
        {
            sprites = spriteOpbouw;
            positie = beginPosition;
        }

        public void Update(GameTime gameTime)
        {
            CheckSprites();
            currentSprite.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(currentSprite.TextureL, positie, currentSprite.AnimatieL.CurrentFrame.SourceRect, Color.White);
        }
        private void CheckSprites()
        {
            type = AnimatieTypes.Idle;

            CheckType();
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
    }
}
