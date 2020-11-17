using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pigit
{
    interface IGameObject
    {
        Vector2 Positie { get; set; }
        void Update(GameTime gameTime, Vector2 verplaatsing);
        void Draw(SpriteBatch _spriteBatch);
    }
}
