using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pigit.SpriteBuild;
using Pigit.TileBuild;
using System;
using System.Collections.Generic;
using System.Text;
using Pigit.Objects;
using Pigit.SpriteBuild.Enums;
using Pigit.Movement.NPCMoveCommands;
using Pigit.Movement;
using Pigit.Objects.Interfaces;
using Pigit.Objects.PlayerObjects;
using Pigit.Map.Interfaces;
using Pigit.Objects.Enums;
using Pigit.Objects.CollectableObjects;
using Pigit.Movement.CollectableMoveCommands;
using Pigit.Movement.Abstracts;
using Pigit.Collison;
using System.Diagnostics;
using Pigit.Text.Enums;
using Pigit.Global.Enums;

namespace Pigit.Map
{
    class Level
    {
        private const int bigHeartValue = 7;
        private const int smallgHeartValue = 2;
        private const int bigDiamondValue = 15;
        private const int smallgDiamondValue = 10;

        private const int enemyBaseAttackDamage = 1;
        private const int enemyBaseHearts = 10;

        private const float enemyWalkSpeed = 2f;
        private const float enemyJumpHeight = 4f;
        private const float enemyStopTime = 4f;
        private const float enemyWalkTime = 2f;

        private const int enemyDeadPoints = 20;

        private const int oneBlockStep = 32;


        private List<IRoomLayout> worlds;
        //private IWorldLayout currentWorld;
        private TileOpbouw blockOpbouw;
        private List<List<IPlayerObject>> worldEnemys;
        private List<List<AMovement>> worldsMoveEnemys;
        private List<List<ACollectableMovement>> worldsMoveCollectables;
        private List<List<ICollectableObject>> worldsCollectables;
        private SpriteGenerator opbouwSprites;
        private ContentManager content;
        private IPlayerObject heroPlayer;
        private List<List<ITile>> worldsTiles;
        private int prevCurrMap = 500;

        Dictionary<TextTypes, SpriteFont> spriteFonts;

        public List<ITile> CurrTiles { get; private set; }
        public List<IPlayerObject> CurrEnemys { get; private set; }
        public List<AMovement> CurrMovementEnemy { get; private set; }
        public List<ICollectableObject> CurrCollectable { get; set; }
        public int CurrMap { get; set; }
        public List<ACollectableMovement> CurrMovementCollectables { get; private set; }
        public bool Play { get; set; }

        public Level(ContentManager content, List<IRoomLayout> worlds, IPlayerObject hero, Dictionary<TextTypes, SpriteFont> spriteFonts)
        {
            heroPlayer = hero;
            this.worlds = worlds;
            this.content = content;
            opbouwSprites = new SpriteGenerator(content);
            this.spriteFonts = spriteFonts;

            worldsTiles = new List<List<ITile>>();

            worldEnemys = new List<List<IPlayerObject>>();
            worldsMoveEnemys = new List<List<AMovement>>();

            worldsCollectables = new List<List<ICollectableObject>>();
            worldsMoveCollectables = new List<List<ACollectableMovement>>();

            CurrMovementEnemy = new List<AMovement>();
            CurrMovementCollectables = new List<ACollectableMovement>();

            CurrEnemys = new List<IPlayerObject>();
            CurrTiles = new List<ITile>();
            CurrCollectable = new List<ICollectableObject>();

            AMoveCommandFollowWhenNearby.HeroPlayer = heroPlayer;
            ACollectableMovement.HeroPlayer = heroPlayer;
        }
        public void Update(GameTime gameTime)
        {
            CheckCollected();
            CheckEnemys();
            CheckCurrMap();

            foreach (var moveCommand in CurrMovementEnemy)
            {
                moveCommand.CheckMovement(gameTime);
            }
            foreach (var moveCommand in CurrMovementCollectables)
            {
                moveCommand.CheckMovement(gameTime);
            }
        }
        public void CreateLevels()
        {
            InitializeTiles(content);

            GeneratelevelContent(content);
            GenerateMovement();
        }
        public void DrawWorld(SpriteBatch spriteBatch)
        {
            foreach (var texture in CurrTiles)
            {
                texture.Draw(spriteBatch);
            }

            foreach (var enemy in CurrEnemys)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (var item in CurrCollectable)
            {
                item.Draw(spriteBatch);
            }
        }

        private void InitializeTiles(ContentManager content)
        {
            this.blockOpbouw = new TileOpbouw(content);
        }
        private void DeleteContent()
        {
            heroPlayer.Reset();
            worldsTiles = new List<List<ITile>>();

            worldEnemys = new List<List<IPlayerObject>>();
            worldsMoveEnemys = new List<List<AMovement>>();

            worldsCollectables = new List<List<ICollectableObject>>();
            worldsMoveCollectables = new List<List<ACollectableMovement>>();
        }
        private void CheckEnemys()
        {
            for (int i = 0; i < CurrEnemys.Count; i++)
            {
                if (CurrEnemys[i].Dead)
                {
                    heroPlayer.Points += enemyDeadPoints;

                    CurrEnemys.RemoveAt(i);
                    CurrMovementEnemy.RemoveAt(i);
                }
            }
        }
        private void CheckCollected()
        {
            for (int i = 0; i < CurrCollectable.Count; i++)
            {
                if (CurrCollectable[i].IsTaken)
                {
                    CurrCollectable.RemoveAt(i);
                    CurrMovementCollectables.RemoveAt(i);
                }
            }
        }
        private void GenerateMovement()
        {
            for (int i = 0; i < worldEnemys.Count; i++)
            {
                foreach (var enemy in worldEnemys[i])
                {
                    var temp = enemy as IMovementEnemy;
                    switch (temp.MovementType)
                    {
                        case MoveTypes.Static:
                            worldsMoveEnemys[i].Add(new MoveCommandStaticNPC((IPlayerObject)enemy, this));
                            break;
                        case MoveTypes.Walk:
                            worldsMoveEnemys[i].Add(new MoveCommandWalkNPC((IPlayerObject)enemy, this, enemyJumpHeight, enemyWalkSpeed));
                            break;
                        case MoveTypes.GuardTime:
                            worldsMoveEnemys[i].Add(new MoveCommandGuardNPC((IPlayerObject)enemy, this,enemyWalkTime, enemyStopTime, enemyJumpHeight, enemyWalkSpeed));
                            break;
                        case MoveTypes.GuardPosition:
                            worldsMoveEnemys[i].Add(new MoveCommandGuardNPC((IPlayerObject)enemy, this, (int)enemy.Positie.X - oneBlockStep, (int)enemy.Positie.X + oneBlockStep, enemyStopTime));
                            break;
                        case MoveTypes.Follow:
                            worldsMoveEnemys[i].Add(new MoveCommandFollowNPC((IPlayerObject)enemy, this, enemyJumpHeight, enemyWalkSpeed));
                            break;
                        default:
                            break;
                    }
                }
            }

            for (int i = 0; i < worldsCollectables.Count; i++)
            {
                foreach (var item in worldsCollectables[i])
                {
                    switch (item.MovementType)
                    {
                        case MoveTypes.Static:
                            worldsMoveCollectables[i].Add(new CollectableMovement(item, this));
                            break;
                        case MoveTypes.Walk:
                        case MoveTypes.GuardTime:
                        case MoveTypes.GuardPosition:
                        case MoveTypes.Follow:
                        default:
                            break;
                    }
                }
            }
        }
        private void CheckCurrMap()
        {
            if (Play)
            {
                if (CurrMap == 0)
                {
                    //initial opbouw van mappen
                    DeleteContent();
                    CreateLevels();

                    //Start map
                    CurrMap = 1;
                }

                CurrEnemys = worldEnemys[CurrMap];
                CurrTiles = worldsTiles[CurrMap];
                CurrMovementEnemy = worldsMoveEnemys[CurrMap];

                CurrCollectable = worldsCollectables[CurrMap];
                CurrMovementCollectables = worldsMoveCollectables[CurrMap];

                if (CurrMap != prevCurrMap)
                {
                    //Plaats speler juist
                    heroPlayer.Velocity = Vector2.Zero;
                    heroPlayer.Positie = worlds[CurrMap].StartPos;
                }
                if(CurrMap != prevCurrMap && prevCurrMap == 3)
                {
                    heroPlayer.Velocity = Vector2.Zero;
                    heroPlayer.Positie = new Vector2(worlds[CurrMap].Warp2.X - oneBlockStep * 2, worlds[CurrMap].Warp2.Y);
                }
                prevCurrMap = CurrMap;
                
                if (WarpCollision.IsAroundWarp(heroPlayer.Positie, worlds[CurrMap].Warp1) && CurrMap == 1) CurrMap = 2;
                if (WarpCollision.IsAroundWarp(heroPlayer.Positie, worlds[CurrMap].Warp1) && CurrMap == 2) CurrMap = 4;
                if (WarpCollision.IsAroundWarp(heroPlayer.Positie, worlds[CurrMap].Warp2) && CurrMap == 2) CurrMap = 3;
                if (WarpCollision.IsAroundWarp(heroPlayer.Positie, worlds[CurrMap].Warp1) && CurrMap == 4)
                {
                    if (CurrEnemys.Count == 0)
                    {
                        Game1.currGameState = GameLoop.End;
                    }
                }
            }
            else
            {
                if (CurrMap != 0)
                {
                    //initial opbouw van mappen
                    DeleteContent();
                    CreateLevels();

                    //Start map
                    CurrMap = 0;
                }

                CurrEnemys = worldEnemys[CurrMap];
                CurrTiles = worldsTiles[CurrMap];
                CurrMovementEnemy = worldsMoveEnemys[CurrMap];

                CurrCollectable = worldsCollectables[CurrMap];
                CurrMovementCollectables = worldsMoveCollectables[CurrMap];

                if (CurrMap != prevCurrMap)
                {
                    //Plaats speler juist
                    heroPlayer.Velocity = Vector2.Zero;
                    heroPlayer.Positie = worlds[CurrMap].StartPos;
                }
                prevCurrMap = CurrMap;
            }
        }
        private void GeneratelevelContent(ContentManager content)
        {
            foreach (var map in worlds)
            {
                worldsTiles.Add(new List<ITile>());
                worldEnemys.Add(new List<IPlayerObject>());
                worldsMoveEnemys.Add(new List<AMovement>());
                worldsCollectables.Add(new List<ICollectableObject>());
                worldsMoveCollectables.Add(new List<ACollectableMovement>());
            }

            for (int a = 0; a < worlds.Count; a++)
            {
                for (int x = 0; x < worlds[a].Width; x++)
                {
                    for (int y = 0; y < worlds[a].Height; y++)
                    {
                        for (int i = 1; i <= blockOpbouw.BackgroundTiles.Count; i++)
                        {
                            if (i == worlds[a].BackgroundTiles[x, y])
                            {
                                worldsTiles[a].Add(new TileDefine(blockOpbouw.BackgroundTiles[i - 1], new Vector2(y * oneBlockStep, x * oneBlockStep)));
                            }
                        }

                        for (int i = 1; i <= blockOpbouw.CollideTiles.Count; i++)
                        {
                            if (i == worlds[a].CollideTileLayout[x, y])
                            {
                                worldsTiles[a].Add(new CollideTileDefine(blockOpbouw.CollideTiles[i - 1], new Vector2(y * oneBlockStep, x * oneBlockStep)));
                            }
                        }

                        for (int i = 1; i <= blockOpbouw.ForegroundTiles.Count; i++)
                        {
                            if (i == worlds[a].ForegroundTiles[x, y])
                            {
                                worldsTiles[a].Add(new TileDefine(blockOpbouw.ForegroundTiles[i - 1], new Vector2(y * oneBlockStep, x * oneBlockStep)));
                            }
                        }

                        for (int i = 1; i <= blockOpbouw.PLatformTiles.Count; i++)
                        {
                            if (i == worlds[a].PlatformTiles[x, y])
                            {
                                worldsTiles[a].Add(new PlatformTileDefine(blockOpbouw.PLatformTiles[i - 1], new Vector2(y * oneBlockStep, x * oneBlockStep)));
                            }
                        }
                        switch ((PigTypes)(worlds[a].Enemys[x, y] / 10))
                        {
                            case PigTypes.Standard:
                                if (a != 0) worldEnemys[a].Add(new Pig(opbouwSprites.GetSpritePig(12), new Vector2(y * oneBlockStep, x * oneBlockStep), (MoveTypes)(worlds[a].Enemys[x, y] % 10), spriteFonts, enemyBaseHearts + enemyBaseHearts * (a - 1), enemyBaseAttackDamage + enemyBaseAttackDamage * (a - 1)));
                                else worldEnemys[a].Add(new Pig(opbouwSprites.GetSpritePig(12), new Vector2(y * oneBlockStep, x * oneBlockStep), (MoveTypes)(worlds[a].Enemys[x, y] % 10), spriteFonts, enemyBaseHearts + enemyBaseHearts * (a), enemyBaseAttackDamage + enemyBaseAttackDamage * (a)));
                                break;
                            case PigTypes.Match:
                                break;
                            case PigTypes.HideBox:
                                break;
                            case PigTypes.TrowBox:
                                break;
                            case PigTypes.TrowBomb:
                                break;
                            default:
                                break;
                        }
                        switch ((CollectableTypes)(worlds[a].Collectable[x, y]))
                        {
                            case CollectableTypes.BigHeart:
                                worldsCollectables[a].Add(new Item(opbouwSprites.GetSpriteBigHeart(6), (CollectableTypes)(worlds[a].Collectable[x, y]), new Vector2(y * oneBlockStep, x * oneBlockStep), MoveTypes.Static, bigHeartValue));
                                break;
                            case CollectableTypes.BigDiamond:
                                worldsCollectables[a].Add(new Item(opbouwSprites.GetSpriteBigDiamond(6), (CollectableTypes)(worlds[a].Collectable[x, y]), new Vector2(y * oneBlockStep, x * oneBlockStep), MoveTypes.Static, bigDiamondValue));
                                break;
                            case CollectableTypes.SmallHeart:
                                worldsCollectables[a].Add(new Item(opbouwSprites.GetSpriteSmallHeart(6), (CollectableTypes)(worlds[a].Collectable[x, y]), new Vector2(y * oneBlockStep, x * oneBlockStep), MoveTypes.Static, smallgHeartValue));
                                break;
                            case CollectableTypes.SmallDiamond:
                                worldsCollectables[a].Add(new Item(opbouwSprites.GetSpriteSmallDiamond(6), (CollectableTypes)(worlds[a].Collectable[x, y]), new Vector2(y * oneBlockStep, x * oneBlockStep), MoveTypes.Static, smallgDiamondValue));
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }
    }
}

