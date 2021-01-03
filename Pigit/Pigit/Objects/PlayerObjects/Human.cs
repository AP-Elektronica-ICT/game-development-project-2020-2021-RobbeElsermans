
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Objects.Abstracts;
using Pigit.SpriteBuild.Enums;
using Pigit.Text.Enums;
using System.Collections.Generic;

namespace Pigit.Objects.PlayerObjects
{
    class Human : APlayerObject
    {
        public Human(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition, Dictionary<TextTypes, SpriteFont> spriteFonts, int hearts, int attackDamage) :base(spriteOpbouw, beginPosition, spriteFonts, hearts, attackDamage)
        {
        }
        protected override void RectBuild()
        {
            Rectangle = new Rectangle((int)Positie.X + 36, (int)Positie.Y + 20, currentSprite.AnimatieL.CurrentFrame.SourceRect.Width - 45, currentSprite.AnimatieL.CurrentFrame.SourceRect.Height - 33);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            text.Update(Positie, Hearts, Points);
        }
    }
}