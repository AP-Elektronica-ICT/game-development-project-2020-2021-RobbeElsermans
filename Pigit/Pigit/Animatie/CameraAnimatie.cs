using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Objects;
using SharpDX.Direct3D9;

namespace Pigit
{
    class CameraAnimatie
    {
        public Matrix Transform { get; private set; }
        private Viewport viewport;

        public void Follow(INPCObject target)
        {
            Matrix offset = Matrix.CreateTranslation(new Vector3(target.Positie.X, target.Positie.Y, 0));
            Matrix centerSprite = Matrix.CreateTranslation(new Vector3(-target.Positie.X, -target.Positie.Y, 0));
            Matrix scale = Matrix.CreateScale(new Vector3(2.2f, 2.2f, 0));

            Matrix offset2 = Matrix.CreateTranslation(30f, 30f, 0);


            //Center van de sprite
            Transform = (centerSprite ) * scale;
        }

        public CameraAnimatie(Viewport viewport)
        {
            this.viewport = viewport;
        }
    }
}