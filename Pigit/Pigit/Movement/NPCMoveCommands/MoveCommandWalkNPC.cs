using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Objects;
using Pigit.SpriteBuild.Enums;
using Pigit.TileBuild;
using Pigit.TileBuild.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pigit.Movement.NPCMoveCommands
{
    class MoveCommandWalkNPC : AMovement
    {
        private bool righting = false;
        private double timer;
        private bool isSetTimer = false;

        public MoveCommandWalkNPC(IPlayerObject player, Level level,int jumpHeight = 4,int walkspeed= 2) : base(player, level, jumpHeight, walkspeed)
        {

        }
        public override void CheckMovement(GameTime gameTime)
        {
            base.CheckMovement(gameTime);

            if(!isSetTimer)
            {
                timer = gameTime.TotalGameTime.TotalSeconds;
                isSetTimer = true;
            }

            player.Direction = righting;

            if (player.Direction)
            {
                velocity.X = -1;
                isGround = false;
                isSide = false;
            }
            else
            {
                velocity.X = 1;
                isGround = false;
                isSide = false;
            }

            if ((gameTime.TotalGameTime.TotalSeconds - timer > 5) && !hasJumped)
            {
                isSetTimer = false;
                velocity.Y = -jumpHeight;
                hasJumped = true;
                isGround = false;
            }

            this.CheckCollide();

            CheckGravity();

            player.Update(gameTime);
        }

        protected override void CheckCollide()
        {
            isGround = false;

            foreach (var tile in level.CurrTiles)
            {
                if (tile is ICollideTile)
                {
                    var temp = tile as ICollideTile;
                    Rectangle rectangle = player.Rectangle;

                    if (EndBlockCollision.isTouchingRight(velocity, temp, rectangle))
                    {
                        righting = false;
                        velocity.X = 0f;
                    }

                    if (EndBlockCollision.isTouchingLeft(velocity, temp, rectangle))
                    {
                        righting = true;
                        velocity.X = 0f;

                    }
                    if (EndBlockCollision.isTouchingTop(velocity, temp, rectangle) && !isGround)
                    {
                        positie.Y = temp.Border.Y - (temp.Border.Height - 4);
                        velocity.Y = 0f;
                        isGround = true;
                    }
                    if (EndBlockCollision.isTouchingBottom(velocity, temp, rectangle))
                    {
                        velocity.Y = 0f;
                    }
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
        }
    }
}
