using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pigit.Objects;
using SharpDX.Direct3D9;

namespace Pigit
{
    class CameraAnimatie
    {
        public Matrix Transform { get; private set; }
        public float Zoom { get; set; }

        public void Follow(INPCObject target)
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

            var scalingFactor = new Vector3(
                1.0f, 
                1.0f, 
                1);

            var scale = 
                Matrix.CreateScale(scalingFactor);


            if (Keyboard.GetState().IsKeyDown(Keys.I))
            {
                Zoom += 0.005f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.K))
            {
                Zoom -= 0.005f;
            }

            Matrix rotation = Matrix.CreateRotationZ(Zoom);

            //Center van de sprite
            //Transform = centerSprite * offset;
            Transform = ((centerSprite * rotation) * scale) * offset;
            //Transform = ((centerSprite * scale) * offset);
        }

        public CameraAnimatie(Viewport viewport)
        {
            this.viewport = viewport;
        }
    }
}