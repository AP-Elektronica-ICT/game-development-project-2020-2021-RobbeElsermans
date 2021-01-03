using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pigit.Input.Interfaces;

namespace Pigit
{
    class MouseReader : IInputReader
    {
        public bool Move { get; set; } = false;
        public bool Direction { get ; set ; } = false;
        public bool Attack { get ; set; }= false;
        public bool Jump { get; set; }

        private Vector2 movement;

        public void ReadInput()
        {
                MouseState state = Mouse.GetState();
                movement = new Vector2(state.X, state.Y);
        }
    }
}
