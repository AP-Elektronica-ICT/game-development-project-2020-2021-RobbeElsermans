﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Objects;
using Pigit.SpriteBuild;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Pigit
{
    class Human : APlayerObject
    {
        public Human(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw):base(spriteOpbouw)
        {

        }
        protected override void RectBuild()
        {
            Rectangle = new Rectangle((int)Positie.X + 32, (int)Positie.Y + 10, CurrentSprite.AnimatieL.CurrentFrame.SourceRect.Width - 41, CurrentSprite.AnimatieL.CurrentFrame.SourceRect.Height - 23);
        }
    }
}
