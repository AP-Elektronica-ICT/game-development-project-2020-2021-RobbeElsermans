using Pigit.Objects;
using Pigit.TileBuild;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;

namespace Pigit.Collison
{
    static class EndBlockCollision
    {
        //bron: https://www.youtube.com/watch?v=CV8P9aq2gQo 
        #region Collision 
        public static bool isTouchingLeft(Vector2 velocity, ICollideTile tiles, Rectangle rectangle)
        {
            bool a = (rectangle.Right + velocity.X > tiles.Border.Left);
            bool b = (rectangle.Left < tiles.Border.Left);
            bool c = (rectangle.Bottom > tiles.Border.Top);
            bool d = (rectangle.Top < tiles.Border.Bottom);

            return (a && b && c && d);
        }
        public static bool isTouchingRight(Vector2 velocity, ICollideTile tiles, Rectangle rectangle)
        {
            bool a = (rectangle.Left + velocity.X < tiles.Border.Right);
            bool b = (rectangle.Right > tiles.Border.Right);
            bool c = (rectangle.Bottom > tiles.Border.Top);
            bool d = (rectangle.Top < tiles.Border.Bottom);

            return (a && b && c && d);
        }
        public static bool isTouchingBottom(Vector2 velocity, ICollideTile tiles, Rectangle rectangle)
        {
            bool a = (rectangle.Top + velocity.Y < tiles.Border.Bottom);
            bool b = (rectangle.Bottom > tiles.Border.Bottom);
            bool c = (rectangle.Right > tiles.Border.Left);
            bool d = (rectangle.Left < tiles.Border.Right);

            return (a && b && c && d);
        }
        public static bool isTouchingTop(Vector2 velocity, ICollideTile tiles, Rectangle rectangle)
        {
            bool a = (rectangle.Bottom + velocity.Y > tiles.Border.Top);
            bool b = (rectangle.Top < tiles.Border.Top);
            bool c = (rectangle.Right > tiles.Border.Left);
            bool d = (rectangle.Left < tiles.Border.Right);

            return (a && b && c && d);
        }
        #endregion
    }
}
