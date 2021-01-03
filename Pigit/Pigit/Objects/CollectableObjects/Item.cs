using Microsoft.Xna.Framework;
using Pigit.Animatie;
using Pigit.Movement.Enums;
using Pigit.Objects.Abstracts;
using Pigit.Objects.Enums;
using Pigit.SpriteBuild.Enums;
using System.Collections.Generic;

namespace Pigit.Objects.CollectableObjects
{
    class Item : AItemObject
    {
        public Item(Dictionary<AnimatieTypes, SpriteDefine> sprites,CollectableTypes type, Vector2 positie, MoveTypes movement, int value) : base(sprites,type , positie, movement,value)
        {}
    }
}
