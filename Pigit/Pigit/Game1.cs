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
            opbouwSprites = new SpriteOpbouw(Content, 12);

            InitializeGameObjects();

            move = new MoveCommand(player, _spriteBatch);
        }

        private void InitializeGameObjects()
        {
            beginWorld = new Level(Content, new World1Layout());
            beginWorld.CreateWorld();

            player = new Human(opbouwSprites);
            player.Positie = new Vector2(5*32, 4*32);
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

            //Teken player
            player.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
