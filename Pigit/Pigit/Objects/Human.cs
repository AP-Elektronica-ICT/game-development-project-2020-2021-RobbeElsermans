
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Objects;
using SharpDX.MediaFoundation;
using System;
using System.Linq.Expressions;

namespace Pigit
{
    class Human : APlayerObject
    {
        public Human(Texture2D textureRight, Texture2D textureLeft, Vector2 size, int amountFrames):base(textureRight,textureLeft,size,amountFrames)
        {

        }
    }
}
