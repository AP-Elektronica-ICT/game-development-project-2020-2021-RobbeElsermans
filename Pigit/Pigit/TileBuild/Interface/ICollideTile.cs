using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.TileBuild.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.TileBuild
{
    interface ICollideTile
    {
        public TileType Type { get;}
        public Rectangle Border { get;}
    }
}
