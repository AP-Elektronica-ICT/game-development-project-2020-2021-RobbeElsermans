namespace Pigit.Input.Interfaces
{
    public interface IInputReader
    {
        public bool Move { get; }
        public bool Direction { get; }
        public bool Attack { get; }
        public bool Jump { get; }
        void ReadInput();
    }

}
