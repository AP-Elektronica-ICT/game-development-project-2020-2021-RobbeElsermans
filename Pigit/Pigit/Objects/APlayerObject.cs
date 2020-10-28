using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects
{
    abstract class APlayerObject : IPlayerObject
    {
        protected Texture2D heroTextureR;
        protected Texture2D heroTextureL;
        protected AnimatieConst animatieR;
        protected AnimatieConst animatieL;

        public int FrameCount { get; private set; }
        public int AmountFrames { get; set; }
        public bool Direction { get; set; } = false; //rechts

        public Rectangle border;

        public APlayerObject(Texture2D textureRight, Texture2D textureLeft, Vector2 size, int amountFrames, int speed)
        {
            this.heroTextureR = textureRight;
            this.heroTextureL = textureLeft;
            animatieR = new AnimatieConst();
            animatieL = new AnimatieConst();
            AmountFrames = amountFrames;
            animatieL.Speed = speed;
            animatieR.Speed = speed;

             IPlayerObject.Positie = new Vector2(1, 300);

            for (int i = 0; i <= size.X * amountFrames - 1; i += (int)size.X)
            {
                animatieR.AddFrame(new AnimatieFrame(new Rectangle(i, 0, (int)size.X, (int)size.Y)));
            }


            for (int i = Convert.ToInt32(size.X * (amountFrames - 1)); i >= 0; i -= (int)size.X)
            {
                animatieL.AddFrame(new AnimatieFrame(new Rectangle(i, 0, (int)size.X, (int)size.Y)));
            }

            border = new Rectangle((int)IPlayerObject.Positie.X, (int)IPlayerObject.Positie.Y, heroTextureL.Width, heroTextureL.Height);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (Direction)
            {
                _spriteBatch.Draw(heroTextureL, IPlayerObject.Positie, animatieL.CurrentFrame.SourceRect, Color.White);
            }
            else
            {
                _spriteBatch.Draw(heroTextureR, IPlayerObject.Positie, animatieR.CurrentFrame.SourceRect, Color.White);
            }
        }


        public void Update(GameTime gameTime, Vector2 verplaatsing)
        {
            this.Move(verplaatsing);
            animatieR.Update(gameTime);
            animatieL.Update(gameTime);
            FrameCount = (animatieL.Counter + animatieR.Counter) / 2;
        }

        private void Move(Vector2 verplaatsing)
        {
            IPlayerObject.Positie += verplaatsing;
            IPlayerObject.Positie += IPlayerObject.Versnelling;
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
    }
}
