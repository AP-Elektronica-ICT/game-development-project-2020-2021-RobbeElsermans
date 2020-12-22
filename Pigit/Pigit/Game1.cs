using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Map;
using Pigit.Map.Interfaces;
using Pigit.Movement;
using Pigit.Objects;
using Pigit.Objects.Interfaces;
using Pigit.Objects.PlayerObjects;
using Pigit.SpriteBuild;
using Pigit.SpriteBuild.Enums;
using Pigit.TileBuild;
using Pigit.TileBuild.Interface;
using System;
using System.Collections.Generic;

namespace Pigit
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //DEBUG
        private Texture2D _rectBlock;
        private Texture2D _rectBlock2;
        //DEBUG

        private CameraAnimatie _cameraAnimatie;

        private AMovement moveHero;
        private SpriteOpbouw opbouwSprites;

        public static int ScreenWidth;
        public static int ScreenHeight;

        private List<IRoomLayout> levelsWorld1;
        private Level level1;
        IObject player;

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
            _rectBlock = new Texture2D(GraphicsDevice,1,1);
            _rectBlock.SetData(new Color[] { Color.Red });
            _rectBlock2 = new Texture2D(GraphicsDevice, 1, 1);
            _rectBlock2.SetData(new Color[] { Color.Blue });

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            opbouwSprites = new SpriteOpbouw(Content);

            player = new Human(opbouwSprites.GetSpriteHuman(12), new Vector2(5 * 32, 4 * 32));

            level1 = new Level(Content, levelsWorld1, player);
            level1.CreateLevels();

            moveHero = new MoveCommandHero((IPlayerObject)player, level1, KeyBoardReader);


            _cameraAnimatie = new CameraAnimatie();
        }

        protected override void Update(GameTime gameTime)
        {
            _cameraAnimatie.Follow(player);

            //if (Keyboard.GetState().IsKeyDown(Keys.I))
            //{
            //    _cameraZoom.Zoom += 0.1f;
            //}
            //else if (Keyboard.GetState().IsKeyDown(Keys.K))
            //{
            //    _cameraZoom.Zoom -= 0.1f;
            //}

            moveHero.CheckMovement(gameTime);
            level1.Update(gameTime);
                        
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(transformMatrix: _cameraAnimatie.Transform, sortMode: SpriteSortMode.Deferred, blendState: BlendState.AlphaBlend);

            //Draw Tiles & enemys
            level1.DrawWorld(_spriteBatch);

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
            player.Draw(_spriteBatch);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
