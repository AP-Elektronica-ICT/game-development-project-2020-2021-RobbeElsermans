using Microsoft.Xna.Framework;
using Pigit.Map;
using Pigit.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Movement
{
    abstract class AMovement
    {
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
            velocity = new Vector2(0f, player.Versnelling.Y);
        }
    }
}
