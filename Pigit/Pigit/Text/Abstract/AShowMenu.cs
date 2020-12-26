using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Global.Enums;
using Pigit.Input.Interfaces;
using Pigit.Text.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pigit.Text.Abstract
{
    abstract class AShowMenu
    {
        protected IInputMenu Input;
        protected SpriteFont title;
        protected SpriteFont normal;
        protected SpriteFont hint;
        protected SpriteFont arrow;
        protected Vector2 position;
        protected List<string> text;
        protected Cursor cursor;

        public AShowMenu(Dictionary<TextTypes, SpriteFont> spriteFonts, IInputMenu inputMenu, Vector2 position, List<string> text)
        {
            Input = inputMenu;
            spriteFonts.TryGetValue(TextTypes.Title, out this.title);
            spriteFonts.TryGetValue(TextTypes.Normal, out this.normal);
            spriteFonts.TryGetValue(TextTypes.Hint, out this.hint);
            spriteFonts.TryGetValue(TextTypes.Arrow, out this.arrow);
            this.position = new Vector2(32 * position.X, 32* position.Y);

            this.text = text;

            cursor = new Cursor(new Vector2(this.position.X - 10, this.position.Y + 50), text.Count - 2, this.arrow, this.text[text.Count-1]);
        }

        public virtual void Update(GameTime gameTime)
        {
            if (Input.Enter)
            {
                Debug.Print("Enter");
                this.EnterLoop(gameTime);
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

            //if (Input.Esc)
            //{
            //    Debug.Print("Esc");
            //    EscapeLoop(gameTime);
            //}

            cursor.Update(gameTime);
        }

        public abstract void EnterLoop(GameTime gameTime);

        //public abstract void EscapeLoop(GameTime gameTime);

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
