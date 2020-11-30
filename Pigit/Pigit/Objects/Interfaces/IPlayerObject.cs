using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;

using Pigit.Movement;
using Pigit.Objects;



namespace Pigit.Objects
{
    interface IPlayerObject: INPCObject
    {
        public int Hearts { get; set; }
        public int AttackDamage { get; set; }
    }
}
