
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using System;
using System.Linq.Expressions;

namespace Pigit
{
    public class Human : IGameObject
    {
        private Texture2D heroTextureR;
        private Texture2D heroTextureL;
        Animatie animatieR;
        Animatie animatieL;
        static Vector2 positie;
        Vector2 snelheid;
        Vector2 versnelling;
        public static bool Direction { get; set; } = false; //rechts

        static public Vector2 Positie { get
            {
                return positie;
            }
            set
            {
                positie += value;
            }
        }

        public Human(Texture2D textureRight, Texture2D textureLeft, Vector2 size, int amountFrames)
        {
            
            this.heroTextureR = textureRight;
            this.heroTextureL = textureLeft;
            animatieR = new Animatie();
            animatieL = new Animatie();
            Animatie.Speed = 8;

            for (int i = 0; i <= size.X * amountFrames -1; i += (int)size.X)
            {
                animatieR.AddFrame(new AnimatieFrame(new Rectangle(i, 0, (int)size.X, (int)size.Y)));
            }

            for (int i = Convert.ToInt32(size.X * (amountFrames-1)); i >= 0; i -= (int)size.X)
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

        public void Update(GameTime gameTime, Vector2 verplaatsing)
        {
            this.Move(verplaatsing);
            animatieR.Update(gameTime);
            animatieL.Update(gameTime);
        }
        public void Update(GameTime gameTime)
        {
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
