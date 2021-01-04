using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Movement.Enums;
using Pigit.Objects.Abstracts;
using Pigit.SpriteBuild.Enums;
using Pigit.SpriteBuild.Generator;
using Pigit.Text.Enums;
using System.Collections.Generic;

namespace Pigit.Objects.NPCObjects
{
    class Enemy : AEnemyObject
    {
        public Enemy(PigTypes pigType,SpriteGenerator sprites, Vector2 beginPosition, MoveTypes moveTypes, Dictionary<TextTypes, SpriteFont> spriteFonts, int hearts = 10, int attackDamage = 1) : base (pigType,sprites, beginPosition, spriteFonts, hearts, attackDamage, moveTypes)
        {

        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            text.Update(Positie, Hearts);
        }
    }
}
