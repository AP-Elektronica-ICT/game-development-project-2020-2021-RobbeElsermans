using Pigit.Music.Generator;
using Pigit.Music.Interface;

namespace Pigit.Music.Abstracts
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
