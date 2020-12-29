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
        private static float attackTicksHero = 0.5f;
        private static float attackTicksEnemy = 0.7f;

        public void Attack(List<AEnemyObject> enemys, IPlayerObject player, GameTime gametime)
        {
            SetTimer(gametime);
            CheckCollision(enemys, player, gametime, attackTicksHero);
        }
        public void NPCAttack(IPlayerObject enemy, AEnemyObject player, GameTime gametime)
        {
            SetTimer(gametime);
            CheckCollision(new List<AEnemyObject> { player }, enemy, gametime, attackTicksEnemy);
        }

        private void SetTimer(GameTime gametime)
        {
            if (!isSetTimer)
            {
                timer = gametime.TotalGameTime.TotalSeconds;
                isSetTimer = true;
            }
        }

        private void CheckCollision(List<AEnemyObject> enemys, IPlayerObject player, GameTime gametime, float ticks)
        {
            foreach (var enemy in enemys)
            {
                if (NPCCollision.IsTouchingNPC(player.Rectangle, enemy.Rectangle))
                {
                    if (gametime.TotalGameTime.TotalSeconds - timer > ticks)
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
}
