using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Map
{
    class World1Layout : IWorldLayout
    {

        private const int width = 10;
        private const int height = 10;

        public int[,] CollideTileLayout { get; }
        public int[,] BackgroundTiles { get; }
        public int[,] ForegroundTiles { get; }

        public int Height { get { return width; } }
        public int Width { get { return height; } }

        public World1Layout()
        {
            CollideTileLayout = new int[width, height]
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1}
        };
            BackgroundTiles = new int[width, height]
        {
            {2,2,2,2,2,2,2,2,2,2},
            {2,0,0,0,0,0,0,0,0,2},
            {2,0,3,4,4,4,4,5,0,2},
            {2,0,14,7,7,7,7,16,0,2},
            {2,0,14,7,7,7,7,16,0,2},
            {2,0,14,7,7,7,7,16,0,2},
            {2,0,14,7,7,7,7,16,0,2},
            {2,0,48,27,27,27,27,28,0,2},
            {2,0,0,0,0,0,0,0,0,2},
            {2,2,2,2,2,2,2,2,2,2}
        };
            ForegroundTiles = new int[width, height]
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,0,0,0}
        };
        }
    }
}
