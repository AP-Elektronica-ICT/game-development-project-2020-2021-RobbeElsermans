
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Objects;
using SharpDX.MediaFoundation;

namespace Pigit
{
    public class Pig : INPCObject
    {
        private Texture2D heroTexture;
        Animatie animatie;
        Vector2 positie;
        Vector2 snelheid;
        Vector2 versnelling;
        private Vector2 mouse;

        public Pig(Texture2D texture)
        {
            this.heroTexture = texture;
            animatie = new Animatie();
            Animatie.Speed = 8;

            //animatie.AddFrame(new AnimatieFrame(new Rectangle(0, i, 128, 48)));


            snelheid = new Vector2(1, 1);
            positie = new Vector2(200, 200);
            versnelling = new Vector2(0.1f, 0.1f);
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

        public void Update(GameTime gameTime)
        {

            this.Move(GetMouseState());
            animatie.Update(gameTime);
        }

        private void Move(Vector2 mouse)
        {

            var richting = Vector2.Add(mouse, -positie);
            richting.Normalize();
            richting = Vector2.Multiply(richting, 0.10f);

            snelheid += richting;
            snelheid = limit(snelheid, 5);
            positie += snelheid;
            float tmp = snelheid.Length();

            if (this.positie.X > 600 + 128 || this.positie.X < 0)
            {
                snelheid.X *= -1;
                versnelling.X *= -1;
            }
            if (this.positie.Y > 400 || this.positie.Y < 0)
            {
                snelheid.Y *= -1;
                versnelling.Y *= -1;
            }

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

        public void Update(GameTime gameTime, Vector2 verplaatsing)
        {
            throw new System.NotImplementedException();
        }
    }

}
