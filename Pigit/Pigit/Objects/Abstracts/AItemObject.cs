using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Movement;
using Pigit.Objects.Enums;
using Pigit.Objects.Interfaces;
using Pigit.SpriteBuild.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects.Abstracts
{
    abstract class AItemObject : ICollectableObject
    {
        protected AnimatieTypes animatieType;
        protected Dictionary<AnimatieTypes, SpriteDefine> sprites;
        protected SpriteDefine currentSprite;

        public MoveTypes MovementType { get; protected set; }
        public int Value { get; protected set; }

        public bool IsCollected { get; set; }
        public bool IsTaken { get; set; }

        public CollectableTypes ItemType { get; protected set; }

        public Rectangle Rectangle { get; protected set; }
        public Vector2 Positie { get; set; }
        public Vector2 Velocity { get; set; }

        public AItemObject(Dictionary<AnimatieTypes, SpriteDefine> sprites, CollectableTypes type, Vector2 positie, MoveTypes movement, int value)
        {
            this.MovementType = movement;
            this.sprites = sprites;
            this.Positie = positie;
            this.ItemType = type;
            this.IsCollected = false;
            this.Value = value;
            CheckSprites();
        }
        private void CheckType()
        {
            foreach (var sprites in sprites)
            {
                if (sprites.Key == animatieType)
                {
                    currentSprite = sprites.Value;
                }
            }
        }

        protected virtual void RectBuild()
        {
            Rectangle = new Rectangle((int)Positie.X, (int)Positie.Y, currentSprite.AnimatieR.CurrentFrame.SourceRect.Width, currentSprite.AnimatieR.CurrentFrame.SourceRect.Height);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
                _spriteBatch.Draw(currentSprite.TextureR, Positie, currentSprite.AnimatieR.CurrentFrame.SourceRect, Color.White);
        }
        private void CheckSprites()
        {
            animatieType = AnimatieTypes.Idle;

            if (IsCollected)
            {
                animatieType = AnimatieTypes.Hit;
            }

            CheckType();
        }
        public void Update(GameTime gameTime)
        {
            Positie += Velocity;
            CheckSprites();
            RectBuild();

            if (currentSprite.AnimatieL.Counter == currentSprite.AmountFrames-1 && IsCollected)
            {
                IsTaken = true;
            }
            else
            {
                currentSprite.Update(gameTime);
            }

        }
    }
}
