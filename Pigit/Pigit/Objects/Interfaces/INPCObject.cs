using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.SpriteBuild;
using Pigit.SpriteBuild.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects
{
    interface INPCObject: IMoveable
    {
        bool Direction { get; set; }
        AnimatieTypes Type { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch _spriteBatch);
        public Rectangle Rectangle { get; set; }
        public SpriteDefine CurrentSprite { get; }
        public Dictionary<AnimatieTypes, SpriteDefine> Sprites { get; set; }
    }
}
