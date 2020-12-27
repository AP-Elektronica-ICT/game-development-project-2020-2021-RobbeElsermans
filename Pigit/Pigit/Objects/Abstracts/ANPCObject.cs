using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Attack;
using Pigit.Movement;
using Pigit.Objects.Interfaces;
using Pigit.SpriteBuild.Enums;
using Pigit.Text.Abstract;
using Pigit.Text.Enums;
using Pigit.Text.PlayerTexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects.Abstracts
{
    abstract class ANPCObject: IEnemyObject
    {
        protected double timer;
        protected bool isSetTimer;
        protected APlayerText text;
        protected int beginHearts;
        protected int beginAttackDamage;

        public Rectangle Rectangle { get; set; }
        public bool Direction { get; set; }
        public Vector2 Positie { get; set; }
        public Vector2 Velocity { get; set; }
        public AnimatieTypes Type { get; set; }
        public Dictionary<AnimatieTypes, SpriteDefine> Sprites { get; set; }
        public SpriteDefine CurrentSprite { get; protected set; }
        public MoveTypes MovementType { get; set; }

        public ANPCObject(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition, Dictionary<TextTypes, SpriteFont> spriteFonts, MoveTypes moveTypes)
        {
            text = new EnemyText(spriteFonts);
            Sprites = spriteOpbouw;
            Positie = beginPosition;
            this.MovementType = moveTypes;
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

        public virtual void Update(GameTime gameTime)
        {
            CheckSprites();

            Positie += Velocity;
            RectBuild();
            CurrentSprite.Update(gameTime);
        }

        protected virtual void CheckSprites()
        {
            if (Velocity.X < 0 || Velocity.X > 0)
            {
                Type = AnimatieTypes.Run;
            }
            else
            {
                Type = AnimatieTypes.Idle;
            }

            if (Velocity.Y + 0.2f < 0)
            {
                Type = AnimatieTypes.Jump;
            }
            if (Velocity.Y - 0.2f > 0)
            {
                Type = AnimatieTypes.Fall;
            }

            CheckType();
        }

        protected virtual void RectBuild()
        {
            Rectangle = new Rectangle((int)Positie.X, (int)Positie.Y, CurrentSprite.AnimatieL.CurrentFrame.SourceRect.Width, CurrentSprite.AnimatieL.CurrentFrame.SourceRect.Height);
        }
        public virtual void Draw(SpriteBatch _spriteBatch)
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

            text.Draw(_spriteBatch);
        }
    }
}
