using Pigit.TileBuild;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Map
{
    class World1Opbouw
    {
        private byte[,] mapLayout;
        private List<ICollideTile> collideItems;

        World1Opbouw(List<ICollideTile> collideItems)
        {
            this.collideItems = collideItems;
        }
    }
}
