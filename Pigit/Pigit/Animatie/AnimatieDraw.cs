﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Pigit.Animatie
{
    class AnimatieDraw
    {
        public AnimatieFrame CurrentFrame { get; set; }

        private List<AnimatieFrame> frames;

        public int Counter { get; set; }

        private double frameMovement = 0;

        public int Speed { get; set; }

        public AnimatieDraw()
        {
            frames = new List<AnimatieFrame>();
        }

        public void AddFrame(AnimatieFrame animatieFrame)
        {
            frames.Add(animatieFrame);
            CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[Counter];


            frameMovement += CurrentFrame.SourceRect.Height * gameTime.ElapsedGameTime.TotalSeconds;

            if (frameMovement >= CurrentFrame.SourceRect.Height / Speed)
            {
                Counter++;
                frameMovement = 0;
            }

            if (Counter >= frames.Count)

                Counter = 0;

        }
    }
}