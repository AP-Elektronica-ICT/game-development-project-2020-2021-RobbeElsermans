using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Movement;
using Pigit.Objects.Abstracts;
using Pigit.Objects.Enums;
using Pigit.Objects.Interfaces;
using Pigit.SpriteBuild.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects.CollectableObjects
{
    class Hearts : AItemObject
    {
        public Hearts(Dictionary<AnimatieTypes, SpriteDefine> sprites, Vector2 positie, MoveTypes movement) : base(sprites, positie, movement)
        {

        }
        
    }
}
