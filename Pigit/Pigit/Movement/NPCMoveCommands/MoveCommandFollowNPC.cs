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
            
            if (heroPlayer.Positie.X + 32 < positie.X)
            {
                player.Direction = true;
                velocity.X = -1;
            }
            else if (heroPlayer.Positie.X + 32 > positie.X)
            {
                player.Direction = false;
                velocity.X = 1;
            }
            else
            {
                velocity.X = 0;
            }

            if (heroPlayer.Positie.Y + 20 < positie.Y && !hasJumped)
            {
                //Jump
                velocity.Y = -jumpHeight;
                hasJumped = true;
                isGround = false;
            }

            CheckCollide();
            CheckGravity();

            player.Update(gameTime);
        }
    }
}
