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
        private Dictionary<AnimatieTypes, SpriteDefine> spriteHuman;
        public SpriteOpbouw(ContentManager Content, int speed)
        {
            spriteHuman = new Dictionary<AnimatieTypes, SpriteDefine>();
            //spriteHuman.Add(AnimatieTypes.Run, new SpriteDefine(Content.Load<Texture2D>(@"Human\Run (78x58)"), Content.Load<Texture2D>(@"Human\Run Left (78x58)"), 8,new Vector2(78,58)));
            spriteHuman.Add(AnimatieTypes.Idle, new SpriteDefine(Content.Load<Texture2D>(@"Human\Idle (78x58)"), Content.Load<Texture2D>(@"Human\Idle Left(78x58)"), 11, new Vector2(78,58)));
            //spriteHuman.Add(AnimatieTypes.Jump, new SpriteDefine(Content.Load<Texture2D>(@"Human\Jump (78x58)"), Content.Load<Texture2D>(@"Human\Jump Left(78x58)"), 1, new Vector2(78,58)));
            //spriteHuman.Add(AnimatieTypes.Attack, new SpriteDefine(Content.Load<Texture2D>(@"Human\Attack (78x58)"), Content.Load<Texture2D>(@"Human\Attack Left(78x58)"), 3, new Vector2(78, 58)));

            //spriteHuman.Add("hit", new SpriteDefine(Content.Load<Texture2D>(@"Human\Hit (78x58)"),Content.Load<Texture2D>(@"Human\Hit Left(78x58)"), );
            //spriteHuman.Add("ground", new SpriteDefine(Content.Load<Texture2D>(@"Human\Ground (78x58)"),Content.Load<Texture2D>(@"Human\Ground Left(78x58)"),);
            //spriteHuman.Add("fallR", new SpriteDefine(Content.Load<Texture2D>(@"Human\Fall (78x58)"),Content.Load<Texture2D>(@"Human\Fall Left(78x58)"),);
            //spriteHuman.Add("doorout", new SpriteDefine(Content.Load<Texture2D>(@"Human\Door Out (78x58)"),Content.Load<Texture2D>(@"Human\Door Out Left(78x58)"),);
            //spriteHuman.Add("doorin", new SpriteDefine(Content.Load<Texture2D>(@"Human\Door In (78x58)"),Content.Load<Texture2D>(@"Human\Door In Left(78x58)"),);
            //spriteHuman.Add("dead", new SpriteDefine(Content.Load<Texture2D>(@"Human\Dead (78x58)"),Content.Load<Texture2D>(@"Human\Dead Left(78x58)"),);

            foreach (var spriteAnimatieFrame in spriteHuman)
            {
                spriteAnimatieFrame.Value.SetSpeed(speed);
            }
            SpriteHuman = spriteHuman;
        }
        public Dictionary<AnimatieTypes, SpriteDefine> SpriteHuman { get; private set; }
    }
}
