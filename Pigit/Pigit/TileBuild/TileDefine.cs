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
        public int Number { get; set; }

        public TileDefine(Texture2D texture, int number)
        {
            this.texture = texture;
            this.Number = number;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}
