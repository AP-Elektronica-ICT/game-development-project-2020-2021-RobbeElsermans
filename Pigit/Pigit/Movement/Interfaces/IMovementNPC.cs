using Pigit.Movement.Enums;

namespace Pigit.Movement.Interfaces
{
    interface IMovementNPC
    {
        MoveTypes MovementType { get; set; }
    }
}