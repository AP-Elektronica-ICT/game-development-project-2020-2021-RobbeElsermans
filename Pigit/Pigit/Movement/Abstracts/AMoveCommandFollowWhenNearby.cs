using Microsoft.Xna.Framework;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Objects;
using Pigit.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Movement.NPCMoveCommands
{
    class AMoveCommandFollowWhenNearby : AMovement
    {
        public static IMoveable HeroPlayer { get; set; }
        public AMoveCommandFollowWhenNearby(IPlayerObject player, Level level, float jumpHeight = 4, float walkspeed = 2) : base(player, level, jumpHeight, walkspeed)
        {
        }

        public override void CheckMovement(GameTime gameTime)
        {
            RecastPositions();

            if (NPCCollision.IsLeftFromNPC(HeroPlayer.Positie, positie))
            {
                player.Direction = true;
                velocity.X = -1;
            }
            else if (NPCCollision.IsRightFromNPC(HeroPlayer.Positie, positie))
            {
                player.Direction = false;
                velocity.X = 1;
            }
            else
            {
                velocity.X = 0;
            }

            if (NPCCollision.IsAboveNPC(HeroPlayer.Positie, positie) && !hasJumped)
            {
                //Jump
                velocity.Y = -jumpHeight;
                hasJumped = true;
                isGround = false;
            }

            CheckCollide(4,5);
            CheckGravity();

            player.Update(gameTime);
        }
    }
}

