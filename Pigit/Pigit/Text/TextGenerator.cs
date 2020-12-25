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
        IInputMenu Input;

        public Dictionary<TextTypes,SpriteFont> spriteFonts;

        public TextGenerator(ContentManager content)
        {
            spriteFonts = new Dictionary<TextTypes, SpriteFont>();

            spriteFonts.Add(TextTypes.Title,content.Load<SpriteFont>(@"Text\Title"));
            spriteFonts.Add(TextTypes.Normal, content.Load<SpriteFont>(@"Text\Normal"));
            spriteFonts.Add(TextTypes.Hint, content.Load<SpriteFont>(@"Text\Hint"));
            spriteFonts.Add(TextTypes.Arrow, content.Load<SpriteFont>(@"Text\arrow"));
        }
    }
}
