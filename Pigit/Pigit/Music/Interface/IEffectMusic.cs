using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Music.Interface
{
    interface IEffectMusic
    {
        public void PlayAttack();
        public void StopAttack();
        public void PlayJump();
        public void PlayHit();
    }
}
