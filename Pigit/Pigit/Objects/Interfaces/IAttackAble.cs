namespace Pigit.Objects.Interfaces
{
    interface IAttackAble
    {
        public int Hearts { get; set; }
        public bool Dead { get; }
        public bool IsHit { get; set; }
    }
}
