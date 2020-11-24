using Microsoft.Xna.Framework;
using Pigit.Objects;
using SharpDX.Direct3D9;

namespace Pigit
{
    class CameraAnimatie
    {
        public Matrix Transform { get; private set; }

        public void Follow(IPlayerObject target)
        {
            Matrix offset = Matrix.CreateTranslation(
                    Game1.ScreenWidth / 2,
                    Game1.ScreenHeight / 2,
                    0);
            Matrix centerSprite = Matrix.CreateTranslation(
                -target.Positie.X - (target.Rectangle.Width / 2),
                -target.Positie.Y - (target.Rectangle.Height / 2),
                0);

            //Center van de sprite
            Transform = centerSprite * offset;
        }
    }
}