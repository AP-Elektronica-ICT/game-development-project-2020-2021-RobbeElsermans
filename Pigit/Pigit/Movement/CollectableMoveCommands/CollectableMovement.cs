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
        public CollectableMovement(ICollectableObject player, Level level) : base(player, level)
        {

        }
    }
}
