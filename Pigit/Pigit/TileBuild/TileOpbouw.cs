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
        public List<ICollideTile> CollideTiles { get; set; }
        public List< >BackgroundTiles { get; set; }

        public TileOpbouw(ContentManager Content)
        {
            CollideTiles = new List<ICollideTile>();
            for (int i = 1; i <= 54; i++)
            {
                string link = @"CollideTiles\CollideTile  (" + i + ")";

            CollideTiles.Add(new CollideTile(Content.Load<Texture2D>(link), i));
            }
        }
    }
}
