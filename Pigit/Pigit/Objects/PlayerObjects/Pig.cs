using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Movement;
using Pigit.Objects;
using Pigit.Objects.Abstracts;
using Pigit.SpriteBuild;
using Pigit.SpriteBuild.Enums;
using Pigit.Text.Enums;
using SharpDX.MediaFoundation;
using System.Collections.Generic;

namespace Pigit.Objects.PlayerObjects
{
    class Pig : APlayerObject, IMovementEnemy
    {
        public MoveTypes MovementType { get; set; }
        public Pig(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition, MoveTypes moveTypes, Dictionary<TextTypes, SpriteFont> spriteFonts) : base (spriteOpbouw, beginPosition, spriteFonts)
        {
            this.MovementType = moveTypes;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            text.Update(Positie, Hearts, -1);
        }
    }

}
