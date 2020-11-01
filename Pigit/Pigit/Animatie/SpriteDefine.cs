using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Pigit.Animatie
{
    public enum AnimatieTypes { Idle, Run, Jump, Fall, Attack}
    class SpriteDefine
    {
        public Texture2D TextureL { get; private set; }
        public Texture2D TextureR { get; set; }
        public int AmountFrames { get; private set; }
        public Vector2 Size { get; private set; }
        public AnimatieFrames AnimatieL { get; set; }
        public AnimatieFrames AnimatieR { get; set; }

        public SpriteDefine(Texture2D texture2DR,Texture2D texture2DL, int amount, Vector2 size)
        {
            this.AmountFrames = amount;
            this.TextureL = texture2DL;
            this.TextureR = texture2DR;
            this.Size = size;

            AnimatieR = new AnimatieFrames();
            AnimatieL = new AnimatieFrames();

            for (int i = 0; i < Size.X * AmountFrames; i+= (int)Size.X)
            {
                AnimatieR.AddFrame(new AnimatieFrame(new Rectangle(i, 0, (int)size.X, (int)Size.Y)));
            }
            for (int i = Convert.ToInt32(size.X * (AmountFrames - 1)); i >= 0; i -= (int)size.X)
            {
                AnimatieL.AddFrame(new AnimatieFrame(new Rectangle(i, 0, (int)Size.X, (int)Size.Y)));
            }
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
        public void Draw(bool direction, SpriteBatch spriteBatch)
        {
            if (!direction)
            {
                //rechts
                
            }
            else
            {
                //links
            }
        }
    }
}
