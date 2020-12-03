using System.Collections.Generic;

namespace Pigit.Map
{
    interface IWorldLayout
    {
        public int Width { get; }
        public int Height { get; }
        public int[,] CollideTileLayout { get; }
        public int[,] BackgroundTiles { get; }
        public int[,] ForegroundTiles { get; }
        public int[,] PlatformTiles { get; }
        public int[,] Enemys { get; set; }
    }
}