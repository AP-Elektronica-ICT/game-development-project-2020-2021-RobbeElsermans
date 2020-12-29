using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Pigit.Animatie
{
    class SpriteDefine
    {
        private Vector2 size;

        public Texture2D TextureL { get; private set; }
        public Texture2D TextureR { get; private set; }
        public int AmountFrames { get; private set; }
        public AnimatieDraw AnimatieL { get; private set; }
        public AnimatieDraw AnimatieR { get; private set; }

        public SpriteDefine(Texture2D texture2DR,Texture2D texture2DL, int amount, Vector2 size)
        {
            this.AmountFrames = amount;
            this.TextureL = texture2DL;
            this.TextureR = texture2DR;
            this.size = size;

            AnimatieR = new AnimatieDraw();
            AnimatieL = new AnimatieDraw();

            for (int i = 0; i < this.size.X * AmountFrames; i += (int)this.size.X)
            {
                AnimatieR.AddFrame(new AnimatieFrame(new Rectangle(i, 0, (int)size.X, (int)this.size.Y)));
            }
            for (int i = Convert.ToInt32(size.X * (AmountFrames - 1)); i >= 0; i -= (int)size.X)
            {
                AnimatieL.AddFrame(new AnimatieFrame(new Rectangle(i, 0, (int)this.size.X, (int)this.size.Y)));
            }

            //for (int i = 0; i < Size.X * AmountFrames; i+= (int)Size.X)
            //{
            //    AnimatieR.AddFrame(new AnimatieFrame(new Rectangle(i, 0, (int)size.X, (int)Size.Y)));
            //}
            //for (int i = Convert.ToInt32(size.X * (AmountFrames - 1)); i >= 0; i -= (int)size.X)
            //{
            //    AnimatieL.AddFrame(new AnimatieFrame(new Rectangle(i, 0, (int)Size.X, (int)Size.Y)));
            //}
        }

        public void SetSpeed(int speed)
        {
            AnimatieL.Speed = speed;
            AnimatieR.Speed = speed;
        }

        public void Update(GameTime gametime)
        {
            AnimatieL.Update(gametime);
            AnimatieR.Update(gametime);
        }
    }
}
