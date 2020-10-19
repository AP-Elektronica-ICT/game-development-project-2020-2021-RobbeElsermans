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
        public bool HasAttacked { get; set; } = false;
        public bool jump { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Hasjumped { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        private Vector2 movement;
        KeyboardState keyboard;

        public Vector2 ReadInput()
        {
            movement = new Vector2(0,0);
            Move = false;

            keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Left))
            {
                this.movement = new Vector2(-1, 0); 
                this.Move = true;
                this.Direction = true;
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                this.movement = new Vector2(1, 0);
                this.Move = true;
                this.Direction = false;
            }
            if (keyboard.IsKeyDown(Keys.A) && !HasAttacked)
            {
                this.Attack = true;
            }            

            return movement;
        }
    }
}
