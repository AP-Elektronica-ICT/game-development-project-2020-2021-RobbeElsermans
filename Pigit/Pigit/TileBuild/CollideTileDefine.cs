using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pigit.TileBuild
{
    class CollideTileDefine : TileDefine, ICollideTile
    {
        private Vector2 position;
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

        public CollideTileDefine(Texture2D texture, int number) : base(texture, number) { }
    }
}
