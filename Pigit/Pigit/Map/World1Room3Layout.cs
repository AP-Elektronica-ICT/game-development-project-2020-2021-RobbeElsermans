﻿using Microsoft.Xna.Framework;
using Pigit.Map.Interfaces;
using Pigit.Objects.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Map
{
    class World1Room3Layout : IRoomLayout
    {
        private const int width = 20;
        private const int height = 20;

        public int[,] CollideTileLayout { get; }
        public int[,] PlatformTiles { get; }
        public int[,] BackgroundTiles { get; }
        public int[,] ForegroundTiles { get; }
        public int[,] Enemys { get; set; }
        public int[,] Collectable { get; set; }
        public Vector2 StartPos { get; set; }

        public Vector2 Warp1 { get; set; }
        public Vector2 Warp2 { get; set; }
        public List<Vector2> Doors { get; set; }

        public int Height { get { return width; } }
        public int Width { get { return height; } }

        public World1Room3Layout()
        {
            StartPos = new Vector2(32 * 14, 32 * 14);
            Warp1 = new Vector2(32 * 6, 32 * 17);
            Warp2 = Vector2.Zero;
            Doors = new List<Vector2>();

            if (StartPos != Vector2.Zero)
            {
                Doors.Add(new Vector2(StartPos.X + 32, StartPos.Y + 9));
            }
            if (Warp1 != Vector2.Zero)
            {
                Doors.Add(new Vector2(Warp1.X + 32, Warp1.Y + 9));
            }
            if (Warp2 != Vector2.Zero)
            {
                Doors.Add(new Vector2(Warp2.X + 32, Warp2.Y + 9));
            }


            CollideTileLayout = new int[width,height]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,44,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,45,0 },
                { 0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0 },
                { 0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0 },
                { 0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0 },
                { 0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0 },
                { 0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0 },
                { 0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0 },
                { 0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0 },
                { 0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0 },
                { 0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0 },
                { 0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0 },
                { 0,6,0,0,0,0,40,42,0,0,0,0,0,0,0,0,0,40,9,0 },
                { 0,6,0,0,0,0,5,6,0,0,0,0,0,0,0,0,0,5,0,0 },
                { 0,6,0,0,0,0,16,32,29,27,0,0,0,0,0,0,0,5,0,0 },
                { 0,6,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,5,0,0 },
                { 0,6,0,0,0,0,0,0,0,34,41,41,41,41,41,41,41,9,0,0 },
                { 0,6,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0 },
                { 0,6,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0 },
                { 0,8,41,41,41,41,41,41,41,9,0,0,0,0,0,0,0,0,0,0 }
            };
            BackgroundTiles = new int[width, height]
            {
                { 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                { 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                { 2,2,3,4,4,4,4,4,4,4,4,4,4,4,4,4,4,5,2,2},
                { 2,2,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,16,2,2},
                { 2,2,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,16,2,2},
                { 2,2,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,16,2,2},
                { 2,2,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,16,2,2},
                { 2,2,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,16,2,2},
                { 2,2,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,16,2,2},
                { 2,2,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,16,2,2},
                { 2,2,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,16,2,2},
                { 2,2,14,15,15,7,27,27,8,15,15,15,15,15,15,15,7,28,2,2},
                { 2,2,14,15,15,16,2,2,14,15,15,15,15,15,15,15,16,2,2,2},
                { 2,2,14,15,15,16,2,2,26,27,8,15,15,15,15,15,16,2,2,2},
                { 2,2,14,15,15,16,2,2,2,2,14,15,15,15,15,15,16,2,2,2},
                { 2,2,14,15,15,18,4,4,5,2,26,27,27,27,27,27,28,2,2,2},
                { 2,2,14,15,15,15,15,15,16,2,2,2,2,2,2,2,2,2,2,2},
                { 2,2,14,15,15,15,15,15,16,2,2,2,2,2,2,2,2,2,2,2},
                { 2,2,26,27,27,27,27,27,28,2,2,2,2,2,2,2,2,2,2,2},
                { 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
            };
            PlatformTiles = new int[width, height]
{
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,1,3,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,5,6,0,0 },
                { 0,0,0,0,0,0,0,1,3,0,0,0,1,3,0,0,0,0,0,0 },
                { 0,0,0,1,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,1,3,0,0,0,1,3,0,0,0,0 },
                { 0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
                };
            ForegroundTiles = new int[width, height]
{
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,9,10,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,6,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,11,12,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,4,5,0,0,1,0,1,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,9,10,0,0,2,0,2,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,3,0,3,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
                };
            Enemys = new int[width, height]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
                };
            Collectable = new int[width, height]
{
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,1,0,1,0,3,0,3,0,1,0,3,0,1,0,1,0,0 },
                { 0,0,0,4,0,0,2,0,0,4,0,0,4,0,0,2,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,3,0,3,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,4,3,0,2,0,0,2,0,0,2,3,0,0,4,3,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
    };
        }
    }
}
