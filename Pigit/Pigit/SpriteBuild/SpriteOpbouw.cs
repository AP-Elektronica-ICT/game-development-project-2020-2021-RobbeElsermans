using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Objects;
using Pigit.SpriteBuild.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Pigit.SpriteBuild
{
    class SpriteOpbouw
    {
        private Dictionary<AnimatieTypes, SpriteDefine> spriteHuman;
        private Dictionary<AnimatieTypes, SpriteDefine> pig;
        private ContentManager content;

        public SpriteOpbouw(ContentManager content)
        {
            this.content = content;
        }
        public Dictionary<AnimatieTypes, SpriteDefine> GetSpriteHuman(int speed)
        {
            spriteHuman = new Dictionary<AnimatieTypes, SpriteDefine>();
            spriteHuman.Add(AnimatieTypes.Run, new SpriteDefine(content.Load<Texture2D>(@"Human\Run (78x58)"), content.Load<Texture2D>(@"Human\Run Left (78x58)"), 8, new Vector2(78, 58)));
            spriteHuman.Add(AnimatieTypes.Idle, new SpriteDefine(content.Load<Texture2D>(@"Human\Idle (78x58)"), content.Load<Texture2D>(@"Human\Idle Left(78x58)"), 11, new Vector2(78, 58)));
            spriteHuman.Add(AnimatieTypes.Jump, new SpriteDefine(content.Load<Texture2D>(@"Human\Jump (78x58)"), content.Load<Texture2D>(@"Human\Jump Left(78x58)"), 1, new Vector2(78, 58)));
            spriteHuman.Add(AnimatieTypes.Attack, new SpriteDefine(content.Load<Texture2D>(@"Human\Attack (78x58)"), content.Load<Texture2D>(@"Human\Attack Left(78x58)"), 3, new Vector2(78, 58)));
            spriteHuman.Add(AnimatieTypes.Fall, new SpriteDefine(content.Load<Texture2D>(@"Human\Fall (78x58)"), content.Load<Texture2D>(@"Human\Fall Left(78x58)"), 1, new Vector2(78, 58)));
            spriteHuman.Add(AnimatieTypes.Hit, new SpriteDefine(content.Load<Texture2D>(@"Human\Hit (78x58)"),content.Load<Texture2D>(@"Human\Hit Left(78x58)"),2, new Vector2(78, 58)));
            //spriteHuman.Add("doorout", new SpriteDefine(content.Load<Texture2D>(@"Human\Door Out (78x58)"),content.Load<Texture2D>(@"Human\Door Out Left(78x58)"),);
            //spriteHuman.Add("doorin", new SpriteDefine(content.Load<Texture2D>(@"Human\Door In (78x58)"),content.Load<Texture2D>(@"Human\Door In Left(78x58)"),);
            spriteHuman.Add(AnimatieTypes.Dead, new SpriteDefine(content.Load<Texture2D>(@"Human\Dead (78x58)"),content.Load<Texture2D>(@"Human\Dead Left(78x58)"),3,new Vector2(78,58)));

            foreach (var spriteAnimatieFrame in spriteHuman)
            {
                spriteAnimatieFrame.Value.SetSpeed(speed);
            }
            return spriteHuman;
        }
        public Dictionary<AnimatieTypes, SpriteDefine> GetSpritePig(int speed)
        {
            pig = new Dictionary<AnimatieTypes, SpriteDefine>();
            pig.Add(AnimatieTypes.Idle, new SpriteDefine(content.Load<Texture2D>(@"pig\Idle (34x28)"), content.Load<Texture2D>(@"pig\Idle Left (34x28)"), 11, new Vector2(34, 28)));
            pig.Add(AnimatieTypes.Run, new SpriteDefine(content.Load<Texture2D>(@"pig\Run (34x28)"), content.Load<Texture2D>(@"pig\Run Left (34x28)"), 6, new Vector2(34, 28)));
            pig.Add(AnimatieTypes.Fall, new SpriteDefine(content.Load<Texture2D>(@"pig\Fall (34x28)"), content.Load<Texture2D>(@"pig\Fall Left (34x28)"), 1, new Vector2(34, 28)));
            pig.Add(AnimatieTypes.Jump, new SpriteDefine(content.Load<Texture2D>(@"pig\Jump (34x28)"), content.Load<Texture2D>(@"pig\Jump Left (34x28)"), 1, new Vector2(34, 28)));
            pig.Add(AnimatieTypes.Attack, new SpriteDefine(content.Load<Texture2D>(@"pig\Attack (34x28)"), content.Load<Texture2D>(@"pig\Attack Left (34x28)"), 5, new Vector2(34, 28)));
            pig.Add(AnimatieTypes.Dead, new SpriteDefine(content.Load<Texture2D>(@"pig\Dead (34x28)"), content.Load<Texture2D>(@"pig\Dead Left (34x28)"), 4, new Vector2(34, 28)));
            pig.Add(AnimatieTypes.Hit, new SpriteDefine(content.Load<Texture2D>(@"pig\Hit (34x28)"), content.Load<Texture2D>(@"pig\Hit Left (34x28)"), 2, new Vector2(34, 28)));

            foreach (var pig in pig)
            {
                pig.Value.SetSpeed(speed);
            }

            return pig;
        }
    }
}
