
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Movement;
using Pigit.Objects;
using Pigit.SpriteBuild;
using Pigit.SpriteBuild.Enums;
using SharpDX.MediaFoundation;
using System.Collections.Generic;

namespace Pigit
{
    class Pig : APlayerObject, IMovementEnemy
    {
        public MoveTypes MovementType { get; private set; }
        public Pig(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition, MoveTypes moveTypes): base (spriteOpbouw, beginPosition)
        {
            this.MovementType = moveTypes;
        }
    }

}
