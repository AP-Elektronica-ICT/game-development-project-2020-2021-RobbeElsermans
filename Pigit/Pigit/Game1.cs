using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        Dictionary<String, Texture2D> spriteHuman = new Dictionary<string, Texture2D>();

        KeyboardState keyboard;
        bool move;
        bool direction;
        bool attack;
        bool jump;
        bool hasJumped;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            move = false; //niet lopen
            direction = false; //dit is rechts
            attack = false; //niet aanvallen
            jump = false; //niet springen
            hasJumped = false;

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
        }


        protected override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Vector2 verplaatsing = new Vector2(0, 0);
            move = false;
            attack = false;
            jump = false;

            if (keyboard.IsKeyDown(Keys.Down))
            {
                verplaatsing.Y += 1;
                this.move = true;
            }
            if (keyboard.IsKeyDown(Keys.Up))
            {
                verplaatsing.Y -= 1;
                this.move = true;
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                verplaatsing.X -= 1;
                move = true;
                this.direction = true;
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                verplaatsing.X += 1;
                move = true;
                this.direction = false;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                this.attack = true;
            }

            if (keyboard.IsKeyDown(Keys.Space) && hasJumped == false)
            {
                jump = true;
                hasJumped = true;
            }



            if (move)
            {
                HumanRun.Update(gameTime, verplaatsing);
            }
            else
            {
                HumanIdle.Update(gameTime);
            }

            if (attack)
            {
                HumanAttack.Update(gameTime);
            }

            if (jump)
            {
                HumanJump.Update(gameTime, new Vector2(0, -20));
            }

            Human.Direction = this.direction;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (attack)
            {
                HumanAttack.Draw(_spriteBatch);
            }
            else if (move)
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
