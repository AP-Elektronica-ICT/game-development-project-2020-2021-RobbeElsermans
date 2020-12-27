using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects.Interfaces
{
    interface INPCObject: IObject, IMoveable, IAttacker, IMoveableSprite, IAttackAble
    {
    }
}
