using System;
using System.Collections.Generic;
using System.Text;

namespace Pigit.Input.Interfaces
{
    interface IInputMenu
    {
        public bool Enter { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }

    }
}
