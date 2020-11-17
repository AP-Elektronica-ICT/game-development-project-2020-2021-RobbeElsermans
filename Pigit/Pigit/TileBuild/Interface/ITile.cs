﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.TileBuild
{
    interface ITile
    {
        public Vector2 Position { get; set; }
        public int Number { get; set; }
        public void Draw(SpriteBatch spriteBatch);
    }
}