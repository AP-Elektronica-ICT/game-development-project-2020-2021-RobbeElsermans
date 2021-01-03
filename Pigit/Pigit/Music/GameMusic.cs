using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Music
{
    class GameMusic
    {
        private MusicGenerator musicGenerator;
        public bool IsSet { get; private set; } = false;

        public GameMusic(MusicGenerator musicGenerator)
        {
            this.musicGenerator = musicGenerator;
        }

        public void StartSong()
        {
            MediaPlayer.Play(musicGenerator.GameMusic);
            MediaPlayer.IsRepeating = true;
            IsSet = true;
        }

        public void StopSong()
        {
            MediaPlayer.Stop();
            IsSet = false;
        }
    }
}
