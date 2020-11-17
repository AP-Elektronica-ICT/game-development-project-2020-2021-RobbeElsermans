using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pigit.TileBuild
{
    class CollideTile: ICollideTile
    {
        private Texture2D texture;
        private Vector2 position;
        public Vector2 Position
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

        public int Number { get; set; }
        public Rectangle Border { get; set; }

        public CollideTile(Texture2D texture, int number)
        {
            this.texture = texture;
            this.Number = number;
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, Position, Color.White);
        }
    }
}
