using Microsoft.Xna.Framework.Graphics;
using Pigit.Text.Abstract;
using Pigit.Text.Enums;
using System.Collections.Generic;

namespace Pigit.Text.PlayerTexts
{
    class HeroText: APlayerText
    {
        public HeroText(Dictionary<TextTypes, SpriteFont> spriteFonts) : base(spriteFonts)
        {
        }
    }
}
