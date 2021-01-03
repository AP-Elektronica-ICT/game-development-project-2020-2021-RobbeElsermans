using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pigit.Objects.Interfaces
{ 
    interface IObject
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch _spriteBatch);
        //public SpriteDefine CurrentSprite { get; }
    }
}
