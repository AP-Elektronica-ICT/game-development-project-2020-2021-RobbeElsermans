using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Text.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Text.PlayerTexts
{
    class HeroText
    {
        protected SpriteFont hint;

        private Vector2 position;

        private int lives;
        private int points;


        public HeroText(Dictionary<TextTypes, SpriteFont> spriteFonts)
        {
            spriteFonts.TryGetValue(TextTypes.Hint, out this.hint);
        }

        private void SetPosition(Vector2 heroPos)
        {
            position = new Vector2(heroPos.X - 10, heroPos.Y - 20);
        }

        public void Update(Vector2 heroPos, int lives, int points)
        {
            SetPosition(heroPos);
            this.lives = lives;
            this.points = points;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.DrawString(hint, "Hearts " + lives, position, Color.Yellow);
            if (points != -1)
            {
                _spriteBatch.DrawString(hint, "Points " + points, position + new Vector2(0, 10), Color.Yellow);
            }
        }

    }
}
