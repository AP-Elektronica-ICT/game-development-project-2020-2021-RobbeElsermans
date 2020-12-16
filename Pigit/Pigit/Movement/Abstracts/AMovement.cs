using Microsoft.Xna.Framework;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Objects;
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
        public static IMoveable HeroPlayer { get; set; }
        protected IInputReader keyboard;
        protected IPlayerObject player;
        protected Level level;
        protected bool isGround = false;
        protected bool isSide = false;

        protected float jumpHeight = 6f;
        protected float walkingSpeed = 2f;
        protected Vector2 positie;
        protected Vector2 velocity;

        protected bool hasJumped;

        public AMovement(IPlayerObject player, Level level, float jumpHeight = 6f, float walkSpeed = 2f)
        {
            keyboard = new KeyBoardReader();
            this.player = player;
            this.level = level;
            hasJumped = true;
            isGround = false;
            isSide = false;
            this.jumpHeight = jumpHeight;
            this.walkingSpeed = walkSpeed;
        }

        public virtual void CheckMovement(GameTime gameTime)
        {
            positie = new Vector2(player.Positie.X, player.Positie.Y);
            velocity = new Vector2(0f, player.Velocity.Y);
        }
        protected virtual void CheckCollide()
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
                        velocity.X = 0f;
                    }

                    if (EndBlockCollision.isTouchingLeft(velocity, temp, rectangle))
                    {
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
            CheckDistance();

        }
        protected virtual void CheckGravity()
        {
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
        }

        protected virtual void CheckDistance()
        {
            if (player is IMovementEnemy)
            {
                var temp = player as IMovementEnemy;
                if (NPCCollision.IsAroundNPC(HeroPlayer.Positie, positie))
                {
                    temp.MovementType = MoveTypes.Follow;
                }
                else
                {
                    temp.MovementType = MoveTypes.Static;
                }
            }
        }
    }
}
