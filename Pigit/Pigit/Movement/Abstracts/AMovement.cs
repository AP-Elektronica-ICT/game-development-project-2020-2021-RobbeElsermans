using Microsoft.Xna.Framework;
using Pigit.Collison;
using Pigit.Map;
using Pigit.Music;
using Pigit.Music.Interface;
using Pigit.Objects;
using Pigit.Objects.Interfaces;
using Pigit.TileBuild;
using Pigit.TileBuild.Enums;
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
        protected IEffectMusic effects;

        public AMovement(IPlayerObject player, Level level,IEffectMusic effects, float jumpHeight = 6f, float walkSpeed = 2f)
        {
            this.player = player;
            this.level = level;
            hasJumped = true;
            isGround = false;
            this.jumpHeight = jumpHeight;
            this.walkingSpeed = walkSpeed;
            this.effects = effects;
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
                if (tile.Type == TileType.BorderTile)
                {
                    if (EndBlockCollision.isTouchingRight(velocity, tile.Border, player.Rectangle) || EndBlockCollision.isTouchingLeft(velocity, tile.Border, player.Rectangle))
                    {
                        velocity.X = 0f;
                    }
                    if (EndBlockCollision.isTouchingTop(velocity, tile.Border, player.Rectangle) && !isGround)
                    {
                        positie.Y = tile.Border.Y - (tile.Border.Height - offsetHeight1);
                        velocity.Y = 0.2f;
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
                        positie.Y = tile.Border.Y - (tile.Border.Height - offsetHeight2);
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
            }

            player.Positie = positie;
            player.Velocity = velocity;
        }
    }
}
