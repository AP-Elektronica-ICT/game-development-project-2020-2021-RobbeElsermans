using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.TileBuild
{
    class TileDefine: ITile
    {
        protected Texture2D texture;
        public virtual Vector2 Position { get; set; }

        public TileDefine(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}
