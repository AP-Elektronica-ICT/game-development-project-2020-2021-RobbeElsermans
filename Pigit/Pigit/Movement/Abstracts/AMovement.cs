using Microsoft.Xna.Framework;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Objects;
using Pigit.Objects.Interfaces;
using Pigit.TileBuild;
using Pigit.TileBuild.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pigit.Movement
{
    abstract class AMovement
    {
        protected IPlayerObject player;
        protected Level level;
        protected bool isGround = false;

        protected float jumpHeight;
        protected float walkingSpeed;
        protected Vector2 positie;
        protected Vector2 velocity;

        protected bool hasJumped;

        public AMovement(IPlayerObject player, Level level, float jumpHeight = 6f, float walkSpeed = 2f)
        {
            this.player = player;
            this.level = level;
            hasJumped = true;
            isGround = false;
            this.jumpHeight = jumpHeight;
            this.walkingSpeed = walkSpeed;
        }

        public abstract void CheckMovement(GameTime gameTime);
        protected void RecastPositions()
        {
            positie = new Vector2(player.Positie.X, player.Positie.Y);
            velocity = new Vector2(0f, player.Velocity.Y);
        }

        protected virtual void CheckCollide(int offsetHeight1, int offsetHeight2)
        {
            isGround = false;

            foreach (var tile in level.CurrTiles)
            {
                if (tile is ICollideTile)
                {
                    var temp = tile as ICollideTile;
                    Rectangle rectangle = player.Rectangle;

                    if (EndBlockCollision.isTouchingRight(velocity, temp, rectangle) || EndBlockCollision.isTouchingLeft(velocity, temp, rectangle))
                    {
                        velocity.X = 0f;
                    }
                    if (EndBlockCollision.isTouchingTop(velocity, temp, rectangle) && !isGround)
                    {
                        positie.Y = temp.Border.Y - (temp.Border.Height - offsetHeight1);
                        velocity.Y = 0.2f;
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
                        positie.Y = temp.Border.Y - (temp.Border.Height - offsetHeight2);
                        velocity.Y = 0.2f;
                        isGround = true;
                    }
                }
            }
        }
        protected virtual void CheckGravity()
        {
            //Hit another object
            if (isGround)
            {
                velocity.Y = 0.2f;
                hasJumped = false;
            }
            else
            {
                float i = 1f;
                velocity.Y += 0.2f * i;
                hasJumped = true;
                //Debug.Print(velocity.Y.ToString());
            }

            player.Positie = positie;
            player.Velocity = velocity;
        }
    }
}
