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
    class MoveCommandStaticNPC : AMoveCommandFollowWhenNearby
    {
        public MoveCommandStaticNPC(AEnemyObject player, Level level,IEffectMusic effect) : base(player, level,effect, 4, 2)
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

                    CheckCollide(4,5);
                    CheckGravity();

                    player.Update(gameTime);
                }
            }
        }
    }
}
