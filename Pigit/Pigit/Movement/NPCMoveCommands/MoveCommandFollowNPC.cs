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
    class MoveCommandFollowNPC: AMoveCommandFollowWhenNearby
    {
        public MoveCommandFollowNPC(IPlayerObject player, Level level,float jumpHeight = 4, float walkspeed = 2) : base(player, level, jumpHeight, walkspeed)
        {

        }
        public override void CheckMovement(GameTime gameTime)
        {
            RecastPositions();

            if (player is IMovementEnemy)
            {
                var temp = player as IMovementEnemy;
                if (NPCCollision.IsAroundNPC(HeroPlayer.Positie, positie))
                {
                    base.CheckMovement(gameTime);
                }
                else
                {
                    if (HeroPlayer.Positie.X + 32 < positie.X)
                    {
                        player.Direction = true;
                        velocity.X = -1;
                    }
                    else if (HeroPlayer.Positie.X + 32 > positie.X)
                    {
                        player.Direction = false;
                        velocity.X = 1;
                    }
                    else
                    {
                        velocity.X = 0;
                    }

                    if (HeroPlayer.Positie.Y + 20 < positie.Y && !hasJumped)
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
    }
}
