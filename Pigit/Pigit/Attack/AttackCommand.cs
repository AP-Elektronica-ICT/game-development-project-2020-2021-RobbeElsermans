using Microsoft.Xna.Framework;
using Pigit.Collison;
using Pigit.Objects;
using Pigit.Objects.Abstracts;
using Pigit.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Attack
{
    class AttackCommand
    {
        private double timer;
        private bool isSetTimer = false;

        public void Attack(List<AEnemyObject> enemys, IPlayerObject player, GameTime gametime)
        {
            //Attack an enemy
            if (!isSetTimer)
            {
                timer = gametime.TotalGameTime.TotalSeconds;
                isSetTimer = true;
            }

            foreach (var enemy in enemys)
            {
                if (NPCCollision.IsTouchingNPC(player.Rectangle, enemy.Rectangle))
                {
                    if (gametime.TotalGameTime.TotalSeconds - timer > 0.5)
                    {
                        isSetTimer = false;
                        enemy.Hearts -= player.AttackDamage;
                        if (!enemy.IsHit)
                        {
                            enemy.IsHit = true;
                        }
                    }
                }
            }
        }
        public void NPCAttack(IPlayerObject enemy, AEnemyObject player, GameTime gametime)
        {
            //Attack an enemy
            if (!isSetTimer)
            {
                timer = gametime.TotalGameTime.TotalSeconds;
                isSetTimer = true;
            }

            if (NPCCollision.IsTouchingNPC(player.Rectangle, enemy.Rectangle))
            {
                if (gametime.TotalGameTime.TotalSeconds - timer > 0.7)
                {
                    isSetTimer = false;
                    enemy.Hearts -= player.AttackDamage;
                    if (!enemy.IsHit)
                    {
                        enemy.IsHit = true;
                    }
                }
            }
        }
    }
}
