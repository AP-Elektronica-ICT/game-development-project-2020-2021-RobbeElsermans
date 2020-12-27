using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Text.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Text.Abstract
{
    class APlayerText
    {
        protected SpriteFont hint;

        protected Vector2 position;

        protected int lives;
        protected int points = -1;

        public APlayerText(Dictionary<TextTypes, SpriteFont> spriteFonts)
        {
            spriteFonts.TryGetValue(TextTypes.Hint, out this.hint);
        }

        protected virtual void SetPosition(Vector2 heroPos)
        {
            position = new Vector2(heroPos.X - 10, heroPos.Y - 20);
        }

        public virtual void Update(Vector2 heroPos, int lives)
        {
            SetPosition(heroPos);
            this.lives = lives;
        }
        public virtual void Update(Vector2 heroPos, int lives, int points)
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
