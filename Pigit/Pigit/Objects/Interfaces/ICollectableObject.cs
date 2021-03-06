﻿using Pigit.Movement.Enums;
using Pigit.Objects.Enums;

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
