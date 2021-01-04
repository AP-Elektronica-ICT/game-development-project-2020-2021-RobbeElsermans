using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Map.Interfaces;
using Pigit.Movement.Enums;
using Pigit.Objects.Abstracts;
using Pigit.SpriteBuild.Enums;
using Pigit.SpriteBuild.Generator;
using Pigit.Text.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Map.Factorys
{
    class Factory
    {
        public static AEnemyObject EnemyFactory(PigTypes types, SpriteGenerator opbouwSprites, int oneBlockStep, List<IRoomLayout> worlds, int a,int x,int y, Dictionary<TextTypes, SpriteFont> spriteFonts, int enemyHearts, int enemyAttackDamage)
        {

            var type = Type.GetType("Pigit.Objects.NPCObjects." + types.ToString(), throwOnError: false);
            if (type != null)
            {
                return (AEnemyObject)Activator.CreateInstance(type, opbouwSprites.GetSpritePig(12), new Vector2(y * oneBlockStep, x * oneBlockStep), (MoveTypes)(worlds[a].Enemys[x, y] % 10), spriteFonts, enemyHearts, enemyAttackDamage);
            }
            return null;
        }
    }
}
