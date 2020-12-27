using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;

using Pigit.Movement;
using Pigit.Objects;
using Pigit.Attack;
using Pigit.SpriteBuild.Enums;

namespace Pigit.Objects.Interfaces
{
    interface IPlayerObject: IObject, IResetAble, ICollector, IMoveable, IAttacker, IMoveableSprite, IAttackAble
    {
    }
}