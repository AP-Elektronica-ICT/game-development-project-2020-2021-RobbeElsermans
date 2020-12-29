using Microsoft.Xna.Framework;
using Pigit.SpriteBuild.Enums;

namespace Pigit.Objects.Interfaces
{
    internal interface IMoveable: IPosition
    {
        Vector2 Velocity { get; set; }
        Rectangle Rectangle { get;}
    }
}