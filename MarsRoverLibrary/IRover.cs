namespace MarsRoverLibrary
{
    public interface IRover
    {
        Position Position { get; set; }
        void CheckEdgeAndMove(IPlatue platue);
        void Move(IPlatue platue, char[] movements);
    }
}