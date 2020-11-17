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

        public List<ICollideTile> CollideTiles { get; set; }
        public List<ITile> BackgroundTiles { get; set; }
        public List<ITile> ForegroundTiles { get; set; }

        public TileOpbouw(ContentManager Content)
        {
            CollideTiles = new List<ICollideTile>();
            for (int i = 1; i <= aantalCollideTiles; i++)
            {
                string link = @"CollideTiles\CollideTile  (" + i + ")";

                CollideTiles.Add(new CollideTileDefine(Content.Load<Texture2D>(link), i));
            }


            BackgroundTiles = new List<ITile>();
            for (int i = 1; i <= aantalBackgroundTiles; i++)
            {
                string link = @"BackgroundTiles\BackgroundTile  (" + i + ")";

                BackgroundTiles.Add(new TileDefine(Content.Load<Texture2D>(link), i));
            }


            ForegroundTiles = new List<ITile>();
            for (int i = 1; i <= aantalForegroundTiles; i++)
            {
                string link = @"ForegroundTiles\ForegroundTile  (" + i + ")";

                ForegroundTiles.Add(new TileDefine(Content.Load<Texture2D>(link), i));
            }
        }
    }
}
