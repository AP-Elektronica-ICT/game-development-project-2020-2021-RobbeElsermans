using Microsoft.Xna.Framework;
using Pigit.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Collison
{
    static class NPCCollision
    {
        public static bool isTouchingNPC(Rectangle player1, Rectangle player2)
        {
            if(player1.Intersects(player2))
            {
                return true;
            }

            return false;
        }
    }
}
