using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Pigit
{
    internal class Animatie
    {
        public AnimatieFrame CurrentFrame { get; set; }

        private List<AnimatieFrame> frames;

        private int counter;

        private double frameMovement = 0;

        static public int Speed { get; set; }

        public Animatie()
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
            CurrentFrame = frames[counter];


            frameMovement += CurrentFrame.SourceRect.Height * gameTime.ElapsedGameTime.TotalSeconds;

            if (frameMovement >= CurrentFrame.SourceRect.Height / Speed)
            {
                counter++;
                frameMovement = 0;
            }

            if (counter >= frames.Count)

                counter = 0;

        }
    }
}