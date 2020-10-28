using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Movement;
using Pigit.Objects;
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
        private Human HumanRun;
        private Human HumanIdle;
        private Human HumanAttack;
        private Human HumanJump;
        private Human HumanFall;
        private IInputReader inputReader;

        private List<IPlayerObject> player = new List<IPlayerObject>();

        Dictionary<String, Texture2D> spriteHuman = new Dictionary<string, Texture2D>();


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            inputReader = new KeyBoardReader();
           

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            opbouwSprites = new SpriteOpbouw(Content);
           

            InitializeGameObjects();

            move = new MoveCommand(player, _spriteBatch);
        }

        private void InitializeGameObjects()
        {
            HumanRun = new Human(opbouwSprites.SpriteHuman.GetValueOrDefault("runR"), opbouwSprites.SpriteHuman.GetValueOrDefault("runL"), new Vector2(78,58),8);
            HumanIdle = new Human(opbouwSprites.SpriteHuman.GetValueOrDefault("idleR"), opbouwSprites.SpriteHuman.GetValueOrDefault("idleL"), new Vector2(78, 58), 11);
            HumanAttack = new Human(opbouwSprites.SpriteHuman.GetValueOrDefault("attackR"), opbouwSprites.SpriteHuman.GetValueOrDefault("attackL"), new Vector2(78, 58), 3);
            HumanJump = new Human(opbouwSprites.SpriteHuman.GetValueOrDefault("jumpR"), opbouwSprites.SpriteHuman.GetValueOrDefault("jumpL"), new Vector2(78, 58), 1);
            HumanFall = new Human(opbouwSprites.SpriteHuman.GetValueOrDefault("fallR"), opbouwSprites.SpriteHuman.GetValueOrDefault("fallL"), new Vector2(78, 58), 1);
            player.Add(HumanRun);
            player.Add(HumanIdle);
            player.Add(HumanAttack);
            player.Add(HumanJump);
            player.Add(HumanFall);
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

            move.DrawMovement();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
