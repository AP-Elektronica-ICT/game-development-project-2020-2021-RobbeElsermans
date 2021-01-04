using Microsoft.Xna.Framework.Input;
using Pigit.Input.Interfaces;

namespace Pigit.Input
{
    public class KeyBoardReader : IInputReader, IInputMenu, IInputSecredKeys
    {
        public bool Move { get; private set; } = false;
        public bool Direction { get; private set; } = false;
        public bool Attack { get; private set; } = false;
        public bool Jump { get; private set ; }
        public bool Enter { get; private set; }
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Esc { get; private set; }
        public bool RotateLeft { get; private set; }
        public bool RotateRight { get; private set; }
        public bool ResetRotation { get ; private set; }

        private bool currUp;
        private bool prevUp;
        private bool currDown;
        private bool prevDown;
        private bool currEnter;
        private bool prevEnter;
        private bool prevEsc;
        private bool currEsc;

        KeyboardState keyboard;

        public void ReadInput()
        {
            Move = false;
            Attack = false;
            Jump = false;
            RotateLeft = false;
            RotateRight = false;
            ResetRotation = false;


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
                Attack = true;
            }
            if (keyboard.IsKeyDown(Keys.Space))
            {
                Jump = true;
            }

            if (keyboard.IsKeyDown(Keys.Up))
            {
                currUp = true;
            }
            else
            {
                currUp = false;
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                currDown = true;
            }
            else
            {
                currDown = false;
            }
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                currEnter = true;
            }
            else
            {
                currEnter = false;
            }

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                currEsc = true;
            }
            else
            {
                currEsc = false;
            }

            if (keyboard.IsKeyDown(Keys.J))
            {
                RotateRight = true;
            }
            if (keyboard.IsKeyDown(Keys.K))
            {
                RotateLeft = true;
            }
            if (keyboard.IsKeyDown(Keys.O))
            {
                ResetRotation = true;
            }


            if (currEnter && !prevEnter)
            {
                Enter = true;
            }
            else
            {
                Enter = false;
            }
            prevEnter = currEnter;

            if (currUp && !prevUp)
            {
                Up = true;
            }
            else
            {
                Up = false;
            }
            prevUp = currUp;


            if (currDown && !prevDown)
            {
                Down = true;
            }
            else
            {
                Down = false;
            }
            prevDown = currDown;

            if (currEsc && !prevEsc)
            {
                Esc = true;
            }
            else
            {
                Esc = false;
            }
            prevEsc = currEsc;
        }
    }
}
