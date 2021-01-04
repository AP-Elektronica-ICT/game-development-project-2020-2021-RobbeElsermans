using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pigit.Input;
using Pigit.Input.Interfaces;
using Pigit.Objects.Interfaces;

namespace Pigit.Animatie
{
    class CameraAnimatie
    {
        private IInputSecredKeys keyBoardReader;
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

        public CameraAnimatie(IInputSecredKeys keyBoard)
        {
            keyBoardReader = keyBoard;
        }
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
            var scalingFactor = new Vector3(Zoom, Zoom, 1);

            var scale =
                Matrix.CreateScale(scalingFactor);


            if (keyBoardReader.RotateLeft)
            {
                Rotation += 0.005f;
            }
            else if (keyBoardReader.RotateRight)
            {
                Rotation -= 0.005f;
            }
            else if (keyBoardReader.ResetRotation)
            {
                Rotation = 0f;
            }

            Matrix rotation = Matrix.CreateRotationZ(Rotation);

            Transform = ((centerSprite * rotation) * scale) * offset;
        }
    }
}