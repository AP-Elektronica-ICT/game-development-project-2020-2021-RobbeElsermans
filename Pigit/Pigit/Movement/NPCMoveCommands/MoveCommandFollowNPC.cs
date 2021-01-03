using Microsoft.Xna.Framework;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Music.Interface;
using Pigit.Objects;
using Pigit.Objects.Abstracts;
using Pigit.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Movement.NPCMoveCommands
{
    class MoveCommandFollowNPC: AMoveCommandFollowWhenNearby
    {
        public MoveCommandFollowNPC(AEnemyObject player, Level level,IEffectMusic effect,float jumpHeight = 4, float walkspeed = 2) : base(player, level,effect, jumpHeight, walkspeed)
        {

        }
        public override void CheckMovement(GameTime gameTime)
        {
            RecastPositions();

            if (player is IMovementNPC)
            {
                var temp = player as IMovementNPC;
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
                        effects.PlayJump();
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
