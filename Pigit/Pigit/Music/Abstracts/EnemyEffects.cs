using Pigit.Music.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Music
{
    class EnemyEffects : IEffectMusic
    {
        private MusicGenerator musicGenerator;

        private bool hasPlayedAttack = false;

        public EnemyEffects(MusicGenerator musicGenerator)
        {
            this.musicGenerator = musicGenerator;
        }
        public void PlayAttack()
        {
            if (!hasPlayedAttack)
            {
                musicGenerator.FightEffectEnemy.Play();
                //hasPlayedAttack = true;
            }
        }
        public void StopAttack()
        {
            musicGenerator.FightEffectEnemy.Dispose();
            hasPlayedAttack = false;
        }

        public void PlayJump()
        {
                musicGenerator.JumpEffect.Play();
        }
        public void PlayHit()
        {
                musicGenerator.HitEffectHuman.Play();
        }
    }
}
