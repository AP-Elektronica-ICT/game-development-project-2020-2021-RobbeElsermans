using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Pigit.Animatie
{
    class SpriteOpbouw
    {
        private Dictionary<String, Texture2D> spriteHuman;
        public SpriteOpbouw(ContentManager Content)
        {
            spriteHuman = new Dictionary<string, Texture2D>();

            spriteHuman.Add("runR", Content.Load<Texture2D>(@"Human\Run (78x58)"));
            spriteHuman.Add("runL", Content.Load<Texture2D>(@"Human\Run Left (78x58)"));
            spriteHuman.Add("idleR", Content.Load<Texture2D>(@"Human\Idle (78x58)"));
            spriteHuman.Add("idleL", Content.Load<Texture2D>(@"Human\Idle Left(78x58)"));
            spriteHuman.Add("jumpR", Content.Load<Texture2D>(@"Human\Jump (78x58)"));
            spriteHuman.Add("jumpL", Content.Load<Texture2D>(@"Human\Jump Left(78x58)"));
            spriteHuman.Add("hitR", Content.Load<Texture2D>(@"Human\Hit (78x58)"));
            spriteHuman.Add("hitL", Content.Load<Texture2D>(@"Human\Hit Left(78x58)"));
            spriteHuman.Add("groundR", Content.Load<Texture2D>(@"Human\Ground (78x58)"));
            spriteHuman.Add("groundL", Content.Load<Texture2D>(@"Human\Ground Left(78x58)"));
            spriteHuman.Add("fallR", Content.Load<Texture2D>(@"Human\Fall (78x58)"));
            spriteHuman.Add("fallL", Content.Load<Texture2D>(@"Human\Fall Left(78x58)"));
            spriteHuman.Add("dooroutR", Content.Load<Texture2D>(@"Human\Door Out (78x58)"));
            spriteHuman.Add("dooroutL", Content.Load<Texture2D>(@"Human\Door Out Left(78x58)"));
            spriteHuman.Add("doorinR", Content.Load<Texture2D>(@"Human\Door In (78x58)"));
            spriteHuman.Add("doorinL", Content.Load<Texture2D>(@"Human\Door In Left(78x58)"));
            spriteHuman.Add("deadR", Content.Load<Texture2D>(@"Human\Dead (78x58)"));
            spriteHuman.Add("deadL", Content.Load<Texture2D>(@"Human\Dead Left(78x58)"));
            spriteHuman.Add("attackR", Content.Load<Texture2D>(@"Human\Attack (78x58)"));
            spriteHuman.Add("attackL", Content.Load<Texture2D>(@"Human\Attack Left(78x58)"));

            SpriteHuman = spriteHuman;
        }
        public Dictionary<String, Texture2D> SpriteHuman { get; private set; }
    }
}
