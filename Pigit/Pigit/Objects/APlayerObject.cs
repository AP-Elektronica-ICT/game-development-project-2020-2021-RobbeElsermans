using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects
{
    abstract class APlayerObject : IPlayerObject
    {
        protected Texture2D heroTextureR;
        protected Texture2D heroTextureL;
        protected Animatie animatieR;
        protected Animatie animatieL;
        protected static Vector2 positie;
        protected Vector2 snelheid;
        protected Vector2 versnelling;

        public bool Direction { get; set; } = false; //rechts

        static public Vector2 Positie
        {
            get
            {
                return positie;
            }
            set
            {
                positie += value;
            }
        }

        public APlayerObject(Texture2D textureRight, Texture2D textureLeft, Vector2 size, int amountFrames)
        {
            this.heroTextureR = textureRight;
            this.heroTextureL = textureLeft;
            animatieR = new Animatie();
            animatieL = new Animatie();
            Animatie.Speed = 8;

            for (int i = 0; i <= size.X * amountFrames - 1; i += (int)size.X)
            {
                animatieR.AddFrame(new AnimatieFrame(new Rectangle(i, 0, (int)size.X, (int)size.Y)));
            }


            for (int i = Convert.ToInt32(size.X * (amountFrames - 1)); i >= 0; i -= (int)size.X)
            {
                animatieL.AddFrame(new AnimatieFrame(new Rectangle(i, 0, (int)size.X, (int)size.Y)));
            }

            snelheid = new Vector2(1, 1);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (Direction)
            {
                _spriteBatch.Draw(heroTextureL, positie, animatieL.CurrentFrame.SourceRect, Color.White);
            }
            else
            {
                _spriteBatch.Draw(heroTextureR, positie, animatieR.CurrentFrame.SourceRect, Color.White);
            }
        }

        public void Update(GameTime gameTime)
        {
            animatieR.Update(gameTime);
            animatieL.Update(gameTime);
        }

        public void Update(GameTime gameTime, Vector2 verplaatsing)
        {
            this.Move(verplaatsing);
            animatieR.Update(gameTime);
            animatieL.Update(gameTime);
        }

        private void Move(Vector2 verplaatsing)
        {
            positie += verplaatsing;

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
