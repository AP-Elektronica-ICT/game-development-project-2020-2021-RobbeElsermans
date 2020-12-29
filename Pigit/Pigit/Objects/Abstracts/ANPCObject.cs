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
        protected Dictionary<AnimatieTypes, SpriteDefine> sprites;
        protected SpriteDefine currentSprite;
        protected AnimatieTypes type;

        public Rectangle Rectangle { get; protected set; }
        public bool Direction { get; set; }
        public Vector2 Positie { get; set; }
        public Vector2 Velocity { get; set; }
        
        public MoveTypes MovementType { get; set; }

        public ANPCObject(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition, Dictionary<TextTypes, SpriteFont> spriteFonts, MoveTypes moveTypes)
        {
            text = new EnemyText(spriteFonts);
            sprites = spriteOpbouw;
            Positie = beginPosition;
            this.MovementType = moveTypes;
            CheckSprites();
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

        public virtual void Update(GameTime gameTime)
        {
            CheckSprites();

            Positie += Velocity;
            RectBuild();
            currentSprite.Update(gameTime);
        }

        protected virtual void CheckSprites()
        {
            if (Velocity.X < 0 || Velocity.X > 0)
            {
                type = AnimatieTypes.Run;
            }
            else
            {
                type = AnimatieTypes.Idle;
            }

            if (Velocity.Y + 0.2f < 0)
            {
                type = AnimatieTypes.Jump;
            }
            if (Velocity.Y - 0.2f > 0)
            {
                type = AnimatieTypes.Fall;
            }

            CheckType();
        }

        protected virtual void RectBuild()
        {
            Rectangle = new Rectangle((int)Positie.X, (int)Positie.Y, currentSprite.AnimatieL.CurrentFrame.SourceRect.Width, currentSprite.AnimatieL.CurrentFrame.SourceRect.Height);
        }
        public virtual void Draw(SpriteBatch _spriteBatch)
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

            text.Draw(_spriteBatch);
        }
    }
}
