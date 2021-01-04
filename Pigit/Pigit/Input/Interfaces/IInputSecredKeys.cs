using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Input.Interfaces
{
    public interface IInputSecredKeys
    {
        public bool RotateLeft { get; }
        public bool RotateRight { get; }
        public bool ResetRotation { get; }
        void ReadInput();
    }
}
