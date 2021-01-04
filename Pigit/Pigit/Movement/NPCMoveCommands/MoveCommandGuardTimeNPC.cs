using Microsoft.Xna.Framework;
using Pigit.Collision;
using Pigit.Map;
using Pigit.Movement.Abstracts;
using Pigit.Music.Interface;
using Pigit.Objects.Abstracts;
using Pigit.TileBuild.Enums;

namespace Pigit.Movement.NPCMoveCommands
{
    class MoveCommandGuardTimeNPC : AMoveCommandFollowWhenNearby
    {
        private bool righting = false;
        private double timer1;
        private double timer2;
        private bool isSetTimer1 = false;
        private bool isSetTimer2 = false;

        private double walkTime = 1;
        private double stopTime = 3;

        private float minX;
        private float maxX;

        private bool time = false;
        private bool position = false;

        private bool hasFollow = false;

        public MoveCommandGuardTimeNPC(AEnemyObject player, Level level, IEffectMusic effect, double walkTime = 2.0, double stopTime = 3.0, float jumpHeight = 4, float walkspeed = 2) : base(player, level, effect, jumpHeight, walkspeed)
        {
            this.walkTime = walkTime;
            this.stopTime = stopTime;
            time = true;
        }
        public override void CheckMovement(GameTime gameTime)
        {
            RecastPositions();

            if (NPCCollision.IsAroundNPC(HeroPlayer.Positie, positie))
            {
                base.CheckMovement(gameTime);
                hasFollow = true;
            }
            else
            {
                if (hasFollow)
                {
                    minX = positie.X - 32f;
                    maxX = positie.X + 32f;
                    hasFollow = false;
                }

                #region met Tijd Guard
                if (time)
                {
                    if (!isSetTimer1)
                    {
                        timer1 = gameTime.TotalGameTime.TotalSeconds;
                        isSetTimer1 = true;
                    }

                    player.Direction = righting;

                    if (player.Direction)
                    {
                        velocity.X = -1;

                    }
                    else
                    {
                        velocity.X = 1;

                    }
                    if ((gameTime.TotalGameTime.TotalSeconds - timer1 > walkTime))
                    {
                        velocity.X = 0;

                        if (!isSetTimer2)
                        {
                            timer2 = gameTime.TotalGameTime.TotalSeconds;
                            isSetTimer2 = true;
                        }

                        if ((gameTime.TotalGameTime.TotalSeconds - timer2 > stopTime))
                        {
                            isSetTimer2 = false;
                            isSetTimer1 = false;
                            righting = !righting;
                        }
                    }
                }
                #endregion


                this.CheckCollide(5, 5);

                CheckGravity();

                player.Positie = positie;
                player.Velocity = velocity;
                //player.Positie += player.Versnelling;

                player.Update(gameTime);
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
