namespace Pigit.Input.Interfaces
{
    public interface IInputReader
    {
        public bool Move { get; set; }
        public bool Direction { get; set; }
        public bool Attack { get; set; }
        public bool Jump { get; set; }
        void ReadInput();
    }

}
