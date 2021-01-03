using Pigit.Music.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Music
{
    class HumanEffect: IEffectMusic
    {
        private MusicGenerator musicGenerator;

        private bool hasPlayedAttack = false;

        public HumanEffect(MusicGenerator musicGenerator)
        {
            this.musicGenerator = musicGenerator;
        }
        public void PlayAttack()
        {
            if (!hasPlayedAttack)
            {
                musicGenerator.FightEffectHuman.Play();
                hasPlayedAttack = true;
            }
        }
        public void StopAttack()
        {
            musicGenerator.FightEffectHuman.Dispose();
            hasPlayedAttack = false;
        }

        public void PlayJump()
        {
                musicGenerator.JumpEffect.Play();
        }
        public void PlayHit()
        {
                musicGenerator.HitEffectEnemy.Play();
        }
    }
}
