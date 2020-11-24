using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.TileBuild
{
    class TileOpbouw
    {
        private int aantalCollideTiles = 54;
        private int aantalBackgroundTiles = 48;
        private int aantalForegroundTiles = 12;

        public List<Texture2D> CollideTiles { get; set; }
        public List<Texture2D> BackgroundTiles { get; set; }
        public List<Texture2D> ForegroundTiles { get; set; }

        public TileOpbouw(ContentManager Content)
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
        }
    }
}
