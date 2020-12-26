using Microsoft.Xna.Framework;
using Pigit.Map.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Map
{
    class StartWorldLayout : IRoomLayout
    {
        private const int width = 10;
        private const int height = 10;

        public int[,] CollideTileLayout { get; }
        public int[,] PlatformTiles { get; }
        public int[,] BackgroundTiles { get; }
        public int[,] ForegroundTiles { get; }
        public int[,] Enemys { get; set; }
        public int[,] Collectable { get; set; }
        public Vector2 StartPos { get; set; }
        public Vector2 Warp1 { get; set; }
        public Vector2 Warp2 { get; set; }

        public int Height { get { return width; } }
        public int Width { get { return height; } }

        public StartWorldLayout()
        {
            StartPos = new Vector2(32 * 3, 32 * 2);
            Warp1 = Vector2.Zero;
            Warp2 = Vector2.Zero;

            CollideTileLayout = new int[width, height]
            {
                { 44,17,17,17,17,17,17,17,17,45 },
                { 6,0,0,0,0,0,0,0,0,5 },
                { 6,0,0,0,0,0,0,0,0,5 },
                { 6,0,0,0,0,0,0,0,0,5 },
                { 6,0,0,0,0,0,0,0,0,5 },
                { 6,0,0,0,0,0,0,0,0,5 },
                { 6,0,0,0,0,0,0,0,0,5 },
                { 6,0,0,0,0,0,0,0,0,5 },
                { 6,0,0,0,0,0,0,0,0,5 },
                { 8,41,41,41,41,41,41,41,41,9 }
            };
            PlatformTiles = new int[width, height]
{
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,6,7,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,8,0,0 },
                { 0,0,0,0,8,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,5,6,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,1,2,2,3,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 }
};
            BackgroundTiles = new int[width, height]
{
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,3,4,4,4,4,4,4,5,0 },
                { 0,14,15,15,15,15,15,15,28,0 },
                { 0,14,15,15,15,15,15,15,28,0 },
                { 0,14,15,15,15,15,15,15,28,0 },
                { 0,14,15,15,15,15,15,15,28,0 },
                { 0,14,15,15,15,15,15,15,28,0 },
                { 0,14,15,15,15,15,15,15,28,0 },
                { 0,26,27,27,27,27,27,27,28,0 },
                { 0,0,0,0,0,0,0,0,0,0 }
};
            ForegroundTiles = new int[width, height]
{
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,4,5,0,0,0,0,0,0,0 },
                { 0,9,10,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,1,0,0,0,0 },
                { 0,0,0,0,0,2,0,0,0,0 },
                { 0,0,0,0,0,3,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 }
};
            Enemys = new int[width, height]
{
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,12,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,10,11,12,13,14,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 }
};
            Collectable = new int[width, height]
{
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,1,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,4,0,0,0,0 },
                { 0,0,0,3,0,0,0,0,0,0 },
                { 0,0,1,0,2,0,4,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 }
};
        }

    }
}
