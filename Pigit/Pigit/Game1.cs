using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Animatie;
using Pigit.Objects;
using System;
using System.Collections.Generic;

namespace Pigit
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteOpbouw opbouwSprites;
        private Human HumanRun;
        private Human HumanIdle;
        private Human HumanAttack;
        private Human HumanJump;
        private IInputReader inputReader;
        private bool hasAttack = false;
        KeyboardState keyboard;
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

        }

        private void InitializeGameObjects()
        {
            HumanRun = new Human(opbouwSprites.SpriteHuman.GetValueOrDefault("runR"), opbouwSprites.SpriteHuman.GetValueOrDefault("runL"), new Vector2(78,58),8);
            HumanIdle = new Human(opbouwSprites.SpriteHuman.GetValueOrDefault("idleR"), opbouwSprites.SpriteHuman.GetValueOrDefault("idleL"), new Vector2(78, 58), 11);
            HumanAttack = new Human(opbouwSprites.SpriteHuman.GetValueOrDefault("attackR"), opbouwSprites.SpriteHuman.GetValueOrDefault("attackL"), new Vector2(78, 58), 3);
            HumanJump = new Human(opbouwSprites.SpriteHuman.GetValueOrDefault("attackR"), opbouwSprites.SpriteHuman.GetValueOrDefault("attackL"), new Vector2(78, 58), 1);

            player.Add(HumanRun);
            player.Add(HumanIdle);
            player.Add(HumanAttack);
            player.Add(HumanJump);
        }


        protected override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            if (inputReader.Attack)
            {
                player[2].Update(gameTime, inputReader.ReadInput());
                if (player[2].FrameCount == player[2].AmountFrames - 1)
                {
                    inputReader.HasAttacked = true;
                }
            }
            else
            {
                if (inputReader.Move)
                {
                    player[0].Update(gameTime, inputReader.ReadInput());
                }
                else
                {
                    player[1].Update(gameTime, inputReader.ReadInput());
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            _spriteBatch.Begin();

            foreach (var part in player)
            {
                part.Direction = inputReader.Direction;
            }

            if(hasAttack)
            {
                hasAttack = false;
                player[2].Draw(_spriteBatch);
            }
            else if (inputReader.Attack && !inputReader.HasAttacked)
            {
                player[2].Draw(_spriteBatch);
                hasAttack = true;
            }
            
            else if (inputReader.Move)
            {
                player[0].Draw(_spriteBatch);
            }
            else
            {
                player[1].Draw(_spriteBatch);
            }

            if (inputReader.Attack && inputReader.HasAttacked)
            {

                inputReader.Attack = false;
                inputReader.HasAttacked = false;
            }

                _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
