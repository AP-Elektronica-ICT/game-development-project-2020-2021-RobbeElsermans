using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects
{
    interface IPlayerObject : IGameObject
    {
        public bool Direction { get; set; }
        public static Vector2 Positie { get; set; }
        public int FrameCount { get; }
        public int AmountFrames { get; set; }
    }
}
