using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.TileBuild.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.TileBuild
{
    class TileDefine: ITile
    {
        private Texture2D texture;
        private Vector2 position;
        public Rectangle Border { get; private set; }
        public TileType Type { get; protected set; }

        public TileDefine(Texture2D texture, Vector2 position, TileType tileType)
        {
            this.texture = texture;
            this.position = position;
            this.Type = tileType;

            if (Type != TileType.BackGroundTile)
            {
                Border = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
