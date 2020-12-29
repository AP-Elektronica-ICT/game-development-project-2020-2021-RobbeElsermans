using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.TileBuild
{
    class TileGenerator
    {
        private const int aantalCollideTiles = 46;
        private const int aantalBackgroundTiles = 48;
        private const int aantalForegroundTiles = 12;
        private const int aantalPlatformTiles = 8;

        public List<Texture2D> CollideTiles { get; private set; }
        public List<Texture2D> BackgroundTiles { get; private set; }
        public List<Texture2D> ForegroundTiles { get; private set; }
        public List<Texture2D> PLatformTiles { get; private set; }

        public TileGenerator(ContentManager Content)
        {
            CollideTiles = new List<Texture2D>();
            for (int i = 1; i <= aantalCollideTiles; i++)
            {
                string link = @"CollideTiles\CollideTile  (" + i + ")";

                CollideTiles.Add(Content.Load<Texture2D>(link));
            }

            BackgroundTiles = new List<Texture2D>();
            for (int i = 1; i <= aantalBackgroundTiles; i++)
            {
                string link = @"BackgroundTiles\BackgroundTile  (" + i + ")";

                BackgroundTiles.Add(Content.Load<Texture2D>(link));
            }

            ForegroundTiles = new List<Texture2D>();
            for (int i = 1; i <= aantalForegroundTiles; i++)
            {
                string link = @"ForegroundTiles\ForegroundTile  (" + i + ")";

                ForegroundTiles.Add(Content.Load<Texture2D>(link));
            }

            PLatformTiles = new List<Texture2D>();
            for (int i = 1; i <= aantalPlatformTiles; i++)
            {
                string link = @"PlatformTiles\PlatformTile  (" + i + ")";

                PLatformTiles.Add(Content.Load<Texture2D>(link));
            }
        }
    }
}
