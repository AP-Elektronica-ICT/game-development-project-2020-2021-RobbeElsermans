using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pigit.Objects;
using System;
using System.Collections.Generic;

namespace Pigit
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Human HumanRun;
        private Human HumanIdle;
        private Human HumanAttack;
        private Human HumanJump;
        private IInputReader inputReader;
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


            InitializeGameObjects();

        }

        private void InitializeGameObjects()
        {
            HumanRun = new Human(spriteHuman.GetValueOrDefault("runR"), spriteHuman.GetValueOrDefault("runL"), new Vector2(78,58),8);
            HumanIdle = new Human(spriteHuman.GetValueOrDefault("idleR"), spriteHuman.GetValueOrDefault("idleL"), new Vector2(78, 58), 11);
            HumanAttack = new Human(spriteHuman.GetValueOrDefault("attackR"), spriteHuman.GetValueOrDefault("attackL"), new Vector2(78, 58), 3);
            HumanJump = new Human(spriteHuman.GetValueOrDefault("attackR"), spriteHuman.GetValueOrDefault("attackL"), new Vector2(78, 58), 1);

            player.Add(HumanRun);
            player.Add(HumanIdle);
            player.Add(HumanAttack);
            player.Add(HumanJump);
        }


        protected override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();

            if (inputReader.Move)
            {
                player[0].Update(gameTime, inputReader.ReadInput());
            }
            else
            {
                player[1].Update(gameTime, inputReader.ReadInput());
            }
            if (inputReader.Attack)
            {
                player[2].Update(gameTime, inputReader.ReadInput());
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            foreach (var part in player)
            {
                part.Direction = inputReader.Direction;
            }


            if (inputReader.Attack)
            {
                HumanAttack.Draw(_spriteBatch);
            }
            else if (inputReader.Move)
            {
                HumanRun.Draw(_spriteBatch);
            }
            else
            {
                HumanIdle.Draw(_spriteBatch);
            }
            

            


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
