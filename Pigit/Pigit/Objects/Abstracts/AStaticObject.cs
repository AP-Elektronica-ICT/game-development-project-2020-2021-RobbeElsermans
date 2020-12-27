using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Objects.Interfaces;
using Pigit.SpriteBuild.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects.Abstracts
{
    class AStaticObject : IMoveableSprite, IObject
    {
        public Vector2 Positie { get; set; }

        public SpriteDefine CurrentSprite { get; private set; }

        public Dictionary<AnimatieTypes, SpriteDefine> Sprites { get; set; }
        public bool Direction { get; set; }
        public AnimatieTypes Type { get; set; }

        public AStaticObject(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition)
        {
            Sprites = spriteOpbouw;
            Positie = beginPosition;
        }

        public void Update(GameTime gameTime)
        {
            CheckSprites();
            CurrentSprite.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(CurrentSprite.TextureL, Positie, CurrentSprite.AnimatieL.CurrentFrame.SourceRect, Color.White);
        }
        private void CheckSprites()
        {
            Type = AnimatieTypes.Idle;

            CheckType();
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
    }
}
