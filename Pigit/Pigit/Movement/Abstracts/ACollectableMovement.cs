using Microsoft.Xna.Framework;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Objects.Interfaces;
using Pigit.TileBuild;
using Pigit.TileBuild.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pigit.Movement.Abstracts
{
    class ACollectableMovement
    {
        protected ICollectableObject item;
        protected Level level;
        protected bool isGround = false;

        protected float jumpHeight;
        protected float walkingSpeed;
        protected Vector2 positie;
        protected Vector2 velocity;

        protected bool hasJumped;
        public static IMoveable HeroPlayer { get; set; }

        public ACollectableMovement(ICollectableObject item, Level level, float jumpHeight = 2f, float walkSpeed = 2f)
        {
            this.item = item;
            this.level = level;
            hasJumped = true;
            isGround = false;
            this.jumpHeight = jumpHeight;
            this.walkingSpeed = walkSpeed;
        }

        public virtual void CheckMovement(GameTime gameTime)
        {
            RecastPositions();

            CheckCollide(18, 18);
            CheckGravity();

            item.Update(gameTime);
        }
        protected void RecastPositions()
        {
            positie = new Vector2(item.Positie.X, item.Positie.Y);
            velocity = new Vector2(0f, item.Velocity.Y);
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
                velocity.Y += 0.20f * i;
            }

            item.Positie = positie;
            item.Velocity = velocity;
        }
        protected virtual void CheckCollide(int offsetHeight1, int offsetHeight2)
        {
            isGround = false;

            foreach (var tile in level.CurrTiles)
            {
                if (tile.Type == TileType.BorderTile)
                {
                    if (EndBlockCollision.isTouchingTop(velocity, tile.Border, item.Rectangle) && !isGround)
                    {
                        positie.Y = tile.Border.Y - (tile.Border.Height - offsetHeight1);
                        velocity.Y = 0.2f;
                        isGround = true;
                    }
                }

                if (tile.Type == TileType.PlatformTile)
                {
                    if (PlatformBlockCollision.isOnTopOf(item.Rectangle, tile.Border, velocity) && velocity.Y > 0)
                    {
                        positie.Y = tile.Border.Y - (tile.Border.Height - offsetHeight2);
                        velocity.Y = 0f;
                        isGround = true;
                    }
                }
            }
        }
    }
}
