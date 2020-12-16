using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Movement;
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
        Rectangle Rectangle { get; set; }
        SpriteDefine CurrentSprite { get; }
        Dictionary<AnimatieTypes, SpriteDefine> Sprites { get; set; }
    }
}
