using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Input.Interfaces;
using Pigit.Text.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pigit.Text
{
    class MenuText
    {
        IInputMenu Input;
        SpriteFont title;
        SpriteFont normal;
        SpriteFont hint;
        SpriteFont arrow;
        private Vector2 position;
        private List<string> text;

        int cursor;

        Vector2 cursorPos;

        public MenuText(Dictionary<TextTypes, SpriteFont> spriteFonts, IInputMenu inputMenu, Vector2 position)
        {
            Input = inputMenu;
            spriteFonts.TryGetValue(TextTypes.Title, out this.title);
            spriteFonts.TryGetValue(TextTypes.Normal, out this.normal);
            spriteFonts.TryGetValue(TextTypes.Hint, out this.hint);
            spriteFonts.TryGetValue(TextTypes.Arrow, out this.arrow);
            this.position = position;

            text = new List<string>();
            text.Add("Pigit");
            text.Add("start");
            text.Add("Help");
            text.Add("Exit");
            text.Add("->");

            cursorPos = new Vector2(position.X - 20, 96);
        }

        public void Update(GameTime gameTime)
        {
            if (Input.Enter)
            {
                Debug.Print("Enter");
            }

            if (Input.Up)
            {
                Debug.Print("Up");

                cursor--;
                if (cursor < 0)
                {
                    cursor = 2;
                }
            }

            if (Input.Down)
            {
                Debug.Print("Down");

                cursor++;
                if (cursor > 2)
                {
                    cursor = 0;
                }
            }
            cursorPos.Y = (position.X - 20/2) + 30 * cursor;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.DrawString(title, text[0], position, Color.Yellow);
            _spriteBatch.DrawString(normal, text[1], new Vector2(position.X + 20, position.Y + 50), Color.Yellow);
            _spriteBatch.DrawString(normal, text[2], new Vector2(position.X + 20, position.Y + 80), Color.Yellow);
            _spriteBatch.DrawString(normal, text[3], new Vector2(position.X + 20, position.Y + 110), Color.Yellow);
            _spriteBatch.DrawString(arrow, text[4], new Vector2(cursorPos.X, cursorPos.Y) , Color.White);
        }
    }
}
