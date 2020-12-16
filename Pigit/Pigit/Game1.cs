using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Map;
using Pigit.Movement;
using Pigit.Objects;
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

        private CameraAnimatie _camera;

        private AMovement moveHero;
        private SpriteOpbouw opbouwSprites;
        public static int ScreenWidth;
        public static int ScreenHeight;
        private List<IWorldLayout> worldsLevel1;


        private Level level;


        INPCObject player;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            ScreenHeight = _graphics.GraphicsDevice.Viewport.Height;
            ScreenWidth = _graphics.GraphicsDevice.Viewport.Width;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            worldsLevel1 = new List<IWorldLayout>();
            worldsLevel1.Add(new World1Layout());
            worldsLevel1.Add(new World2Layout());

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

            level = new Level(Content, worldsLevel1, player);
            level.CreateWorlds();

            moveHero = new MoveCommandHero((IPlayerObject)player, level);


            _camera = new CameraAnimatie();
        }

        protected override void Update(GameTime gameTime)
        {
            _camera.Follow(player);

            moveHero.CheckMovement(gameTime);
            level.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(transformMatrix: _camera.Transform, sortMode: SpriteSortMode.Immediate);

            //Draw Tiles
            level.DrawWorld(_spriteBatch);


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
            _spriteBatch.Draw(_rectBlock, player.Rectangle, Color.White);

            //Teken player
            player.Draw(_spriteBatch);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
