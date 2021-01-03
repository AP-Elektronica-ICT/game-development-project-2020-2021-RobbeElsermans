using Microsoft.Xna.Framework;
using Pigit.TileBuild.Enums;

namespace Pigit.TileBuild.Interface
{
    interface ICollideTile
    {
        public TileType Type { get;}
        public Rectangle Border { get;}
    }
}
