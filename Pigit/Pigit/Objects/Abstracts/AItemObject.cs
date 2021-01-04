using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Movement.Enums;
using Pigit.Objects.Enums;
using Pigit.Objects.Interfaces;
using Pigit.SpriteBuild.Enums;
using Pigit.SpriteBuild.Generator;
using System.Collections.Generic;

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
        public bool IsTaken { get; protected set; }

        public CollectableTypes ItemType { get; protected set; }

        public Rectangle Rectangle { get; protected set; }
        public Vector2 Positie { get; set; }
        public Vector2 Velocity { get; set; }

        public AItemObject(CollectableTypes collectableType, SpriteGenerator sprites, CollectableTypes type, Vector2 positie, MoveTypes movement)
        {
            this.MovementType = movement;

            switch (collectableType)
            {
                case CollectableTypes.BigHeart:
                    this.sprites = sprites.GetSpriteBigHeart(6);
                    this.Value = (int)CollectableValues.BigHeart;
                    break;
                case CollectableTypes.BigDiamond:
                    this.sprites = sprites.GetSpriteBigDiamond(6);
                    this.Value = (int)CollectableValues.BigDiamond;
                    break;
                case CollectableTypes.SmallHeart:
                    this.sprites = sprites.GetSpriteSmallHeart(6);
                    this.Value = (int)CollectableValues.SmallgHeart;
                    break;
                case CollectableTypes.SmallDiamond:
                    this.sprites = sprites.GetSpriteSmallDiamond(6);
                    this.Value = (int)CollectableValues.SmallgDiamond;
                    break;
                default:
                    this.sprites = sprites.GetSpriteSmallHeart(6);
                    this.Value = (int)CollectableValues.SmallgHeart;
                    break;
            }
            this.Positie = positie;
            this.ItemType = type;
            this.IsCollected = false;
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
