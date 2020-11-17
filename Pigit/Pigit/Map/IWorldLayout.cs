using System.Collections.Generic;

namespace Pigit.Map
{
    internal interface IWorldLayout
    {
        public int Width { get; }
        public int Height { get; }
        public int[,] CollideTileLayout { get; }
        public int[,] BackgroundTiles { get; }
        public int[,] ForegroundTiles { get; }
    }
}