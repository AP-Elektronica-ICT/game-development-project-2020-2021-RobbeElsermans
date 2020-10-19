using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit
{
    class MouseReader : IInputReader
    {
        public bool Move { get; set; } = false;
        public bool Direction { get ; set ; } = false;
        public bool Attack { get ; set; }= false;
        public bool jump { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool hasjumped { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private Vector2 movement;

        public Vector2 ReadInput()
        {
                MouseState state = Mouse.GetState();
                movement = new Vector2(state.X, state.Y);
                return movement;
        }
    }
}
