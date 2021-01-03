using Microsoft.Xna.Framework;

namespace Pigit.Collision
{
    class ItemCollision
    {
        private const int oneBlockStep = 32;
        private const int marginLeft = oneBlockStep * 1;
        private const int marginRight = oneBlockStep * 1;
        private const int marginTop = oneBlockStep * 1;
        private const int marginBottom = oneBlockStep * 1;
        public static bool IsTouchingItem(Rectangle player1, Rectangle player2)
        {
            if (player1.Intersects(player2))
            {
                return true;
            }

            return false;
        }
        public static bool IsAroundItem(Vector2 player1, Vector2 player2)
        {
            //Enter langs links van enemy object
            if (player1.X > (player2.X) - marginLeft &&
                player1.X < (player2.X) + marginRight &&
                player1.Y < (player2.Y) + marginBottom &&
                player1.Y > (player2.Y) - marginTop)
            {
                return true;
            }
            return false;
        }
    }
}
