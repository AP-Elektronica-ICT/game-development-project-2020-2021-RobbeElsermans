using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.TileBuild.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.TileBuild
{
    class PlatformTileDefine: TileDefine, IPlatformTile
    {
        protected Vector2 position;
        public override Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                Border = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }
        public Rectangle Border { get; set; }

        public PlatformTileDefine(Texture2D texture, Vector2 position) : base(texture, position) { }

    }
}
