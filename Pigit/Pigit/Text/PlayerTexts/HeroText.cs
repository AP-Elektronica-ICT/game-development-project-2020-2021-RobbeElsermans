using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Text.Abstract;
using Pigit.Text.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Text.PlayerTexts
{
    class HeroText: APlayerText
    {
        public HeroText(Dictionary<TextTypes, SpriteFont> spriteFonts) : base(spriteFonts)
        {
        }
    }
}
