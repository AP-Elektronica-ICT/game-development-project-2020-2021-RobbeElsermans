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

        int aantal = 0;
        private Pigit.Animatie.SpriteOpbouw opbouw;
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
            opbouw = new Pigit.Animatie.SpriteOpbouw(Content);
            /*
            spriteHuman.Add("runR", Content.Load<Texture2D>(@"Human\Run (78x58)"));
            spriteHuman.Add("runL", Content.Load<Texture2D>(@"Human\Run Left (78x58)"));
            spriteHuman.Add("idleR", Content.Load<Texture2D>(@"Human\Idle (78x58)"));
            spriteHuman.Add("idleL", Content.Load<Texture2D>(@"Human\Idle Left(78x58)"));
            spriteHuman.Add("jumpR", Content.Load<Texture2D>(@"Human\Jump (78x58)"));
            spriteHuman.Add("jumpL", Content.Load<Texture2D>(@"Human\Jump Left(78x58)"));
            spriteHuman.Add("hitR", Content.Load<Texture2D>(@"Human\Hit (78x58)"));
            spriteHuman.Add("hitL", Content.Load<Texture2D>(@"Human\Hit Left(78x58)"));
            spriteHuman.Add("groundR", Content.Load<Texture2D>(@"Human\Ground (78x58)"));
            spriteHuman.Add("groundL", Content.Load<Texture2D>(@"Human\Ground Left(78x58)"));
            spriteHuman.Add("fallR", Content.Load<Texture2D>(@"Human\Fall (78x58)"));
            spriteHuman.Add("fallL", Content.Load<Texture2D>(@"Human\Fall Left(78x58)"));
            spriteHuman.Add("dooroutR", Content.Load<Texture2D>(@"Human\Door Out (78x58)"));
            spriteHuman.Add("dooroutL", Content.Load<Texture2D>(@"Human\Door Out Left(78x58)"));
            spriteHuman.Add("doorinR", Content.Load<Texture2D>(@"Human\Door In (78x58)"));
            spriteHuman.Add("doorinL", Content.Load<Texture2D>(@"Human\Door In Left(78x58)"));
            spriteHuman.Add("deadR", Content.Load<Texture2D>(@"Human\Dead (78x58)"));
            spriteHuman.Add("deadL", Content.Load<Texture2D>(@"Human\Dead Left(78x58)"));
            spriteHuman.Add("attackR", Content.Load<Texture2D>(@"Human\Attack (78x58)"));
            spriteHuman.Add("attackL", Content.Load<Texture2D>(@"Human\Attack Left(78x58)"));
            */
           

            InitializeGameObjects();

        }

        private void InitializeGameObjects()
        {
            HumanRun = new Human(opbouw.SpriteHuman.GetValueOrDefault("runR"), spriteHuman.GetValueOrDefault("runL"), new Vector2(78,58),8);
            HumanIdle = new Human(opbouw.SpriteHuman.GetValueOrDefault("idleR"), spriteHuman.GetValueOrDefault("idleL"), new Vector2(78, 58), 11);
            HumanAttack = new Human(opbouw.SpriteHuman.GetValueOrDefault("attackR"), spriteHuman.GetValueOrDefault("attackL"), new Vector2(78, 58), 3);
            HumanJump = new Human(opbouw.SpriteHuman.GetValueOrDefault("attackR"), spriteHuman.GetValueOrDefault("attackL"), new Vector2(78, 58), 1);

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
