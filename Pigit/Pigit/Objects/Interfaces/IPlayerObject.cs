using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;

using Pigit.Movement;
using Pigit.Objects;
using Pigit.Attack;
using Pigit.SpriteBuild.Enums;

namespace Pigit.Objects.Interfaces
{
    interface IPlayerObject: IObject
    {
        public AttackCommand Attack { get; set; }
        public int Hearts { get; set; }
        public int AttackDamage { get; set; }
        public bool Dead { get; }
        public bool IsHit { get; set; }
        public bool IsAttacking { get; set; }
        bool Direction { get; set; }
        AnimatieTypes Type { get; set; }
    }
}
