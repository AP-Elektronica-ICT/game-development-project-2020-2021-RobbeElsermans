using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;

using Pigit.Movement;
using Pigit.Objects;



namespace Pigit.Objects
{
    interface IPlayerObject
    {
        bool Direction { get; set; }
        AnimatieTypes Type { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch _spriteBatch);
        Vector2 Positie { get; set; }
        Vector2 Versnelling { get; set; }
        public Rectangle RectangleR { get; set; }
        public Rectangle RectangleL { get; set; }
    }
}
