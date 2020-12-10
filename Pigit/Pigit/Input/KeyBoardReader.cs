using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit
{
    public class KeyBoardReader : IInputReader
    {
        public bool Move { get; set; } = false;
        public bool Direction { get; set; } = false;
        public bool Attack { get; set; } = false;
        public bool Jump { get; set ; }

        KeyboardState keyboard;

        public void ReadInput()
        {
            Move = false;
            Attack = false;
            Jump = false;


            keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Left))
            {
                this.Move = true;
                this.Direction = true;
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                this.Move = true;
                this.Direction = false;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                this.Attack = true;
            }
            if (keyboard.IsKeyDown(Keys.Space))
            {
                this.Jump = true;
            }
        }
    }
}
