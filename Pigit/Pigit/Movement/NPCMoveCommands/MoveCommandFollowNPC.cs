using Microsoft.Xna.Framework;
using Pigit.Map;
using Pigit.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Movement.NPCMoveCommands
{
    class MoveCommandFollowNPC:AMovement
    {
        private IMoveable heroPlayer;
        public MoveCommandFollowNPC(IPlayerObject player, Level level,IMoveable hero ,int jumpHeight = 4, int walkspeed = 2) : base(player, level, jumpHeight, walkspeed)
        {
            heroPlayer = hero;
        }
        public override void CheckMovement(GameTime gameTime)
        {
            base.CheckMovement(gameTime);

            if (heroPlayer.Positie.X < positie.X)
            {
                velocity.X = -1;
            }
            else if (heroPlayer.Positie.X < positie.X)
            {
                velocity.X = 1;
            }
            else
            {
                velocity.X = 0;
            }

            CheckCollide();
            CheckGravity();
        }
    }
}
