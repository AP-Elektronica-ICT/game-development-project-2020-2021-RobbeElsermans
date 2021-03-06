﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Animatie;
using Pigit.Global.Enums;
using Pigit.Input;
using Pigit.Input.Interfaces;
using Pigit.Map;
using Pigit.Map.Interfaces;
using Pigit.Movement.Abstracts;
using Pigit.Movement.HeroMoveCommands;
using Pigit.Music;
using Pigit.Music.Abstracts;
using Pigit.Music.Generator;
using Pigit.Objects.Interfaces;
using Pigit.Objects.PlayerObjects;
using Pigit.SpriteBuild.Generator;
using Pigit.Text.Abstract;
using Pigit.Text.Generator;
using Pigit.Text.Menus;
using System.Collections.Generic;

namespace Pigit
{
    public class Game1 : Game
    {
        public static GameLoop currGameState { get; set; }
        public static int ScreenWidth { get; private set; }
        public static int ScreenHeight { get; private set; }

        private const float maxZoom = 1.5f;
        private const float noZoom = 1f;
        private const int heroHearts = 120;
        private const int heroAttackDamage = 2;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private CameraAnimatie _cameraAnimation;

        private AMovement moveHero;
        private SpriteGenerator generateSprites;

        private List<IRoomLayout> levelsWorld1;
        private Level level1;
        IPlayerObject player;

        private AShowMenu startMenu;
        private AShowMenu pauseMenu;
        private AShowMenu deadMenu;
        private AShowMenu endMenu;
        private FontGenerator fontGenerator;
        private List<string> startMenuItems;
        private List<string> pauseMenuItems;
        private List<string> deadMenuItems;
        private List<string> endMenuItems;

        private IInputReader keyBoardReader;

        private MusicGenerator musicGenerator;
        private GameMusic gameMusic;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            ScreenHeight = _graphics.GraphicsDevice.Viewport.Height;
            ScreenWidth = _graphics.GraphicsDevice.Viewport.Width;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            keyBoardReader = new KeyBoardReader();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            #region add worlds to level1
            levelsWorld1 = new List<IRoomLayout>();
            levelsWorld1.Add(new StartWorldLayout());
            levelsWorld1.Add(new World1Room1Layout());
            levelsWorld1.Add(new World1Room2Layout());
            levelsWorld1.Add(new World1Room3Layout());
            levelsWorld1.Add(new World1Room4Layout());
            #endregion
            #region add menu items to the menus
            startMenuItems = new List<string>
            {
                "Pigit", "Play", "Exit Game","->"
            };

            pauseMenuItems = new List<string>
            {
                 "Pause", "Resume", "Main Menu", "->"
            };

            deadMenuItems = new List<string>
            {
                 "Dead","Main Menu", "Exit Game", "->"
            };

            endMenuItems = new List<string>
            {
                 "End","Main Menu", "Exit Game", "->"
            };
            #endregion
            #region generate
            fontGenerator = new FontGenerator(Content);
            generateSprites = new SpriteGenerator(Content);
            musicGenerator = new MusicGenerator(Content);
            #endregion
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            #region initialize game music
            gameMusic = new GameMusic(musicGenerator);
            #endregion
            #region initialize Hero
            player = new Human(generateSprites.GetSpriteHuman(12), Vector2.Zero, fontGenerator.SpriteFonts, heroHearts, heroAttackDamage);
            #endregion
            #region initialize level1
            level1 = new Level(Content, levelsWorld1, player, fontGenerator.SpriteFonts, new EnemyEffects(musicGenerator));
            level1.CreateLevels();
            #endregion
            #region initialize hero movements
            moveHero = new MoveCommandHero(player, level1, keyBoardReader, new HumanEffect(musicGenerator));
            #endregion
            #region initialize camera animation
            _cameraAnimation = new CameraAnimatie((IInputSecredKeys)keyBoardReader);
            #endregion
            #region initialize menus
            startMenu = new StartMenu(fontGenerator.SpriteFonts, (IInputMenu)keyBoardReader, new Vector2(12, 2), startMenuItems);
            pauseMenu = new PauseMenu(fontGenerator.SpriteFonts, (IInputMenu)keyBoardReader, new Vector2(2, 2), pauseMenuItems);
            deadMenu = new EndingGameMenu(fontGenerator.SpriteFonts, (IInputMenu)keyBoardReader, new Vector2(2, 2), deadMenuItems);
            endMenu = new EndingGameMenu(fontGenerator.SpriteFonts, (IInputMenu)keyBoardReader, new Vector2((levelsWorld1[levelsWorld1.Count - 1].Warp1.X / 32) - 2, (levelsWorld1[levelsWorld1.Count - 1].Warp1.Y / 32) - 4), endMenuItems);
            #endregion
            #region initialize gameloop
            currGameState = GameLoop.Menu;
            #endregion
        }

        protected override void Update(GameTime gameTime)
        {
            CheckInputs(keyBoardReader as IInputMenu);

            switch (currGameState)
            {
                case GameLoop.Menu:
                    startMenu.Update(gameTime);
                    gameMusic.StopAllSongs();
                    level1.Play = false;
                    level1.Update(gameTime);

                    _cameraAnimation.Zoom = noZoom;             //Set camera for no zooming
                    if (currGameState != GameLoop.Play)         //Checks if gameloop has changed in the past
                        moveHero.CheckMovement(gameTime);
                    break;
                case GameLoop.Play:
                    _cameraAnimation.Follow(player);
                    gameMusic.StartIngameSong();

                    level1.Play = true;
                    level1.Update(gameTime);

                    moveHero.CheckMovement(gameTime);

                    CameraZoomIn();
                    break;
                case GameLoop.Pause:
                    pauseMenu.Update(gameTime);
                    gameMusic.StopAllSongs();

                    break;
                case GameLoop.Dead:
                    deadMenu.Update(gameTime);
                    gameMusic.StopIngameSong();
                    gameMusic.StopVictorySong();
                    gameMusic.StartDeadSong();
                    break;
                case GameLoop.End:
                    endMenu.Update(gameTime);
                    gameMusic.StopIngameSong();
                    gameMusic.StopDeadSong();
                    gameMusic.StartVictorySong();
                    _cameraAnimation.Follow(player);
                    level1.Play = true;
                    level1.Update(gameTime);

                    moveHero.CheckMovement(gameTime);
                    CameraZoomOut();

                    break;
                case GameLoop.Exit:
                    gameMusic.StopAllSongs();
                    Exit();
                    break;
                default:
                    break;
            }

            base.Update(gameTime);
        }
        #region camera Effects
        private void CameraZoomIn()
        {
            if (_cameraAnimation.Zoom <= maxZoom)
            {
                float x = 1f;
                _cameraAnimation.Zoom += x * 0.005f;
            }
        }
        private void CameraZoomOut()
        {
            if (_cameraAnimation.Zoom >= noZoom)
            {
                float x = 1f;
                _cameraAnimation.Zoom -= x * 0.005f;
            }
        }
        #endregion

        #region check for Escape in gameloop play
        private void CheckInputs(IInputMenu keys)
        {
            keys.ReadInput();
            if (keys.Esc && currGameState == GameLoop.Play)
            {
                currGameState = GameLoop.Pause;
            }
        }
        #endregion

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            switch (currGameState)
            {
                case GameLoop.Menu:
                    _spriteBatch.Begin();

                    level1.DrawWorld(_spriteBatch);
                    player.Draw(_spriteBatch);

                    startMenu.Draw(_spriteBatch);
                    break;
                case GameLoop.Play:
                    _spriteBatch.Begin(transformMatrix: _cameraAnimation.Transform, sortMode: SpriteSortMode.Deferred, blendState: BlendState.AlphaBlend);

                    level1.DrawWorld(_spriteBatch);
                    player.Draw(_spriteBatch);

                    break;
                case GameLoop.Pause:
                    _spriteBatch.Begin();

                    pauseMenu.Draw(_spriteBatch);
                    break;
                case GameLoop.Dead:
                    _spriteBatch.Begin();

                    deadMenu.Draw(_spriteBatch);
                    break;
                case GameLoop.End:
                    _spriteBatch.Begin(transformMatrix: _cameraAnimation.Transform, sortMode: SpriteSortMode.Deferred, blendState: BlendState.AlphaBlend);

                    level1.DrawWorld(_spriteBatch);
                    player.Draw(_spriteBatch);

                    endMenu.Draw(_spriteBatch);
                    break;
                case GameLoop.Exit:
                    _spriteBatch.Begin();

                    break;
                default:
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
