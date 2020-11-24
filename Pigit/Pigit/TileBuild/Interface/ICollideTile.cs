using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.TileBuild
{
    interface ICollideTile : ITile
    {
        public Rectangle Border { get; set; }
    }
}
