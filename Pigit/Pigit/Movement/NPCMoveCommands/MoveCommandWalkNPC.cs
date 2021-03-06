﻿using Microsoft.Xna.Framework;
using Pigit.Collision;
using Pigit.Map;
using Pigit.Movement.Abstracts;
using Pigit.Movement.Interfaces;
using Pigit.Music.Interface;
using Pigit.Objects.Abstracts;
using Pigit.TileBuild.Enums;

namespace Pigit.Movement.NPCMoveCommands
{
    class MoveCommandWalkNPC : AMoveCommandFollowWhenNearby
    {
        private bool righting = false;
        private double timer;
        private bool isSetTimer = false;
        private float timeOnJump;

        public MoveCommandWalkNPC(AEnemyObject player, Level level, IEffectMusic effect, float jumpHeight = 4,float walkspeed= 2, float timeOnJump = 5) : base(player, level,effect ,jumpHeight, walkspeed)
        {
            this.timeOnJump = timeOnJump;
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
                    if (!isSetTimer)
                    {
                        timer = gameTime.TotalGameTime.TotalSeconds;
                        isSetTimer = true;
                    }

                    player.Direction = righting;

                    if (player.Direction)
                    {
                        velocity.X = -1;
                        isGround = false;
                    }
                    else
                    {
                        velocity.X = 1;
                        isGround = false;

                    }

                    if ((gameTime.TotalGameTime.TotalSeconds - timer > timeOnJump) && !hasJumped)
                    {
                        effects.PlayJump();
                        isSetTimer = false;
                        velocity.Y = -jumpHeight;
                        hasJumped = true;
                        isGround = false;
                    }

                    this.CheckCollide(4,5);

                    CheckGravity();

                    player.Update(gameTime);
                }
            }
        }

        protected override void CheckCollide(int offsetHeight1, int offsetHeight2)
        {
            isGround = false;

            foreach (var tile in level.CurrTiles)
            {
                if (tile.Type == TileType.BorderTile)
                {
                    if (EndBlockCollision.isTouchingRight(velocity, tile.Border, player.Rectangle))
                    {
                        righting = false;
                        velocity.X = 0f;
                    }

                    if (EndBlockCollision.isTouchingLeft(velocity, tile.Border, player.Rectangle))
                    {
                        righting = true;
                        velocity.X = 0f;

                    }
                    if (EndBlockCollision.isTouchingTop(velocity, tile.Border, player.Rectangle) && !isGround)
                    {
                        positie.Y = tile.Border.Y - (tile.Border.Height - 4);
                        velocity.Y = 0f;
                        isGround = true;
                    }
                    if (EndBlockCollision.isTouchingBottom(velocity, tile.Border, player.Rectangle))
                    {
                        velocity.Y = 0f;
                    }
                }

                if (tile.Type == TileType.PlatformTile)
                {
                    if (PlatformBlockCollision.isOnTopOf(player.Rectangle, tile.Border, velocity) && velocity.Y > 0)
                    {
                        positie.Y = tile.Border.Y - (tile.Border.Height - 5);
                        velocity.Y = 0f;
                        isGround = true;
                    }
                }
            }
        }
    }
}
