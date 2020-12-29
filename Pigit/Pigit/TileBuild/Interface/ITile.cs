using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.TileBuild
{
    interface ITile: ICollideTile
    {
        public void Draw(SpriteBatch spriteBatch);
    }
}
