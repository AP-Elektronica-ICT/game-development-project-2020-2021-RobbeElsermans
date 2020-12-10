using Microsoft.Xna.Framework;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Objects;
using Pigit.TileBuild;
using Pigit.TileBuild.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Movement
{
    class MoveCommandGuardNPC: AMovement
    {
        private bool righting = false;
        private double timer1;
        private double timer2;
        private bool isSetTimer1 = false;
        private bool isSetTimer2 = false;

        private int walkTime = 1;
        private int stopTime = 3;
        public MoveCommandGuardNPC(IPlayerObject player, Level level) : base(player, level, 4, 2)
        {

        }
        public override void CheckMovement(GameTime gameTime)
        {
            base.CheckMovement(gameTime);

            if (!isSetTimer1)
            {
                timer1 = gameTime.TotalGameTime.TotalSeconds;
                isSetTimer1 = true;
            }

            player.Direction = righting;

            if (player.Direction)
            {
                velocity.X = -1;
                isSide = false;
            }
            else
            {
                velocity.X = 1;
                isSide = false;
            }

            #region met Tijd Guard
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
            #endregion

            isGround = false;

            foreach (var tile in level.Tiles)
            {
                if (tile is ICollideTile)
                {
                    var temp = tile as ICollideTile;
                    Rectangle rectangle = player.Rectangle;

                    if (EndBlockCollision.isTouchingRight(velocity, temp, rectangle)) velocity.X = 0f;
                    if (EndBlockCollision.isTouchingLeft(velocity, temp, rectangle)) velocity.X = 0f;
                    if (EndBlockCollision.isTouchingTop(velocity, temp, rectangle) && !isGround)
                    {
                        positie.Y = temp.Border.Y - (temp.Border.Height - 4);
                        velocity.Y = 0f;
                        isGround = true;
                    }
                    if (EndBlockCollision.isTouchingBottom(velocity, temp, rectangle)) velocity.Y = 0f;
                }

                if (tile is IPlatformTile)
                {
                    var temp = tile as IPlatformTile;
                    Rectangle rectangle = player.Rectangle;

                    if (PlatformBlockCollision.isOnTopOf(rectangle, temp.Border, velocity) && velocity.Y > 0)
                    {
                        positie.Y = temp.Border.Y - (temp.Border.Height - 5);
                        velocity.Y = 0f;
                        isGround = true;
                    }
                }
            }

            //Hit another object
            if (isGround)
            {
                velocity.Y = 0f;
                hasJumped = false;
            }
            else
            {
                float i = 1f;
                velocity.Y += 0.20f * i;
            }

            player.Positie = positie;
            player.Velocity = velocity;
            //player.Positie += player.Versnelling;

            player.Update(gameTime);
        }
    }
}
