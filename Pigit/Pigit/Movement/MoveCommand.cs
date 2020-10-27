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

        public MoveCommand(List<IPlayerObject> player, SpriteBatch _spriteBatch)
        {
            keyboard = new KeyBoardReader();
            this.player = player;
            this._spriteBatch = _spriteBatch;
        }

        public void CheckMovement(GameTime gameTime)
        {
            if (keyboard.Attack)
            {
                player[2].Update(gameTime, keyboard.ReadInput());
       
                    //keyboard.Attack = true;
                
            }

            else
            {
                if (keyboard.Move)
                {
                    player[0].Update(gameTime, keyboard.ReadInput());
                }
                else
                {
                    player[1].Update(gameTime, keyboard.ReadInput());
                }
            }
        }

        public void DrawMovement( )
        {
            foreach (var part in player)
            {
                part.Direction = keyboard.Direction;
            }

            if (keyboard.HasAttacked)
            {
                //keyboard.HasAttacked = false;
                player[2].Draw(_spriteBatch);
            }
            else if (keyboard.Attack && !keyboard.HasAttacked)
            {
                player[2].Draw(_spriteBatch);
                //keyboard.HasAttacked = true;
            }

            else if (keyboard.Move)
            {
                player[0].Draw(_spriteBatch);
            }
            else
            {
                player[1].Draw(_spriteBatch);
            }

            if (keyboard.Attack && keyboard.HasAttacked)
            {

                keyboard.Attack = false;
                keyboard.HasAttacked = false;
            }
        }
    }
}
