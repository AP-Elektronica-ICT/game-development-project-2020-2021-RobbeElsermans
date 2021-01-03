using Microsoft.Xna.Framework;

namespace Pigit.Collision
{
    static class PlatformBlockCollision
    {
        private const int penetrationMargin = 5;

        public static bool isOnTopOf(this Rectangle r1, Rectangle r2, Vector2 velocity)
        {
            return (r1.Bottom >= r2.Top - velocity.Y &&
                    r1.Bottom <= r2.Top + penetrationMargin &&
                    r1.Right >= r2.Left + penetrationMargin &&
                    r1.Left <= r2.Right - penetrationMargin);
        }
    }
}
