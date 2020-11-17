using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.TileBuild
{
    class BackGroundTileDefine
    {
        private Texture2D texture { get; set; }
        public int Number { get; set; }
        public Vector2 Position { get; set; }

        public BackGroundTileDefine(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}
