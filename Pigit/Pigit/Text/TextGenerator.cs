using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Input.Interfaces;
using Pigit.Text.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Text
{
    class TextGenerator
    {
        public Dictionary<TextTypes, SpriteFont> SpriteFonts { get; private set; }

        public TextGenerator(ContentManager content)
        {
            SpriteFonts = new Dictionary<TextTypes, SpriteFont>();

            SpriteFonts.Add(TextTypes.Title,content.Load<SpriteFont>(@"Text\Title"));
            SpriteFonts.Add(TextTypes.Normal, content.Load<SpriteFont>(@"Text\Normal"));
            SpriteFonts.Add(TextTypes.Hint, content.Load<SpriteFont>(@"Text\Hint"));
            SpriteFonts.Add(TextTypes.Arrow, content.Load<SpriteFont>(@"Text\arrow"));
        }
    }
}
