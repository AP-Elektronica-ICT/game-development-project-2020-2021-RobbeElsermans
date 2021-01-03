using Microsoft.Xna.Framework.Graphics;

namespace Pigit.TileBuild.Interface
{
    interface ITile: ICollideTile
    {
        public void Draw(SpriteBatch spriteBatch);
    }
}
