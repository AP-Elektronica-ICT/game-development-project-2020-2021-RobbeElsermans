using Pigit.Attack;

namespace Pigit.Objects.Interfaces
{
    interface IAttacker
    {
        public AttackCommand Attack { get; }
        public bool IsAttacking { get; set; }
        public int AttackDamage { get; }
    }
}
