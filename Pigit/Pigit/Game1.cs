using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Map;
using Pigit.Movement;
using Pigit.Objects;
using Pigit.SpriteBuild;
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


        private Level beginWorld;


        INPCObject player;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;

            base.Initialize();
        }

        protected override void LoadContent()
        {
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

            beginWorld = new Level(Content, new World1Layout());
            beginWorld.CreateWorld();

            player = new Human(opbouwSprites.GetSpriteHuman(12));
            player.Positie = new Vector2(5*32, 4*32);

            moveHero = new MoveCommandHero(player, beginWorld);

            _camera = new CameraAnimatie();
        }

        protected override void Update(GameTime gameTime)
        {
            _camera.Follow(player);

            moveHero.CheckMovement(gameTime);
            beginWorld.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(transformMatrix: _camera.Transform);

            //Draw Tiles
            beginWorld.DrawWorld(_spriteBatch);


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
