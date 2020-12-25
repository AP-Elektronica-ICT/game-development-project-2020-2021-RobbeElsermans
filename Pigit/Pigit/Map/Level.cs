﻿using Microsoft.Xna.Framework;
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

namespace Pigit.Map
{
    class Level
    {
        private List<IRoomLayout> worlds;
        //private IWorldLayout currentWorld;
        private TileOpbouw blockOpbouw;
        private List<List<IPlayerObject>> worldEnemys;
        private List<List<AMovement>> worldsMoveEnemys;
        private List<List<ACollectableMovement>> worldsMoveCollectables;
        private List<List<ICollectableObject>> worldsCollectables;
        private SpriteGenerator opbouwSprites;
        private ContentManager content;
        private IMoveable heroPlayer;
        private List<List<ITile>> worldsTiles;

        public List<ITile> CurrTiles { get; set; }
        public List<IPlayerObject> CurrEnemys { get; set; }

        public List<AMovement> CurrMovementEnemy { get; set; }
        public List<ICollectableObject> CurrCollectable { get; set; }
        public int CurrMap { get; set; } = 2;
        public List<ACollectableMovement> CurrMovementCollectables { get; private set; }

        public Level(ContentManager content, List<IRoomLayout> worlds, IMoveable hero)
        {
            heroPlayer = hero;
            this.worlds = worlds;
            this.content = content;
            opbouwSprites = new SpriteGenerator(content);

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

        private void InitializeTiles(ContentManager content)
        {
            this.blockOpbouw = new TileOpbouw(content);
        }
        public void Update(GameTime gameTime)
        {
            CheckCollected();
            CheckEnemys();

            foreach (var moveCommand in CurrMovementEnemy)
            {
                moveCommand.CheckMovement(gameTime);
            }
            foreach (var moveCommand in CurrMovementCollectables)
            {
                moveCommand.CheckMovement(gameTime);
            }
        }

        private void CheckEnemys()
        {
            for (int i = 0; i < CurrEnemys.Count; i++)
            {
                if (CurrEnemys[i].Dead)
                {
                    CurrEnemys.RemoveAt(i);
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
                }
            }
        }

        public void CreateLevels()
        {
            InitializeTiles(content);

            GeneratelevelContent(content);
            GenerateMovement();
            CheckCurrMap();
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
                            worldsMoveEnemys[i].Add(new MoveCommandWalkNPC((IPlayerObject)enemy, this));
                            break;
                        case MoveTypes.GuardTime:
                            worldsMoveEnemys[i].Add(new MoveCommandGuardNPC((IPlayerObject)enemy, this, 5.0, 3.0));
                            break;
                        case MoveTypes.GuardPosition:
                            worldsMoveEnemys[i].Add(new MoveCommandGuardNPC((IPlayerObject)enemy, this, (int)enemy.Positie.X - 32, (int)enemy.Positie.X + 32, 4.0));
                            break;
                        case MoveTypes.Follow:
                            worldsMoveEnemys[i].Add(new MoveCommandFollowNPC((IPlayerObject)enemy, this));
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
            CurrEnemys = worldEnemys[CurrMap];
            CurrTiles = worldsTiles[CurrMap];
            CurrMovementEnemy = worldsMoveEnemys[CurrMap];

            CurrCollectable = worldsCollectables[CurrMap];
            CurrMovementCollectables = worldsMoveCollectables[CurrMap];
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
                                worldsTiles[a].Add(new TileDefine(blockOpbouw.BackgroundTiles[i - 1], new Vector2(y * 32, x * 32)));
                            }
                        }

                        for (int i = 1; i <= blockOpbouw.CollideTiles.Count; i++)
                        {
                            if (i == worlds[a].CollideTileLayout[x, y])
                            {
                                worldsTiles[a].Add(new CollideTileDefine(blockOpbouw.CollideTiles[i - 1], new Vector2(y * 32, x * 32)));
                            }
                        }

                        for (int i = 1; i <= blockOpbouw.ForegroundTiles.Count; i++)
                        {
                            if (i == worlds[a].ForegroundTiles[x, y])
                            {
                                worldsTiles[a].Add(new TileDefine(blockOpbouw.ForegroundTiles[i - 1], new Vector2(y * 32, x * 32)));
                            }
                        }

                        for (int i = 1; i <= blockOpbouw.PLatformTiles.Count; i++)
                        {
                            if (i == worlds[a].PlatformTiles[x, y])
                            {
                                worldsTiles[a].Add(new PlatformTileDefine(blockOpbouw.PLatformTiles[i - 1], new Vector2(y * 32, x * 32)));
                            }
                        }
                        switch ((PigTypes)(worlds[a].Enemys[x, y] / 10))
                        {
                            case PigTypes.Standard:
                                worldEnemys[a].Add(new Pig(opbouwSprites.GetSpritePig(12), new Vector2(y * 32, x * 32), (MoveTypes)(worlds[a].Enemys[x, y] % 10)));
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
                                worldsCollectables[a].Add(new Item(opbouwSprites.GetSpriteBigHeart(6), (CollectableTypes)(worlds[a].Collectable[x, y]), new Vector2(y * 32, x * 32), MoveTypes.Static,2));
                                break;
                            case CollectableTypes.BigDiamond:
                                worldsCollectables[a].Add(new Item(opbouwSprites.GetSpriteBigDiamond(6), (CollectableTypes)(worlds[a].Collectable[x, y]), new Vector2(y * 32, x * 32), MoveTypes.Static,10));
                                break;
                            case CollectableTypes.SmallHeart:
                                worldsCollectables[a].Add(new Item(opbouwSprites.GetSpriteSmallHeart(6), (CollectableTypes)(worlds[a].Collectable[x, y]), new Vector2(y * 32, x * 32), MoveTypes.Static,1)) ;
                                break;
                            case CollectableTypes.SmallDiamond:
                                worldsCollectables[a].Add(new Item(opbouwSprites.GetSpriteSmallDiamond(6), (CollectableTypes)(worlds[a].Collectable[x, y]), new Vector2(y * 32, x * 32), MoveTypes.Static,5));
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
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
    }
}

