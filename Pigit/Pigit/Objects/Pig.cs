
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Objects;
using Pigit.SpriteBuild;
using SharpDX.MediaFoundation;
using System.Collections.Generic;

namespace Pigit
{
    class Pig : APlayerObject
    {
        public Pig(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw): base (spriteOpbouw)
        {

        }
    }

}
