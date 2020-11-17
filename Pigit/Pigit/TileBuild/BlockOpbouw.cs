using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.TileBuild
{
    class BlockOpbouw
    {
        public List<ITile> Blocks { get; set; }

        public BlockOpbouw(ContentManager Content)
        {
            Blocks = new List<ITile>();
            for (int i = 1; i <= 54; i++)
            {
                string link = @"CollideTiles\CollideTile  (" + i + ")";

                Blocks.Add(new CollideTile(Content.Load<Texture2D>(link), i));
            }
        }
    }
}
