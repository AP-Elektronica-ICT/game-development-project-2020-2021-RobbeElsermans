using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pigit
{
    interface IGameObject
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch _spriteBatch);
    }
}
