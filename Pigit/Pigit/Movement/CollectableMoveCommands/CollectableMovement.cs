using Microsoft.Xna.Framework;
using Pigit.Map;
using Pigit.Movement.Abstracts;
using Pigit.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Movement.CollectableMoveCommands
{
    class CollectableMovement : ACollectableMovement
    {
        private double timer;
        private bool isSetTimer = false;

        public CollectableMovement(ICollectableObject player, Level level) : base(player, level)
        {

        }
        public override void CheckMovement(GameTime gameTime)
        {
            RecastPositions();

            if (!isSetTimer)
            {
                timer = gameTime.TotalGameTime.TotalSeconds;
                isSetTimer = true;
            }

            if ((gameTime.TotalGameTime.TotalSeconds - timer > 3) && !hasJumped)
            {
                isSetTimer = false;
                velocity.Y = -jumpHeight;
                hasJumped = true;
                isGround = false;
            }

            CheckCollide(18, 18);
            CheckGravity();

            item.Update(gameTime);
        }
    }
}
