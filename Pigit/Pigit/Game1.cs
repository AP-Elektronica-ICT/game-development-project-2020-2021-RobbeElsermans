using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Global.Enums;
using Pigit.Input;
using Pigit.Input.Interfaces;
using Pigit.Map;
using Pigit.Map.Interfaces;
using Pigit.Movement;
using Pigit.Objects;
using Pigit.Objects.Interfaces;
using Pigit.Objects.PlayerObjects;
using Pigit.SpriteBuild;
using Pigit.Text;
using Pigit.Text.Abstract;
using Pigit.Text.Menus;
using Pigit.TileBuild.Interface;
using System;
using System.Collections.Generic;

namespace Pigit
{
    public class Game1 : Game
    {
        private const float maxZoom = 1.5f;
        private const float noZoom = 1f;
        private const int heroHearts = 1000;
        private const int heroAttackDamage = 100;

        public static GameLoop currGameState { get; set; }
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private CameraAnimatie _cameraAnimatie;

        private AMovement moveHero;
        private SpriteGenerator opbouwSprites;

        public static int ScreenWidth;
        public static int ScreenHeight;

        private List<IRoomLayout> levelsWorld1;
        private Level level1;
        IObject player;

        private AShowMenu startMenu;
        private AShowMenu pauseMenu;
        private AShowMenu deadMenu;
        private AShowMenu endMenu;
        private TextGenerator textGenerator;
        private List<string> startMenuText;
        private List<string> pauseMenuText;
        private List<string> deadMenuText;
        private List<string> endMenuText;

        private IInputReader KeyBoardReader;

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
            KeyBoardReader = new KeyBoardReader();

            levelsWorld1 = new List<IRoomLayout>();
            levelsWorld1.Add(new StartWorldLayout());
            levelsWorld1.Add(new World1Room1Layout());
            levelsWorld1.Add(new World1Room2Layout());
            levelsWorld1.Add(new World1Room3Layout());
            levelsWorld1.Add(new World1Room4Layout());

            startMenuText = new List<string>
            {
                "Pigit", "Play", "Help", "Settings", "Exit Game","->"
            };

            pauseMenuText = new List<string>
            {
                 "Pause", "Resume", "Help", "Main Menu", "->"
            };

            deadMenuText = new List<string>
            {
                 "Dead","Main Menu", "Help", "Exit Game", "->"
            };

            endMenuText = new List<string>
            {
                 "End","Main Menu", "Help", "Exit Game", "->"
            };

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            InitializeGameObjects();

            currGameState = GameLoop.Menu;
        }

        private void InitializeGameObjects()
        {
            textGenerator = new TextGenerator(Content);
            opbouwSprites = new SpriteGenerator(Content);

            player = new Human(opbouwSprites.GetSpriteHuman(12), Vector2.Zero, textGenerator.SpriteFonts, heroHearts,heroAttackDamage);

            level1 = new Level(Content, levelsWorld1, player as IPlayerObject, textGenerator.SpriteFonts);
            level1.CreateLevels();

            moveHero = new MoveCommandHero((IPlayerObject)player, level1, KeyBoardReader);

            _cameraAnimatie = new CameraAnimatie();

            startMenu = new StartMenu(textGenerator.SpriteFonts, (IInputMenu)KeyBoardReader, new Vector2(12, 2), startMenuText);
            pauseMenu = new PauseMenu(textGenerator.SpriteFonts, (IInputMenu)KeyBoardReader, new Vector2(2, 2), pauseMenuText);
            deadMenu = new EndingGameMenu(textGenerator.SpriteFonts, (IInputMenu)KeyBoardReader, new Vector2(2, 2), deadMenuText);
            endMenu = new EndingGameMenu(textGenerator.SpriteFonts, (IInputMenu)KeyBoardReader, new Vector2((levelsWorld1[levelsWorld1.Count-1].Warp1.X/32)-2, (levelsWorld1[levelsWorld1.Count - 1].Warp1.Y / 32)-4), endMenuText);
        }

        protected override void Update(GameTime gameTime)
        {
            CheckInputs(KeyBoardReader as IInputMenu);

            switch (currGameState)
            {
                case GameLoop.Menu:
                    startMenu.Update(gameTime);
                    level1.Play = false;
                    level1.Update(gameTime);
                    _cameraAnimatie.Zoom = noZoom;
                    if (currGameState != GameLoop.Play)
                        moveHero.CheckMovement(gameTime);

                    break;
                case GameLoop.Play:
                    _cameraAnimatie.Follow(player);
                    level1.Play = true;
                    level1.Update(gameTime);
                    moveHero.CheckMovement(gameTime);

                    CameraZoomIn();

                    break;
                case GameLoop.Pause:
                    pauseMenu.Update(gameTime);

                    break;
                case GameLoop.Dead:
                    deadMenu.Update(gameTime);
                    _cameraAnimatie.Follow(player);
                    
                    moveHero.CheckMovement(gameTime);
                    CameraZoomOut();

                    break;
                case GameLoop.End:
                    endMenu.Update(gameTime);
                    _cameraAnimatie.Follow(player);
                    level1.Play = true;
                    level1.Update(gameTime);

                    moveHero.CheckMovement(gameTime);
                    CameraZoomOut();

                    break;
                case GameLoop.Exit:
                    Exit();
                    break;
                default:
                    break;
            }

            base.Update(gameTime);
        }

        private void CameraZoomIn()
        {
            if (_cameraAnimatie.Zoom <= maxZoom)
            {
                float x = 1f;
                _cameraAnimatie.Zoom += x * 0.005f;
            }
        }
        private void CameraZoomOut()
        {
            if (_cameraAnimatie.Zoom >= noZoom)
            {
                float x = 1f;
                _cameraAnimatie.Zoom -= x * 0.005f;
            }
        }

        private void CheckInputs(IInputMenu keys)
        {
            keys.ReadInput();
            if (keys.Esc && currGameState == GameLoop.Play)
            {
                currGameState = GameLoop.Pause;
            }
        }

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
                    _spriteBatch.Begin(transformMatrix: _cameraAnimatie.Transform, sortMode: SpriteSortMode.Deferred, blendState: BlendState.AlphaBlend);

                    level1.DrawWorld(_spriteBatch);
                    player.Draw(_spriteBatch);

                    break;
                case GameLoop.Pause:
                    _spriteBatch.Begin();

                    pauseMenu.Draw(_spriteBatch);
                    break;
                case GameLoop.Dead:
                    _spriteBatch.Begin(transformMatrix: _cameraAnimatie.Transform, sortMode: SpriteSortMode.Deferred, blendState: BlendState.AlphaBlend);

                    player.Draw(_spriteBatch);

                    deadMenu.Draw(_spriteBatch);
                    break;
                case GameLoop.End:
                    _spriteBatch.Begin(transformMatrix: _cameraAnimatie.Transform, sortMode: SpriteSortMode.Deferred, blendState: BlendState.AlphaBlend);

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
