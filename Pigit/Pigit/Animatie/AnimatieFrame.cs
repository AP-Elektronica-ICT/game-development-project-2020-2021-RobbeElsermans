using Microsoft.Xna.Framework;

namespace Pigit
{
    internal class AnimatieFrame
    {
        public Rectangle SourceRect { get; set; }

        public AnimatieFrame(Rectangle rectangle)
        {
            this.SourceRect = rectangle;
        }
    }
}