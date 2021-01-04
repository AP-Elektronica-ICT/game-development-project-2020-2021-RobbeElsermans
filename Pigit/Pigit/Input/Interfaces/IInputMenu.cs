namespace Pigit.Input.Interfaces
{
    public interface IInputMenu
    {
        public bool Enter { get; }
        public bool Up { get; }
        public bool Down { get; }
        public bool Esc { get; }
        void ReadInput();

    }
}
