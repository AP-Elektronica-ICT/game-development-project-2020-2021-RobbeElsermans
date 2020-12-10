using Microsoft.Xna.Framework;

namespace Pigit.Objects
{
    internal interface IMoveable
    {
        Vector2 Positie { get; set; }
        Vector2 Velocity { get; set; }
    }
}