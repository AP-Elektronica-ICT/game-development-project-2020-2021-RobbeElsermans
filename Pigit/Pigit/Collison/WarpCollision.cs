using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Collison
{
    class WarpCollision
    {
        private const int margin = 20;
        public static bool IsAroundWarp(Vector2 player1, Vector2 player2)
        {
            if (player1.X > (player2.X) - margin &&
                player1.X < (player2.X) + margin &&
                player1.Y < (player2.Y) + margin &&
                player1.Y > (player2.Y) - margin)
            {
                return true;
            }
            return false;
        }
    }
}
