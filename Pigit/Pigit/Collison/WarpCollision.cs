﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Collison
{
    class WarpCollision
    {
        public static bool IsAroundWarp(Vector2 player1, Vector2 player2)
        {
            //Enter langs links van enemy object
            if (player1.X > (player2.X) - 100 &&
                player1.X < (player2.X) + 100 &&
                player1.Y < (player2.Y) + 50 &&
                player1.Y > (player2.Y) - 50)
            {
                return true;
            }
            return false;
        }
    }
}
