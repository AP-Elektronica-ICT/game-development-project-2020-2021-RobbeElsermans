using Pigit.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Attack
{
    class AttackCommand
    {
        private List<IPlayerObject> enemys;
        private IPlayerObject player1;
        public AttackCommand(List<IPlayerObject> enemys, IPlayerObject player)
        {
            this.enemys = enemys;
            this.player1 = player;
        }

        public void SmallAttack(IPlayerObject enemy, IPlayerObject player)
        {

        }
    }
}
