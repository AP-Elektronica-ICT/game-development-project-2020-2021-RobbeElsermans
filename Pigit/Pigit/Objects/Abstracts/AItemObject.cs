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
    class AItemObject : ICollectableObject
    {
        public MoveTypes MovementType { get; set; }
        public AnimatieTypes Type { get; set; }

        public int Value { get; protected set; }

        public bool IsTaken { get; set; }
        public bool IsCollected { get; set; }

        public CollectableTypes Size { get; protected set; }

        public Rectangle Rectangle { get; set; }

        public SpriteDefine CurrentSprite { get; protected set; }

        public Dictionary<AnimatieTypes, SpriteDefine> Sprites { get; set; }
        public Vector2 Positie { get; set; }
        public Vector2 Velocity { get; set; }

        public AItemObject(Dictionary<AnimatieTypes, SpriteDefine> sprites, Vector2 positie, MoveTypes movement)
        {
            this.MovementType = movement;
            this.Sprites = sprites;
            this.Positie = positie;
            IsCollected = false;
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

        protected virtual void RectBuild()
        {
            Rectangle = new Rectangle((int)Positie.X, (int)Positie.Y, CurrentSprite.AnimatieR.CurrentFrame.SourceRect.Width, CurrentSprite.AnimatieR.CurrentFrame.SourceRect.Height);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (!IsCollected)
            {
                _spriteBatch.Draw(CurrentSprite.TextureR, Positie, CurrentSprite.AnimatieR.CurrentFrame.SourceRect, Color.White);
            }
        }
        private void CheckSprites()
        {
            Type = AnimatieTypes.Idle;

            if (IsCollected)
            {
                Type = AnimatieTypes.Hit;
            }

            CheckType();
        }
        public void Update(GameTime gameTime)
        {
            Positie += Velocity;
            CheckSprites();
            CurrentSprite.Update(gameTime);
            
            RectBuild();
        }
    }
}
