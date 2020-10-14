using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pigit
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D humanRun;
        private Texture2D humanIdle;
        private Human HumanIdle;
        private Human HumanRun;
        KeyboardState keyboard;
        Boolean move = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            humanRun = Content.Load<Texture2D>(@"Human\Run (78x58)");
            humanIdle = Content.Load<Texture2D>(@"Human\Idle (78x58)");
            InitializeGameObjects();

        }

        private void InitializeGameObjects()
        {
            HumanRun = new Human(humanRun, new Vector2(78,58),8);
            HumanIdle = new Human(humanIdle, new Vector2(78, 58),11);
        }


        protected override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Vector2 verplaatsing = new Vector2(0, 0);
            move = false;

            if (keyboard.IsKeyDown(Keys.Down))
            {
                verplaatsing.Y += 1;
                move = true;
            }
            if (keyboard.IsKeyDown(Keys.Up))
            {
                verplaatsing.Y -= 1;
                move = true;
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                verplaatsing.X -= 1;
                move = true;
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                verplaatsing.X += 1;
                move = true;
            }


            if (move)
            {
                HumanRun.Update(gameTime, verplaatsing);
            }
            else
            {
                HumanIdle.Positie = HumanRun.Positie;
                HumanIdle.Update(gameTime);
            }


            
            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (move)
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
