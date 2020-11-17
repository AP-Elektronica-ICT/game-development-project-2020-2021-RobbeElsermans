using Pigit.TileBuild;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Map
{
    class World1Opbouw
    {
        private byte[,] mapLayout;
        private List<ITile> collideItems;

        World1Opbouw(List<ITile> collideItems)
        {
            this.collideItems = collideItems;
        }
    }
}
