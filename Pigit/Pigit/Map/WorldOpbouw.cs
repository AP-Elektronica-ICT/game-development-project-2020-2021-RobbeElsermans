using Pigit.TileBuild;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Map
{
    class WorldOpbouw
    {
        private byte[,] mapLayout1;
        private List<ICollideTile> collideTiles;
        private List<ITile> backgroundTiles;
        private List<ITile> foregroundTiles;

        WorldOpbouw(List<ICollideTile> collideTiles)
        {
            this.collideTiles = collideTiles;
        }
    }
}
