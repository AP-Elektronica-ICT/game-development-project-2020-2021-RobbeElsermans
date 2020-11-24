using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Map;
using Pigit.Movement;
using Pigit.Objects;
using Pigit.SpriteBuild;
using Pigit.TileBuild;
using System;
using System.Collections.Generic;

namespace Pigit
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _rectBlock;
        private Texture2D _rectBlock2;


        private MoveCommand move;
        private SpriteOpbouw opbouwSprites;
        

        private Level beginWorld;


        IPlayerObject player;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
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


            opbouwSprites = new SpriteOpbouw(Content, 12);

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            beginWorld = new Level(Content, new World1Layout());
            beginWorld.CreateWorld();

            player = new Human(opbouwSprites);
            player.Positie = new Vector2(5*32, 4*32);


            move = new MoveCommand(player, beginWorld);
        }

        protected override void Update(GameTime gameTime)
        {
            move.CheckMovement(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            //Draw Tiles
            beginWorld.DrawWorld(_spriteBatch);


            //DEBUG

            //foreach (var tile in beginWorld.Tiles)
            //{
            //    if (tile is ICollideTile)
            //    {
            //        var temp = tile as ICollideTile;
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
