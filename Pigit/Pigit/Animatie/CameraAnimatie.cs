using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pigit.Objects.Interfaces;

namespace Pigit.Animatie
{
    class CameraAnimatie
    {
        public Matrix Transform { get; private set; }
        public float Zoom
        {
            get { return zoom; }
            set
            {
                zoom = value;
                if (zoom > 1.5f) zoom = 1.5f;
                if (zoom < 1) zoom = 1f;
            }
        }
        public float Rotation { get; set; }

        private float zoom = 1;
        public void Follow(IMoveable target)
        {
            Matrix offset =
                Matrix.CreateTranslation(
                    Game1.ScreenWidth / 2,
                    Game1.ScreenHeight / 2,
                    0);

            Matrix centerSprite =
                Matrix.CreateTranslation(
                    -target.Rectangle.X - (target.Rectangle.Width / 2),
                    -target.Rectangle.Y - (target.Rectangle.Height / 2),
                    0);
            //var scalingFactor = Vector3.One;
            //if (Game1.currGameState == GameLoop.Play)
            //{
            //    if (zoom <= 1.5)
            //    {
            //        float x = 1f;
            //        zoom += x * 0.005f;
            //    }
            //}
            //else
            //{
            //    zoom = 1f;                
            //}
            var scalingFactor = new Vector3(Zoom, Zoom, 1);

            var scale =
                Matrix.CreateScale(scalingFactor);


            if (Keyboard.GetState().IsKeyDown(Keys.I))
            {
                Rotation += 0.005f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.K))
            {
                Rotation -= 0.005f;
            }

            Matrix rotation = Matrix.CreateRotationZ(Rotation);

            //Center van de sprite
            //Transform = centerSprite * offset;
            Transform = ((centerSprite * rotation) * scale) * offset;
            //Transform = ((centerSprite * scale) * offset);
        }
    }
}