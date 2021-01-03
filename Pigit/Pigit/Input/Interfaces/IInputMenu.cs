namespace Pigit.Input.Interfaces
{
    interface IInputMenu
    {
        public bool Enter { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Esc { get; set; }
        void ReadInput();

    }
}
