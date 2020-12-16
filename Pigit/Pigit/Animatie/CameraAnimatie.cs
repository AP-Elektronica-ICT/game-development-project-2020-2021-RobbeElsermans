using Microsoft.Xna.Framework;
using Pigit.Objects;
using SharpDX.Direct3D9;

namespace Pigit
{
    class CameraAnimatie
    {
        public Matrix Transform { get; private set; }

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
                1.3f, 
                1.3f, 
                1);

            var scale = 
                Matrix.CreateScale(scalingFactor);

            //Center van de sprite
            //Transform = centerSprite * offset;
            Transform = (centerSprite * scale) * offset;
        }
    }
}