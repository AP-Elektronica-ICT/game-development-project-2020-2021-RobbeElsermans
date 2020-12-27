
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Global.Enums;
using Pigit.Objects;
using Pigit.Objects.Abstracts;
using Pigit.SpriteBuild;
using Pigit.SpriteBuild.Enums;
using Pigit.Text.Enums;
using Pigit.Text.PlayerTexts;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Pigit.Objects.PlayerObjects
{
    class Human : APlayerObject
    {
        public Human(Dictionary<AnimatieTypes, SpriteDefine> spriteOpbouw, Vector2 beginPosition, Dictionary<TextTypes, SpriteFont> spriteFonts, int hearts, int attackDamage) :base(spriteOpbouw, beginPosition, spriteFonts, hearts, attackDamage)
        {
        }
        protected override void RectBuild()
        {
            Rectangle = new Rectangle((int)Positie.X + 36, (int)Positie.Y + 20, CurrentSprite.AnimatieL.CurrentFrame.SourceRect.Width - 45, CurrentSprite.AnimatieL.CurrentFrame.SourceRect.Height - 33);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            text.Update(Positie, Hearts, Points);

            if (Dead && Game1.currGameState == GameLoop.Play)
            {
                Game1.currGameState = GameLoop.Dead;
                Positie = new Vector2(Game1.ScreenWidth, Game1.ScreenHeight);
            }
            
        }
        public override void Reset()
        {
            Hearts = beginHearts;
            AttackDamage = beginAttackDamage;
            Points = 0;
            Dead = false;
        }
    }
}