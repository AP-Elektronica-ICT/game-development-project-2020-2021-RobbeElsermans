using Microsoft.Xna.Framework;

namespace Pigit.Collision
{
    static class EndBlockCollision
    {
        //bron: https://www.youtube.com/watch?v=CV8P9aq2gQo 
        #region Collision 
        public static bool isTouchingLeft(Vector2 velocity, Rectangle tile, Rectangle rectangle)
        {
            bool a = (rectangle.Right + velocity.X > tile.Left);
            bool b = (rectangle.Left < tile.Left);
            bool c = (rectangle.Bottom > tile.Top);
            bool d = (rectangle.Top < tile.Bottom);

            return (a && b && c && d);
        }
        public static bool isTouchingRight(Vector2 velocity, Rectangle tile, Rectangle rectangle)
        {
            bool a = (rectangle.Left + velocity.X < tile.Right);
            bool b = (rectangle.Right > tile.Right);
            bool c = (rectangle.Bottom > tile.Top);
            bool d = (rectangle.Top < tile.Bottom);

            return (a && b && c && d);
        }
        public static bool isTouchingBottom(Vector2 velocity, Rectangle tile, Rectangle rectangle)
        {
            bool a = (rectangle.Top + velocity.Y < tile.Bottom);
            bool b = (rectangle.Bottom > tile.Bottom);
            bool c = (rectangle.Right > tile.Left);
            bool d = (rectangle.Left < tile.Right);

            return (a && b && c && d);
        }
        public static bool isTouchingTop(Vector2 velocity, Rectangle tile, Rectangle rectangle)
        {
            bool a = (rectangle.Bottom + velocity.Y > tile.Top);
            bool b = (rectangle.Top < tile.Top);
            bool c = (rectangle.Right > tile.Left);
            bool d = (rectangle.Left < tile.Right);

            return (a && b && c && d);
        }
        #endregion
    }
}
