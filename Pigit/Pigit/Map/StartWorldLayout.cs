using Pigit.Map.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Map
{
    class StartWorldLayout: IRoomLayout
    {
        private const int width = 50;
        private const int height = 50;

        public int[,] CollideTileLayout { get; }
        public int[,] PlatformTiles { get; }
        public int[,] BackgroundTiles { get; }
        public int[,] ForegroundTiles { get; }
        public int[,] Enemys { get; set; }
        public int[,] Collectable { get; set; }

        public int Height { get { return width; } }
        public int Width { get { return height; } }


    }
}
