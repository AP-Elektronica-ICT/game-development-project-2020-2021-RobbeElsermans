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
            {0,0,0,0,0,0,0,0,0,0},
            {0,52,17,17,17,17,17,17,53,0},
            {0,6,0,0,0,0,0,0,5,0},
            {0,6,0,0,0,0,0,0,5,0},
            {0,6,0,0,0,0,0,0,5,0},
            {0,6,0,0,0,0,0,0,5,0},
            {0,6,0,0,0,0,0,0,5,0},
            {0,6,0,0,0,0,0,0,5,0},
            {0,8,49,49,49,49,49,49,9,0},
            {0,0,0,0,0,0,0,0,0,0},
        };
            BackgroundTiles = new int[width, height]
        {
            {2,2,2,2,2,2,2,2,2,2},
            {2,0,0,0,0,0,0,0,0,2},
            {2,0,3,4,4,4,4,5,0,2},
            {2,0,14,15,15,15,15,16,0,2},
            {2,0,14,15,15,15,15,16,0,2},
            {2,0,14,15,15,15,15,16,0,2},
            {2,0,14,15,15,15,15,16,0,2},
            {2,0,26,27,27,27,27,28,0,2},
            {2,0,0,0,0,0,0,0,0,2},
            {2,2,2,2,2,2,2,2,2,2}
        };
            ForegroundTiles = new int[width, height]
        {
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,1,0,4,5,0,0,0},
            {0,0,0,2,0,9,10,0,0,0},
            {0,0,0,3,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0}
        };
        }
    }
}
