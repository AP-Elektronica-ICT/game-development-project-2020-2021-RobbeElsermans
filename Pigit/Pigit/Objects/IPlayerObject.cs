using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects
{
    interface IPlayerObject : IGameObject
    {
        public static bool Direction { get; set; }
        public static Vector2 Positie { get; set; }
    }
}
