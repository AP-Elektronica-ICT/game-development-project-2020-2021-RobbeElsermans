using Microsoft.Xna.Framework.Graphics;
using Pigit.Text.Abstract;
using Pigit.Text.Enums;
using System.Collections.Generic;

namespace Pigit.Text.PlayerTexts
{
    class EnemyText: APlayerText
    {
        public EnemyText(Dictionary<TextTypes, SpriteFont> spriteFonts) : base(spriteFonts)
        {
        }
    }
}
