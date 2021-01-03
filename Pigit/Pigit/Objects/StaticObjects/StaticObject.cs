using Microsoft.Xna.Framework;
using Pigit.Animatie;
using Pigit.Objects.Abstracts;
using Pigit.SpriteBuild.Enums;
using System.Collections.Generic;

namespace Pigit.Objects.StaticObjects
{
    class StaticObject: AStaticObject
    {
        public StaticObject(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition): base(spriteOpbouw, beginPosition)
        {

        }
    }
}
