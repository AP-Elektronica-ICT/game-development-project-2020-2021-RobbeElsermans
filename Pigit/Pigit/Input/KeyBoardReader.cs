using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pigit.Input.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Input
{
    public class KeyBoardReader : IInputReader, IInputMenu
    {
        public bool Move { get; set; } = false;
        public bool Direction { get; set; } = false;
        public bool Attack { get; set; } = false;
        public bool Jump { get; set ; }
        public bool Enter { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Esc { get; set; }

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

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                currUp = true;
            }
            else
            {
                currUp = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                currDown = true;
            }
            else
            {
                currDown = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                currEnter = true;
            }
            else
            {
                currEnter = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                currEsc = true;
            }
            else
            {
                currEsc = false;
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
