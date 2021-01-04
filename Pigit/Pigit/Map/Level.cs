using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pigit.TileBuild;
using System.Collections.Generic;
using Pigit.SpriteBuild.Enums;
using Pigit.Movement.NPCMoveCommands;
using Pigit.Objects.Interfaces;
using Pigit.Map.Interfaces;
using Pigit.Objects.Enums;
using Pigit.Objects.CollectableObjects;
using Pigit.Movement.CollectableMoveCommands;
using Pigit.Movement.Abstracts;
using Pigit.Collision;
using Pigit.Text.Enums;
using Pigit.Global.Enums;
using Pigit.TileBuild.Enums;
using Pigit.Objects.Abstracts;
using Pigit.Objects.StaticObjects;
using Pigit.Objects.NPCObjects;
using Pigit.Music.Interface;
using Pigit.Global;
using Pigit.TileBuild.Generator;
using Pigit.SpriteBuild.Generator;
using Pigit.TileBuild.Interface;
using Pigit.Movement.Enums;
using System;

namespace Pigit.Map
{
    class Level
    {
        private const int enemyBaseAttackDamage = 1;
        private const int enemyBaseHearts = 10;

        private const float enemyWalkSpeed = 2f;
        private const float enemyJumpHeight = 4f;
        //private float enemyStopTime = 4f;
        //private float enemyWalkTime = 2f;
        //private float enemytimeOnJump = 5f;
        private const int enemyStopTimeMin = 3;
        private const int enemyStopTimeMax = 5;
        private const int enemyWalkTimeMin = 1;
        private const int enemyWalkTimeMax = 3;
        private const int enemytimeOnJumpMin = 4;
        private const int enemytimeOnJumpMax = 8;


        private const int enemyDeadPoints = 20;

        private const int oneBlockStep = 32;

        private List<IRoomLayout> worlds;
        private TileGenerator blockOpbouw;
        private List<List<AStaticObject>> worldsDoors;
        private List<List<AEnemyObject>> worldsEnemys;
        private List<List<AEnemyMovement>> worldsMoveEnemys;
        private List<List<ACollectableMovement>> worldsMoveCollectables;
        private List<List<ICollectableObject>> worldsCollectables;
        private SpriteGenerator opbouwSprites;
        private ContentManager content;
        private IPlayerObject heroPlayer;
        private List<List<ITile>> worldsTiles;
        private int prevCurrMap = 500;
        private List<AEnemyMovement> currMovementEnemy;
        private int currMap;
        private Dictionary<TextTypes, SpriteFont> spriteFonts;
        private List<AStaticObject> currDoors;
        private IEffectMusic effectMusic;

        public List<ITile> CurrTiles { get; private set; }
        public List<AEnemyObject> CurrEnemys { get; private set; }
        public List<ICollectableObject> CurrCollectable { get; private set; }
        public List<ACollectableMovement> CurrMovementCollectables { get; private set; }
        public bool Play { get; set; }

        public Level(ContentManager content, List<IRoomLayout> worlds, IPlayerObject hero, Dictionary<TextTypes, SpriteFont> spriteFonts, IEffectMusic effects)
        {
            this.effectMusic = effects;
            heroPlayer = hero;
            this.worlds = worlds;
            this.content = content;
            opbouwSprites = new SpriteGenerator(content);
            this.spriteFonts = spriteFonts;

            #region initialize all lists
            worldsTiles = new List<List<ITile>>();
            worldsDoors = new List<List<AStaticObject>>();
            worldsEnemys = new List<List<AEnemyObject>>();
            worldsMoveEnemys = new List<List<AEnemyMovement>>();
            worldsCollectables = new List<List<ICollectableObject>>();
            worldsMoveCollectables = new List<List<ACollectableMovement>>();
            currMovementEnemy = new List<AEnemyMovement>();
            CurrMovementCollectables = new List<ACollectableMovement>();
            CurrEnemys = new List<AEnemyObject>();
            CurrTiles = new List<ITile>();
            CurrCollectable = new List<ICollectableObject>();
            currDoors = new List<AStaticObject>();

            #endregion
            AMoveCommandFollowWhenNearby.HeroPlayer = heroPlayer;
            ACollectableMovement.HeroPlayer = heroPlayer;
        }
        public void Update(GameTime gameTime)
        {
            CheckCollected();
            CheckEnemys();
            CheckCurrMap();

            #region update every current movements and check for collision with the doors
            foreach (var moveCommand in currMovementEnemy)
            {
                moveCommand.CheckMovement(gameTime);
            }
            foreach (var moveCommand in CurrMovementCollectables)
            {
                moveCommand.CheckMovement(gameTime);
            }
            foreach (var door in currDoors)
            {
                door.Update(gameTime);
            }
            #endregion
        }
        public void CreateLevels()
        {
            InitializeTiles(content);

            GenerateLevelContent(content);
            GenerateMovement();
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            #region draw every current item on the map
            foreach (var texture in CurrTiles)
            {
                texture.Draw(spriteBatch);
            }
            foreach (var door in currDoors)
            {
                door.Draw(spriteBatch);
            }
            foreach (var enemy in CurrEnemys)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (var item in CurrCollectable)
            {
                item.Draw(spriteBatch);
            }
            #endregion
        }

        private void InitializeTiles(ContentManager content)
        {
            this.blockOpbouw = new TileGenerator(content);
        }
        private void DeleteContent()
        {
            heroPlayer.Reset();
            worldsTiles = new List<List<ITile>>();

            worldsEnemys = new List<List<AEnemyObject>>();
            worldsMoveEnemys = new List<List<AEnemyMovement>>();

            worldsCollectables = new List<List<ICollectableObject>>();
            worldsMoveCollectables = new List<List<ACollectableMovement>>();

            worldsDoors = new List<List<AStaticObject>>();
        }
        private void CheckEnemys()
        {
            #region check for dead enemys
            for (int i = 0; i < CurrEnemys.Count; i++)
            {
                if (CurrEnemys[i].Dead)
                {
                    heroPlayer.Points += enemyDeadPoints;

                    CurrEnemys.RemoveAt(i);
                    currMovementEnemy.RemoveAt(i);
                }
            }
            #endregion
        }
        private void CheckCollected()
        {
            #region check for collected items
            for (int i = 0; i < CurrCollectable.Count; i++)
            {
                if (CurrCollectable[i].IsTaken)
                {
                    CurrCollectable.RemoveAt(i);
                    CurrMovementCollectables.RemoveAt(i);
                }
            }
            #endregion
        }
        private void GenerateMovement()
        {
            for (int i = 0; i < worldsEnemys.Count; i++)
            {
                foreach (var enemy in worldsEnemys[i])
                {
                    switch (enemy.MovementType)
                    {
                        case MoveTypes.Static:
                            worldsMoveEnemys[i].Add(new MoveCommandStaticNPC(enemy, this, effectMusic));
                            break;
                        case MoveTypes.Walk:
                            worldsMoveEnemys[i].Add(new MoveCommandWalkNPC(enemy, this, effectMusic, enemyJumpHeight, enemyWalkSpeed,timeOnJump:Randomizer.GetRandomFloat(enemytimeOnJumpMin, enemytimeOnJumpMax)));
                            break;
                        case MoveTypes.GuardTime:
                            worldsMoveEnemys[i].Add(new MoveCommandGuardTimeNPC(enemy, this, effectMusic, walkTime:Randomizer.GetRandomFloat(enemyWalkTimeMin, enemyWalkTimeMax),stopTime:Randomizer.GetRandomFloat(enemyStopTimeMin, enemyStopTimeMax), enemyJumpHeight, enemyWalkSpeed));
                            break;
                        case MoveTypes.GuardPosition:
                            worldsMoveEnemys[i].Add(new MoveCommandGuardPositionNPC(enemy, this, effectMusic,(int)enemy.Positie.X - oneBlockStep, (int)enemy.Positie.X + oneBlockStep,stopTime: Randomizer.GetRandomFloat(enemyStopTimeMin, enemyStopTimeMax)));
                            break;
                        case MoveTypes.Follow:
                            worldsMoveEnemys[i].Add(new MoveCommandFollowNPC(enemy, this, effectMusic, enemyJumpHeight, enemyWalkSpeed));
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
                if (currMap == 0)
                {
                    //initial opbouw van mappen
                    DeleteContent();
                    CreateLevels();

                    //Start map
                    currMap = 1;
                }

                currDoors = worldsDoors[currMap];
                CurrEnemys = worldsEnemys[currMap];
                CurrTiles = worldsTiles[currMap];
                currMovementEnemy = worldsMoveEnemys[currMap];

                CurrCollectable = worldsCollectables[currMap];
                CurrMovementCollectables = worldsMoveCollectables[currMap];

                if (currMap != prevCurrMap)
                {
                    //Plaats speler juist
                    heroPlayer.Velocity = Vector2.Zero;
                    heroPlayer.Positie = worlds[currMap].StartPos;
                }
                if (currMap != prevCurrMap && prevCurrMap == 3)
                {
                    heroPlayer.Velocity = Vector2.Zero;
                    heroPlayer.Positie = new Vector2(worlds[currMap].Warp2.X - oneBlockStep * 2, worlds[currMap].Warp2.Y);
                }
                prevCurrMap = currMap;

                if (WarpCollision.IsAroundWarp(heroPlayer.Positie, worlds[currMap].Warp1) && currMap == 1) currMap = 2;
                if (WarpCollision.IsAroundWarp(heroPlayer.Positie, worlds[currMap].Warp1) && currMap == 2) currMap = 4;
                if (WarpCollision.IsAroundWarp(heroPlayer.Positie, worlds[currMap].Warp2) && currMap == 2) currMap = 3;
                if (WarpCollision.IsAroundWarp(heroPlayer.Positie, worlds[currMap].Warp1) && currMap == 3) currMap = 2;
                if (WarpCollision.IsAroundWarp(heroPlayer.Positie, worlds[currMap].Warp1) && currMap == 4)
                {
                    if (CurrEnemys.Count == 0)
                    {
                        Game1.currGameState = GameLoop.End;
                    }
                }
            }
            else
            {
                if (currMap != 0)
                {
                    //initial opbouw van mappen
                    DeleteContent();
                    CreateLevels();

                    //Start map
                    currMap = 0;
                }

                currDoors = worldsDoors[currMap];
                CurrEnemys = worldsEnemys[currMap];
                CurrTiles = worldsTiles[currMap];
                currMovementEnemy = worldsMoveEnemys[currMap];

                CurrCollectable = worldsCollectables[currMap];
                CurrMovementCollectables = worldsMoveCollectables[currMap];

                if (currMap != prevCurrMap)
                {
                    //Plaats speler juist
                    heroPlayer.Velocity = Vector2.Zero;
                    heroPlayer.Positie = worlds[currMap].StartPos;
                }
                prevCurrMap = currMap;
            }
        }
        private void GenerateLevelContent(ContentManager content)
        {
            foreach (var map in worlds)
            {
                worldsTiles.Add(new List<ITile>());
                worldsEnemys.Add(new List<AEnemyObject>());
                worldsMoveEnemys.Add(new List<AEnemyMovement>());
                worldsCollectables.Add(new List<ICollectableObject>());
                worldsMoveCollectables.Add(new List<ACollectableMovement>());
                worldsDoors.Add(new List<AStaticObject>());
            }

            for (int a = 0; a < worlds.Count; a++)
            {
                foreach (var place in worlds[a].Doors)
                {
                    worldsDoors[a].Add(new StaticObject(opbouwSprites.GetSpriteDoor(1), place));
                }
                for (int x = 0; x < worlds[a].Width; x++)
                {
                    for (int y = 0; y < worlds[a].Height; y++)
                    {
                        for (int i = 1; i <= blockOpbouw.BackgroundTiles.Count; i++)
                        {
                            if (i == worlds[a].BackgroundTiles[x, y]) worldsTiles[a].Add(new TileDefine(blockOpbouw.BackgroundTiles[i - 1], new Vector2(y * oneBlockStep, x * oneBlockStep), TileType.BackGroundTile));
                        }

                        for (int i = 1; i <= blockOpbouw.CollideTiles.Count; i++)
                        {
                            if (i == worlds[a].CollideTileLayout[x, y]) worldsTiles[a].Add(new TileDefine(blockOpbouw.CollideTiles[i - 1], new Vector2(y * oneBlockStep, x * oneBlockStep), TileType.BorderTile));
                        }

                        for (int i = 1; i <= blockOpbouw.ForegroundTiles.Count; i++)
                        {
                            if (i == worlds[a].ForegroundTiles[x, y]) worldsTiles[a].Add(new TileDefine(blockOpbouw.ForegroundTiles[i - 1], new Vector2(y * oneBlockStep, x * oneBlockStep), TileType.BackGroundTile));
                        }

                        for (int i = 1; i <= blockOpbouw.PLatformTiles.Count; i++)
                        {
                            if (i == worlds[a].PlatformTiles[x, y]) worldsTiles[a].Add(new TileDefine(blockOpbouw.PLatformTiles[i - 1], new Vector2(y * oneBlockStep, x * oneBlockStep), TileType.PlatformTile));
                        }

                        if ((worlds[a].Enemys[x, y] / 10) != 0)
                        {
                            if (a != 0) worldsEnemys[a].Add(new Enemy((PigTypes)(worlds[a].Enemys[x, y] / 10), opbouwSprites, new Vector2(y * oneBlockStep, x * oneBlockStep), (MoveTypes)(worlds[a].Enemys[x, y] % 10), spriteFonts, enemyBaseHearts + enemyBaseHearts * (a - 1), enemyBaseAttackDamage + enemyBaseAttackDamage * (a - 1)));
                            else worldsEnemys[a].Add(new Enemy((PigTypes)(worlds[a].Enemys[x, y] / 10), opbouwSprites, new Vector2(y * oneBlockStep, x * oneBlockStep), (MoveTypes)(worlds[a].Enemys[x, y] % 10), spriteFonts, enemyBaseHearts + enemyBaseHearts * (a), enemyBaseAttackDamage + enemyBaseAttackDamage * (a)));
                        }

                        if ((worlds[a].Collectable[x, y]) != 0)
                        {
                            worldsCollectables[a].Add(new Item((CollectableTypes)(worlds[a].Collectable[x, y]),opbouwSprites, (CollectableTypes)(worlds[a].Collectable[x, y]), new Vector2(y * oneBlockStep, x * oneBlockStep), MoveTypes.Static));
                        }
                    }
                }
            }
        }
    }
}

