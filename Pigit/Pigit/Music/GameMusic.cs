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
        public bool IsSetIngame { get; private set; } = false;
        public bool IsSetDeadSong { get; private set; } = false;
        public bool IsSetVictorySong { get; private set; } = false;

        public GameMusic(MusicGenerator musicGenerator)
        {
            this.musicGenerator = musicGenerator;
        }

        public void StartIngameSong()
        {
            if (!IsSetIngame)
            {
                MediaPlayer.Play(musicGenerator.IngameMusic);
                MediaPlayer.IsRepeating = true;
                IsSetIngame = true;
            }
        }

        public void StopIngameSong()
        {
            //MediaPlayer.Stop();
            IsSetIngame = false;
        }

        public void StartDeadSong()
        {
            if (!IsSetDeadSong)
            {
                MediaPlayer.Play(musicGenerator.DeadMusic);
                MediaPlayer.IsRepeating = false;
                IsSetDeadSong = true;
            }
        }
        public void StopDeadSong()
        {
            //MediaPlayer.Stop();
            IsSetDeadSong = false;
        }

        public void StartVictorySong()
        {
            if (!IsSetVictorySong)
            {
                MediaPlayer.Play(musicGenerator.VictoryMusic);
                MediaPlayer.IsRepeating = false;
                IsSetVictorySong = true;
            }
        }
        public void StopVictorySong()
        {
            //MediaPlayer.Stop();
            IsSetVictorySong = false;
        }
        public void StopAllSongs()
        {
            MediaPlayer.Stop();
            IsSetDeadSong = false;
            IsSetIngame = false;
            IsSetVictorySong = false;
        }
    }
}
