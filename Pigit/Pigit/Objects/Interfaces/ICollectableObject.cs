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
        public MoveTypes MovementType { get; }
        public int Value { get; }
        public bool IsTaken { get;}
        public bool IsCollected { get; set; }
        public CollectableTypes ItemType { get;}
    }
}
