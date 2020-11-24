using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.TileBuild.Interface
{
    interface IPlatformTile: ITile
    {
        public Rectangle Border { get; set; }
    }
}
