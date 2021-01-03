using Microsoft.Xna.Framework;

namespace Pigit.Animatie
{
    class AnimatieFrame
    {
        public Rectangle SourceRect { get; set; }

        public AnimatieFrame(Rectangle rectangle)
        {
            this.SourceRect = rectangle;
        }
    }
}