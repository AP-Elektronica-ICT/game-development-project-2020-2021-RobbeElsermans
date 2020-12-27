using Pigit.Movement;
using Pigit.Objects.Enums;
using Pigit.SpriteBuild.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects.Interfaces
{
    interface ICollectableObject: IObject, IMoveable
    {
        public MoveTypes MovementType { get; set; }
        public int Value { get; }
        public bool IsTaken { get; set; }
        public bool IsCollected { get; set; }
        public CollectableTypes ItemType { get;}
    }
}
