
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using System.Linq.Expressions;

namespace Pigit
{
    public class Human : IGameObject
    {
        private Texture2D heroTexture;
        Animatie animatie;
        Vector2 positie;
        Vector2 snelheid;
        Vector2 versnelling;
        private Vector2 mouse;
        KeyboardState keyboard;

        public Vector2 Positie { get
            {
                return positie;
            }
            set
            {
                positie = value;
            }
        }


        public Human(Texture2D texture, Vector2 size, int amountFrames)
        {
            
            this.heroTexture = texture;
            animatie = new Animatie();
            Animatie.Speed = 8;

            for (int i = 0; i <= size.X * amountFrames -1; i += (int)size.X)
            {
                animatie.AddFrame(new AnimatieFrame(new Rectangle(i, 0, (int)size.X, (int)size.Y)));
            }

            snelheid = new Vector2(1, 1);
            
        }

        private Vector2 GetMouseState()
        {
            MouseState state = Mouse.GetState();
            mouse = new Vector2(state.X, state.Y);
            return mouse;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(heroTexture, positie, animatie.CurrentFrame.SourceRect, Color.White);
        }

        public void Update(GameTime gameTime, Vector2 verplaatsing)
        {
            
            this.Move(verplaatsing);
            animatie.Update(gameTime);
        }
        public void Update(GameTime gameTime)
        {
            animatie.Update(gameTime);
        }

        private void Move(Vector2 verplaatsing)
        {
            positie += verplaatsing;
            Vector2.Add(snelheid, positie);
            positie += versnelling;
            Positie = positie;
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
