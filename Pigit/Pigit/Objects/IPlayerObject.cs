using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects
{
    interface IPlayerObject : IGameObject
    {
        bool Direction { get; set; }
        Vector2 Positie { get; set; }
        Vector2 Versnelling { get; set; }
        AnimatieTypes Type { get; set; }
    }
}
