﻿using Microsoft.Xna.Framework;
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
        public MoveTypes MovementType { get; set; }
        public AnimatieTypes AnimatieType { get; set; }

        public int Value { get; protected set; }

        public bool IsCollected { get; set; }
        public bool IsTaken { get; set; }

        public CollectableTypes ItemType { get; protected set; }

        public Rectangle Rectangle { get; set; }

        public SpriteDefine CurrentSprite { get; protected set; }

        public Dictionary<AnimatieTypes, SpriteDefine> Sprites { get; set; }
        public Vector2 Positie { get; set; }
        public Vector2 Velocity { get; set; }

        public AItemObject(Dictionary<AnimatieTypes, SpriteDefine> sprites, CollectableTypes type, Vector2 positie, MoveTypes movement, int value)
        {
            this.MovementType = movement;
            this.Sprites = sprites;
            this.Positie = positie;
            this.ItemType = type;
            this.IsCollected = false;
            this.Value = value;
            CheckSprites();
        }
        private void CheckType()
        {
            foreach (var sprites in Sprites)
            {
                if (sprites.Key == AnimatieType)
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
                _spriteBatch.Draw(CurrentSprite.TextureR, Positie, CurrentSprite.AnimatieR.CurrentFrame.SourceRect, Color.White);
        }
        private void CheckSprites()
        {
            AnimatieType = AnimatieTypes.Idle;

            if (IsCollected)
            {
                AnimatieType = AnimatieTypes.Hit;
            }

            CheckType();
        }
        public void Update(GameTime gameTime)
        {
            Positie += Velocity;
            CheckSprites();
            RectBuild();

            if (CurrentSprite.AnimatieL.Counter == CurrentSprite.AmountFrames-1 && IsCollected)
            {
                IsTaken = true;
            }
            else
            {
                CurrentSprite.Update(gameTime);
            }

        }
    }
}
