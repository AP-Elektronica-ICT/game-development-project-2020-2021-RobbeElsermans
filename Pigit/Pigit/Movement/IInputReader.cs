using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit
{
    public interface IInputReader
    {
        public bool Move { get; set; }
        public bool Direction { get; set; }
        public bool Attack { get; set; }
        public bool jump { get; set; }
        public bool hasjumped { get; set; }
        Vector2 ReadInput();
    }

}
