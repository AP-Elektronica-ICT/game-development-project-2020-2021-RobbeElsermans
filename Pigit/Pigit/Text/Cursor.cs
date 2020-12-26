using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pigit.Text
{
    class Cursor
    {
        int amountItems = 0;
        Vector2 cursorPos;
        Vector2 basePositon;
        SpriteFont font;
        string text;

        private int cursor;
        public int CursorIndex
        {
            get
            {
                return cursor;
            }
            private set 
            {
                cursor = value;
                if (cursor < 0)
                {
                    cursor = amountItems-1;
                }
                if (cursor >= amountItems)
                {
                    cursor = 0;
                }
                Debug.Print(cursor.ToString());
            }
        }

        public Cursor(Vector2 position, int amountItems, SpriteFont font, string text)
        {
            basePositon = position;
            cursorPos = position;
            this.amountItems = amountItems;
            this.font = font;
            this.text = text;
        }

        public void ResetCursor()
        {
            CursorIndex = 0;
        }

        public void Update(GameTime gameTime)
        {
            cursorPos.Y = basePositon.Y + 20 * cursor;
        }

        public void Draw(SpriteBatch _spriteBatch, Color color)
        {
            _spriteBatch.DrawString(font, text, new Vector2(cursorPos.X, cursorPos.Y), color);
        }

        public void CursorUp()
        {
            CursorIndex--;
        }
        public void CursorDown()
        {
            CursorIndex++;
        }


    }
}
