using Microsoft.Xna.Framework;
using Pigit.Movement.Enums;
using Pigit.Objects.Abstracts;
using Pigit.Objects.Enums;
using Pigit.SpriteBuild.Generator;

namespace Pigit.Objects.CollectableObjects
{
    class Item : AItemObject
    {
        public Item(CollectableTypes collectableType,SpriteGenerator sprites,CollectableTypes type, Vector2 positie, MoveTypes movement) : base(collectableType,sprites,type , positie, movement)
        {}
    }
}
