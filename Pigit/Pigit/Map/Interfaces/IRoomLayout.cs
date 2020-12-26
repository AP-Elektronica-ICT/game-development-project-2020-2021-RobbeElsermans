using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Pigit.Map.Interfaces
{
    interface IRoomLayout
    {
        public int Width { get; }
        public int Height { get; }
        public int[,] CollideTileLayout { get; }
        public int[,] BackgroundTiles { get; }
        public int[,] ForegroundTiles { get; }
        public int[,] PlatformTiles { get; }
        public int[,] Enemys { get; set; }
        public int[,] Collectable { get; set; }
        public Vector2 StartPos { get; set; }
        public Vector2 Warp1 { get; set; }
        public Vector2 Warp2 { get; set; }
    }
}