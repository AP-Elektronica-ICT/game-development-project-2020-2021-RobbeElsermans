using Pigit.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects.Interfaces
{
    interface ICollectableObject: IObject
    {
        public int Value { get; }
        public bool IsTaken { get; set; }
        public bool IsCollected { get; set; }
        public SizeCollectable Size { get;}
    }
}
