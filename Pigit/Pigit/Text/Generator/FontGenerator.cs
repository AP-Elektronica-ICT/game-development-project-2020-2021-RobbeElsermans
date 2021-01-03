using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Text.Enums;
using System.Collections.Generic;

namespace Pigit.Text.Generator
{
    class FontGenerator
    {
        public Dictionary<TextTypes, SpriteFont> SpriteFonts { get; private set; }

        public FontGenerator(ContentManager content)
        {
            SpriteFonts = new Dictionary<TextTypes, SpriteFont>();

            SpriteFonts.Add(TextTypes.Title,content.Load<SpriteFont>(@"Text\Title"));
            SpriteFonts.Add(TextTypes.Normal, content.Load<SpriteFont>(@"Text\Normal"));
            SpriteFonts.Add(TextTypes.Hint, content.Load<SpriteFont>(@"Text\Hint"));
            SpriteFonts.Add(TextTypes.Arrow, content.Load<SpriteFont>(@"Text\arrow"));
        }
    }
}
