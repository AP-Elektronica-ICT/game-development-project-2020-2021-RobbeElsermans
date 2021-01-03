using Microsoft.Xna.Framework;

namespace Pigit.Objects.Interfaces
{
    internal interface IMoveable: IPosition
    {
        Vector2 Velocity { get; set; }
        Rectangle Rectangle { get;}
    }
}