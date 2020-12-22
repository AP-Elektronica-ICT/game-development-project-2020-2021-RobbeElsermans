using Microsoft.Xna.Framework;
using Pigit.Animatie;
using Pigit.Movement;
using Pigit.Objects.Abstracts;
using Pigit.Objects.Enums;
using Pigit.SpriteBuild.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects.CollectableObjects
{
    class Item : AItemObject
    {
        public Item(Dictionary<AnimatieTypes, SpriteDefine> sprites,CollectableTypes type, Vector2 positie, MoveTypes movement) : base(sprites,type , positie, movement)
        {

        }
    }
}
