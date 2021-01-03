using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.SpriteBuild.Enums;
using System.Collections.Generic;

namespace Pigit.SpriteBuild.Generator
{
    class SpriteGenerator
    {
        private Dictionary<AnimatieTypes, SpriteDefine> human;
        private Dictionary<AnimatieTypes, SpriteDefine> pig;
        //private Dictionary<AnimatieTypes, SpriteDefine> kingPig;
        private Dictionary<AnimatieTypes, SpriteDefine> bigHeart;
        private Dictionary<AnimatieTypes, SpriteDefine> bigDiamond;
        private Dictionary<AnimatieTypes, SpriteDefine> smallHeart;
        private Dictionary<AnimatieTypes, SpriteDefine> smallDiamond;
        private Dictionary<AnimatieTypes, SpriteDefine> door;
        private ContentManager content;

        public SpriteGenerator(ContentManager content)
        {
            this.content = content;
        }
        public Dictionary<AnimatieTypes, SpriteDefine> GetSpriteDoor(int speed)
        {
            door = new Dictionary<AnimatieTypes, SpriteDefine>();
            door.Add(AnimatieTypes.Idle, new SpriteDefine(content.Load<Texture2D>(@"Objects\Door\idle"), content.Load<Texture2D>(@"Objects\Door\idle"),1,new Vector2(46,56)));

            foreach (var value in door)
            {
                value.Value.SetSpeed(speed);
            }
            return door;
        }
        public Dictionary<AnimatieTypes, SpriteDefine> GetSpriteSmallDiamond(int speed)
        {
            smallDiamond = new Dictionary<AnimatieTypes, SpriteDefine>();
            smallDiamond.Add(AnimatieTypes.Idle, new SpriteDefine(content.Load<Texture2D>(@"Objects\LiveAndCoints\Small Diamond Idle (12x14)"), content.Load<Texture2D>(@"Objects\LiveAndCoints\Small Diamond Idle (12x14)"), 8, new Vector2(12, 14)));
            smallDiamond.Add(AnimatieTypes.Hit, new SpriteDefine(content.Load<Texture2D>(@"Objects\LiveAndCoints\Small Diamond Hit (12x14)"), content.Load<Texture2D>(@"Objects\LiveAndCoints\Small Diamond Hit (12x14)"), 2, new Vector2(12, 14)));

            foreach (var spriteAnimatieFrame in smallDiamond)
            {
                spriteAnimatieFrame.Value.SetSpeed(speed);
            }
            return smallDiamond;
        }
        public Dictionary<AnimatieTypes, SpriteDefine> GetSpriteSmallHeart(int speed)
        {
            smallHeart = new Dictionary<AnimatieTypes, SpriteDefine>();
            smallHeart.Add(AnimatieTypes.Idle, new SpriteDefine(content.Load<Texture2D>(@"Objects\LiveAndCoints\Small Heart Idle (18x14)"), content.Load<Texture2D>(@"Objects\LiveAndCoints\Small Heart Idle (18x14)"), 8, new Vector2(18, 14)));
            smallHeart.Add(AnimatieTypes.Hit, new SpriteDefine(content.Load<Texture2D>(@"Objects\LiveAndCoints\Small Heart Hit (18x14)"), content.Load<Texture2D>(@"Objects\LiveAndCoints\Small Heart Hit (18x14)"), 2, new Vector2(18, 14)));

            foreach (var spriteAnimatieFrame in smallHeart)
            {
                spriteAnimatieFrame.Value.SetSpeed(speed);
            }
            return smallHeart;
        }

        public Dictionary<AnimatieTypes, SpriteDefine> GetSpriteBigDiamond(int speed)
        {
            bigDiamond = new Dictionary<AnimatieTypes, SpriteDefine>();
            bigDiamond.Add(AnimatieTypes.Idle, new SpriteDefine(content.Load<Texture2D>(@"Objects\LiveAndCoints\Big Diamond Idle (18x14)"), content.Load<Texture2D>(@"Objects\LiveAndCoints\Big Diamond Idle (18x14)"), 10, new Vector2(18, 14)));
            bigDiamond.Add(AnimatieTypes.Hit, new SpriteDefine(content.Load<Texture2D>(@"Objects\LiveAndCoints\Big Diamond Hit (18x14)"), content.Load<Texture2D>(@"Objects\LiveAndCoints\Big Diamond Hit (18x14)"), 2, new Vector2(18, 14)));

            foreach (var spriteAnimatieFrame in bigDiamond)
            {
                spriteAnimatieFrame.Value.SetSpeed(speed);
            }
            return bigDiamond;
        }
        public Dictionary<AnimatieTypes, SpriteDefine> GetSpriteBigHeart(int speed)
        {
            bigHeart = new Dictionary<AnimatieTypes, SpriteDefine>();
            bigHeart.Add(AnimatieTypes.Idle, new SpriteDefine(content.Load<Texture2D>(@"Objects\LiveAndCoints\Big Heart Idle (18x14)"), content.Load<Texture2D>(@"Objects\LiveAndCoints\Big Heart Idle (18x14)"), 8, new Vector2(18, 14)));
            bigHeart.Add(AnimatieTypes.Hit, new SpriteDefine(content.Load<Texture2D>(@"Objects\LiveAndCoints\Big Heart Hit (18x14)"), content.Load<Texture2D>(@"Objects\LiveAndCoints\Big Heart Hit (18x14)"), 2, new Vector2(18, 14)));

            foreach (var spriteAnimatieFrame in bigHeart)
            {
                spriteAnimatieFrame.Value.SetSpeed(speed);
            }
            return bigHeart;
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
