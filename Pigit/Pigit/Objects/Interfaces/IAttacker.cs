using Pigit.Attack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Objects.Interfaces
{
    interface IAttacker
    {
        public AttackCommand Attack { get; set; }
        public bool IsAttacking { get; set; }
        public int AttackDamage { get; set; }
    }
}
