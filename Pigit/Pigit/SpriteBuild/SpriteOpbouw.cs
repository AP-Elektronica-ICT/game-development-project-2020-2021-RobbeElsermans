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
        private Dictionary<AnimatieTypes, SpriteDefine> human;
        private Dictionary<AnimatieTypes, SpriteDefine> pig;
        private Dictionary<AnimatieTypes, SpriteDefine> heart;
        private Dictionary<AnimatieTypes, SpriteDefine> diamond;
        private ContentManager content;

        public SpriteOpbouw(ContentManager content)
        {
            this.content = content;
        }
        public Dictionary<AnimatieTypes, SpriteDefine> GetSpriteDiamond(int speed)
        {
            diamond = new Dictionary<AnimatieTypes, SpriteDefine>();
            diamond.Add(AnimatieTypes.Idle, new SpriteDefine(content.Load<Texture2D>(@"Objects\LiveAndCoints\Big Diamond Idle (18x14)"), content.Load<Texture2D>(@"Objects\LiveAndCoints\Objects\LiveAndCoints\Big Diamond Idle (18x14)"), 10, new Vector2(18, 14)));
            diamond.Add(AnimatieTypes.Hit, new SpriteDefine(content.Load<Texture2D>(@"Objects\LiveAndCoints\Big Diamond Hit (18x14)"), content.Load<Texture2D>(@"Objects\LiveAndCoints\Big Diamond Hit (18x14)"), 2, new Vector2(18, 14)));

            foreach (var spriteAnimatieFrame in diamond)
            {
                spriteAnimatieFrame.Value.SetSpeed(speed);
            }
            return diamond;
        }
        public Dictionary<AnimatieTypes, SpriteDefine> GetSpriteHeart(int speed)
        {
            heart = new Dictionary<AnimatieTypes, SpriteDefine>();
            heart.Add(AnimatieTypes.Idle, new SpriteDefine(content.Load<Texture2D>(@"Objects\LiveAndCoints\Small Heart Idle (18x14)"), content.Load<Texture2D>(@"Objects\LiveAndCoints\Small Heart Idle (18x14)"), 8, new Vector2(18, 14)));
            heart.Add(AnimatieTypes.Hit, new SpriteDefine(content.Load<Texture2D>(@"Objects\LiveAndCoints\Small Heart Hit (18x14)"), content.Load<Texture2D>(@"Objects\LiveAndCoints\Small Heart Hit (18x14)"), 2, new Vector2(18, 14)));

            foreach (var spriteAnimatieFrame in heart)
            {
                spriteAnimatieFrame.Value.SetSpeed(speed);
            }
            return heart;
        }
        public Dictionary<AnimatieTypes, SpriteDefine> GetSpriteHuman(int speed)
        {
            human = new Dictionary<AnimatieTypes, SpriteDefine>();
            human.Add(AnimatieTypes.Run, new SpriteDefine(content.Load<Texture2D>(@"Human\Run (78x58)"), content.Load<Texture2D>(@"Human\Run Left (78x58)"), 8, new Vector2(78, 58)));
            human.Add(AnimatieTypes.Idle, new SpriteDefine(content.Load<Texture2D>(@"Human\Idle (78x58)"), content.Load<Texture2D>(@"Human\Idle Left(78x58)"), 11, new Vector2(78, 58)));
            human.Add(AnimatieTypes.Jump, new SpriteDefine(content.Load<Texture2D>(@"Human\Jump (78x58)"), content.Load<Texture2D>(@"Human\Jump Left(78x58)"), 1, new Vector2(78, 58)));
            human.Add(AnimatieTypes.Attack, new SpriteDefine(content.Load<Texture2D>(@"Human\Attack (78x58)"), content.Load<Texture2D>(@"Human\Attack Left(78x58)"), 3, new Vector2(78, 58)));
            human.Add(AnimatieTypes.Fall, new SpriteDefine(content.Load<Texture2D>(@"Human\Fall (78x58)"), content.Load<Texture2D>(@"Human\Fall Left(78x58)"), 1, new Vector2(78, 58)));
            human.Add(AnimatieTypes.Hit, new SpriteDefine(content.Load<Texture2D>(@"Human\Hit (78x58)"),content.Load<Texture2D>(@"Human\Hit Left(78x58)"),2, new Vector2(78, 58)));
            //spriteHuman.Add("doorout", new SpriteDefine(content.Load<Texture2D>(@"Human\Door Out (78x58)"),content.Load<Texture2D>(@"Human\Door Out Left(78x58)"),);
            //spriteHuman.Add("doorin", new SpriteDefine(content.Load<Texture2D>(@"Human\Door In (78x58)"),content.Load<Texture2D>(@"Human\Door In Left(78x58)"),);
            human.Add(AnimatieTypes.Dead, new SpriteDefine(content.Load<Texture2D>(@"Human\Dead (78x58)"),content.Load<Texture2D>(@"Human\Dead Left(78x58)"),3,new Vector2(78,58)));

            foreach (var spriteAnimatieFrame in human)
            {
                spriteAnimatieFrame.Value.SetSpeed(speed);
            }
            return human;
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
