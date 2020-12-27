using Microsoft.Xna.Framework.Graphics;
using Pigit.Text.Abstract;
using Pigit.Text.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Text.PlayerTexts
{
    class NPCText: APlayerText
    {
        public NPCText(Dictionary<TextTypes, SpriteFont> spriteFonts) : base(spriteFonts)
        {
        }
    }
}
