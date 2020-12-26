﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Global.Enums;
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
        private Cursor cursor;

        public MenuText(Dictionary<TextTypes, SpriteFont> spriteFonts, IInputMenu inputMenu, Vector2 position, List<string> text)
        {
            Input = inputMenu;
            spriteFonts.TryGetValue(TextTypes.Title, out this.title);
            spriteFonts.TryGetValue(TextTypes.Normal, out this.normal);
            spriteFonts.TryGetValue(TextTypes.Hint, out this.hint);
            spriteFonts.TryGetValue(TextTypes.Arrow, out this.arrow);
            this.position = position;

            this.text = text;

            cursor = new Cursor(new Vector2(position.X - 10, position.Y + 50), text.Count - 2, this.arrow, this.text[text.Count-1]);
        }

        public void Update(GameTime gameTime)
        {
            if (Input.Enter)
            {
                Debug.Print("Enter");
                if (cursor.CursorIndex == 0)
                {
                    Game1.currGameState = GameLoop.Play;
                }
            }

            if (Input.Up)
            {
                Debug.Print("Up");

                cursor.CursorUp();
            }

            if (Input.Down)
            {
                Debug.Print("Down");

                cursor.CursorDown();
            }

            cursor.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.DrawString(title, text[0], position, Color.Yellow);
            for (int i = 0; i < text.Count - 2; i++)
            {
                _spriteBatch.DrawString(normal, text[i + 1], new Vector2(position.X + 20, position.Y + 50 + (20 * i)), Color.Yellow);
            }

            cursor.Draw(_spriteBatch, Color.White);
        }
    }
}
