using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
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
    class MoveCommandNPC: AMovement
    {
        public MoveCommandNPC(IPlayerObject player, Level level):base(player,level,4,2)
        {

        }
        public override void CheckMovement(GameTime gameTime)
        {
            base.CheckMovement(gameTime);

            player.Type = AnimatieTypes.Idle;

            velocity.X += 1f;


            player.Positie = positie;
            player.Versnelling = velocity;
            player.Positie += player.Versnelling;

            player.Update(gameTime);
        }
    }
}
