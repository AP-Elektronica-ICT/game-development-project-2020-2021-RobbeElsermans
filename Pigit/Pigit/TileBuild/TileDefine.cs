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
        protected Texture2D texture;
        public Vector2 Position { get; set; }
        public Rectangle Border { get; set; }
        public TileType Type { get; protected set; }

        public TileDefine(Texture2D texture, Vector2 position, TileType tileType)
        {
            this.texture = texture;
            this.Position = position;
            this.Type = tileType;

            if (Type != TileType.BackGroundTile)
            {
                Border = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}
