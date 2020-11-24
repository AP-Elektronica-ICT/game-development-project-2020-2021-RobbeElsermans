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
        protected SpriteOpbouw opbouwSprites;
        SpriteDefine currentSprite;
        public AnimatieTypes Type { get; set; }

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
        public void Update(GameTime gameTime)
        {
            //if (Direction)
            //{
            //    RectangleL = new Rectangle((int)Positie.X + 30, (int)Positie.Y + 14, 40, 34);
            //}
            //else
            //{
            //    RectangleR = new Rectangle((int)Positie.X + 8, (int)Positie.Y + 14, 40, 34);
            //}

            Rectangle = new Rectangle((int)Positie.X + 18, (int)Positie.Y + 17, 40, 28);

            CheckType();
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
