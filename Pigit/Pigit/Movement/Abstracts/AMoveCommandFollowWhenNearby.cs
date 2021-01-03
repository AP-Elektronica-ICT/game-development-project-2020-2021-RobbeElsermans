using Microsoft.Xna.Framework;
using Pigit.Collision;
using Pigit.Map;
using Pigit.Music.Interface;
using Pigit.Objects.Abstracts;
using Pigit.Objects.Interfaces;

namespace Pigit.Movement.Abstracts
{
    class AMoveCommandFollowWhenNearby : AEnemyMovement
    {
        public static IMoveable HeroPlayer { get; set; }
        public AMoveCommandFollowWhenNearby(AEnemyObject player, Level level,IEffectMusic effect, float jumpHeight = 4, float walkspeed = 2) : base(player, level, effect, jumpHeight, walkspeed)
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
                effects.PlayJump();
                velocity.Y = -jumpHeight;
                hasJumped = true;
                isGround = false;
            }
            else
            {
                //effects.StopJump();
            }

            player.IsAttacking = false;
            if (NPCCollision.IsTouchingNPC(HeroPlayer.Rectangle, player.Rectangle))
            {
                player.IsAttacking = true;
                player.Attack.NPCAttack(HeroPlayer as IPlayerObject, player,gameTime, effects);
            }

            CheckCollide(4,5);
            CheckGravity();

            player.Update(gameTime);
        }
    }
}

