﻿using Microsoft.Xna.Framework;
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
        public static GameLoop currGameState { get; set; }
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //DEBUG
        private Texture2D _rectBlock;
        private Texture2D _rectBlock2;
        //DEBUG

        private CameraAnimatie _cameraAnimatie;

        private AMovement moveHero;
        private SpriteGenerator opbouwSprites;

        public static int ScreenWidth;
        public static int ScreenHeight;

        private List<IRoomLayout> levelsWorld1;
        private Level level1;
        IObject player;

        private AShowMenu menuText;
        private TextGenerator textGenerator;

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
            levelsWorld1.Add(new World1Room1Layout());
            levelsWorld1.Add(new World1Room2Layout());
            levelsWorld1.Add(new StartWorldLayout());

            //_cameraZoom = new CameraZoom(GraphicsDevice.Viewport);

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //DEBUG
            _rectBlock = new Texture2D(GraphicsDevice, 1, 1);
            _rectBlock.SetData(new Color[] { Color.Red });
            _rectBlock2 = new Texture2D(GraphicsDevice, 1, 1);
            _rectBlock2.SetData(new Color[] { Color.Blue });

            InitializeGameObjects();

            currGameState = GameLoop.Menu;
        }

        private void InitializeGameObjects()
        {
            opbouwSprites = new SpriteGenerator(Content);

            player = new Human(opbouwSprites.GetSpriteHuman(12), new Vector2(5 * 32, 4 * 32));

            level1 = new Level(Content, levelsWorld1, player);
            level1.CreateLevels();

            moveHero = new MoveCommandHero((IPlayerObject)player, level1, KeyBoardReader);


            _cameraAnimatie = new CameraAnimatie();


            textGenerator = new TextGenerator(Content);
            menuText = new StartMenu(textGenerator.spriteFonts,(IInputMenu)KeyBoardReader,new Vector2(12, 2), new List<string>{"Pigit", "Start", "Help", "Settings", "Exit","->"});
        }

        protected override void Update(GameTime gameTime)
        {
            switch (currGameState)
            {
                case GameLoop.Menu:
                    menuText.Update(gameTime);
                    moveHero.CheckMovement(gameTime);
                    level1.Play = false;
                    level1.Update(gameTime);

                    break;
                case GameLoop.Play:
                    _cameraAnimatie.Follow(player);
                    moveHero.CheckMovement(gameTime);

                    level1.Play = true;
                    level1.Update(gameTime);

                    break;
                case GameLoop.Pause:
                    break;
                case GameLoop.Dead:
                    break;
                case GameLoop.End:
                    break;
                case GameLoop.Exit:
                    break;
                default:
                    break;
            }
            //if (Keyboard.GetState().IsKeyDown(Keys.I))
            //{
            //    _cameraZoom.Zoom += 0.1f;
            //}
            //else if (Keyboard.GetState().IsKeyDown(Keys.K))
            //{
            //    _cameraZoom.Zoom -= 0.1f;
            //}

            base.Update(gameTime);
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
                    menuText.Draw(_spriteBatch);
                    break;
                case GameLoop.Play:
                    _spriteBatch.Begin(transformMatrix: _cameraAnimatie.Transform, sortMode: SpriteSortMode.Deferred, blendState: BlendState.AlphaBlend);

                    level1.DrawWorld(_spriteBatch);
                    player.Draw(_spriteBatch);

                    break;
                case GameLoop.Pause:
                    break;
                case GameLoop.Dead:
                    break;
                case GameLoop.End:
                    break;
                case GameLoop.Exit:
                    break;
                default:
                    break;
            }

            //DEBUG

            //foreach (var tile in beginWorld.Tiles)
            //{
            //    if (tile is IPlatformTile)
            //    {
            //        var temp = tile as IPlatformTile;
            //        _spriteBatch.Draw(_rectBlock2, temp.Border, Color.White);
            //    }
            //}

            //if (player.Direction)
            //{
            //    _spriteBatch.Draw(_rectBlock, player.RectangleL, Color.White);
            //}
            //else
            //{
            //    _spriteBatch.Draw(_rectBlock, player.RectangleR, Color.White);
            //}

            // _spriteBatch.Draw(_rectBlock, player.Rectangle, Color.White);

            //Teken player

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
