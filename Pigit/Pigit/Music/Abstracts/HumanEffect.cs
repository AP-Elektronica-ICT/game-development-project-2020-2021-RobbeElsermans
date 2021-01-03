using Pigit.Music.Generator;
using Pigit.Music.Interface;

namespace Pigit.Music.Abstracts
{
    class HumanEffect: IEffectMusic, ICollectMusic
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

        public void PlayDiamondCollect()
        {
            musicGenerator.CollectDiamond.Play();
        }

        public void PlayHeartCollect()
        {
            musicGenerator.CollectHeart.Play();
        }
    }
}
