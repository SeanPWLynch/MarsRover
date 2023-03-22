namespace MarsRoverLibrary
{
    public interface IRover
    {
        Position Position { get; set; }
        void CheckEdgeAndMove(Platue platue);
        void Move(Platue platue, char[] movements);
    }
}