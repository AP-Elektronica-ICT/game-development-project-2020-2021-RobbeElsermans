using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pigit.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Movement
{
    class MoveCommand
    {
        private IInputReader keyboard;
        List<IPlayerObject> player;
        SpriteBatch _spriteBatch;
        private bool hasJumped;

        public MoveCommand(List<IPlayerObject> player, SpriteBatch _spriteBatch)
        {
            keyboard = new KeyBoardReader();
            this.player = player;
            this._spriteBatch = _spriteBatch;
            hasJumped = true;
        }


        /*
         * TODO
         * fall sprite implementeren
         */
        public void CheckMovement(GameTime gameTime)
        {
            keyboard.ReadInput();
            if (keyboard.Attack)
            {
                if (keyboard.Direction)
                {
                    player[2].Update(gameTime, Vector2.Zero);
                }
                else
                {
                    player[2].Update(gameTime, Vector2.Zero);
                }
            }
            if (keyboard.Jump && !hasJumped)
            {
                //IPlayerObject.Positie -= new Vector2(0f, 10f);
                IPlayerObject.Versnelling = new Vector2(0f, -5f);
                hasJumped = true;
                player[3].Update(gameTime, new Vector2(0f, -10f));
            }

            if (IPlayerObject.Positie.Y >= 400f)
            {
                IPlayerObject.Versnelling = new Vector2(0f, 0f);
                hasJumped = false;
            }
            else
            {
                float i = 1f;
                IPlayerObject.Versnelling += new Vector2(0f, 0.15f * i);
            }

            if (keyboard.Move)
            {
                if (keyboard.Direction)
                {
                    player[0].Update(gameTime, new Vector2(-1, 0));
                }
                else
                {
                    player[0].Update(gameTime, new Vector2(1, 0));
                }

            }
            else
            {
                player[1].Update(gameTime, Vector2.Zero);
            }

        }

        public void DrawMovement()
        {
            foreach (var part in player)
            {
                part.Direction = keyboard.Direction;
            }

            if (keyboard.Attack)
            {
                player[2].Draw(_spriteBatch);
            }
            else if(hasJumped)
            {
                player[3].Draw(_spriteBatch);
            }
            else if (keyboard.Move)
            {
                player[0].Draw(_spriteBatch);
            }
            else
            {
                player[1].Draw(_spriteBatch);
            }
        }
    }
}
