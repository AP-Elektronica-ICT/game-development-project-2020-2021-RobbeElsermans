using Microsoft.Xna.Framework;
using Pigit.SpriteBuild.Enums;

namespace Pigit.Objects.Interfaces
{
    internal interface IMoveable
    {
        Vector2 Positie { get; set; }
        Vector2 Velocity { get; set; }
        Rectangle Rectangle { get; set; }
    }
}