using Microsoft.Xna.Framework;
using Pigit.Map;
using Pigit.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Movement.NPCMoveCommands
{
    class MoveCommandStaticNPC : AMovement
    {
        public MoveCommandStaticNPC(IPlayerObject player, Level level) : base(player, level, 4, 2)
        {

        }
        public override void CheckMovement(GameTime gameTime)
        {
            base.CheckMovement(gameTime);

            CheckCollide();
            CheckGravity();

            player.Update(gameTime);
        }
    }
}
