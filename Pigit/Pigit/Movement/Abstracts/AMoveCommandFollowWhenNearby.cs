
using Microsoft.Xna.Framework;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Movement.Abstracts;
using Pigit.Objects.Abstracts;
using Pigit.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pigit.Movement.NPCMoveCommands
{
    class AMoveCommandFollowWhenNearby : AEnemyMovement
    {
        public static IMoveable HeroPlayer { get; set; }
        public AMoveCommandFollowWhenNearby(AEnemyObject player, Level level, float jumpHeight = 4, float walkspeed = 2) : base(player, level, jumpHeight, walkspeed)
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

            player.IsAttacking = false;
            if (NPCCollision.IsTouchingNPC(HeroPlayer.Rectangle, player.Rectangle))
            {
                player.IsAttacking = true;
                player.Attack.NPCAttack(HeroPlayer as IPlayerObject, player, gameTime);
            }

            CheckCollide(4,5);
            CheckGravity();

            player.Update(gameTime);
        }
    }
}

