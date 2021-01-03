namespace Pigit.Objects.Interfaces
{
    interface IPlayerObject: IObject, IResetAble, ICollector, IMoveable, IAttacker, IMoveableSprite, IAttackAble
    {
        public bool HasAttacked { get;}

    }
}