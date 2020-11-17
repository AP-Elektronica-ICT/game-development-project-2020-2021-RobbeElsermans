using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Movement
{
    static class RectangleCollision
    {
        const int penetrationMargin = 2;
        public static bool isOnTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - penetrationMargin &&
                    r1.Bottom <= r2.Top + 1 &&
                    r1.Right >= r2.Left + 5 &&
                    r1.Left <= r2.Right - 5);
        }
    }
}
