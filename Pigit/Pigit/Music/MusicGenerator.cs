using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Music
{
    class MusicGenerator
    {
        public SoundEffect JumpEffect { get; private set; }
        public SoundEffect FightEffectHuman { get; private set; }
        public SoundEffect FightEffectEnemy { get; private set; }
        public SoundEffect HitEffectHuman { get; private set; }
        public SoundEffect HitEffectEnemy { get; private set; }

        public Song GameMusic { get; private set; }


        public MusicGenerator(ContentManager content)
        {
            JumpEffect = content.Load<SoundEffect>(@"Music\Woosh");
            FightEffectHuman = content.Load<SoundEffect>(@"Music\Strong Punch");
            FightEffectEnemy = content.Load<SoundEffect>(@"Music\Smack");
            HitEffectHuman = content.Load<SoundEffect>(@"Music\man-getting-hit");
            HitEffectEnemy = content.Load<SoundEffect>(@"Music\pig-squeaking-a");
            GameMusic = content.Load<Song>(@"Music\Dungeon - Serpent's Tunnel");
        }
    }
}
