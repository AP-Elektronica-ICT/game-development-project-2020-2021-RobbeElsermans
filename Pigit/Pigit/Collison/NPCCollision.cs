using Microsoft.Xna.Framework;
using Pigit.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Collison
{
    static class NPCCollision
    {
        private const int oneBlockStep = 32;
        private const int marginLeft = oneBlockStep * 3;
        private const int marginRight = oneBlockStep * 1;
        private const int marginTop = oneBlockStep * 2;
        private const int marginBottom = oneBlockStep * 1;
        public static bool IsTouchingNPC(Rectangle player1, Rectangle player2)
        {
            if (player1.Intersects(player2))
            {
                return true;
            }

            return false;
        }
        public static bool IsAroundNPC(Vector2 player1, Vector2 player2)
        {
            if (player1.X > (player2.X) - marginLeft &&
                player1.X < (player2.X) + marginRight &&
                player1.Y < (player2.Y) + marginBottom &&
                player1.Y > (player2.Y) - marginTop)
            {
                return true;
            }
            return false;
        }
        public static bool IsLeftFromNPC(Vector2 player1, Vector2 player2)
        {
            if (player1.X + oneBlockStep < player2.X)
            {
                return true;
            }
            return false;
        }
        public static bool IsRightFromNPC(Vector2 player1, Vector2 player2)
        {
            if (player1.X + oneBlockStep > player2.X)
            {
                return true;
            }
            return false;
        }
        public static bool IsAboveNPC(Vector2 player1, Vector2 player2)
        {
            if (player1.Y + oneBlockStep < player2.Y)
            {
                return true;
            }
            return false;
        }

    }
}
