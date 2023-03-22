namespace MarsRoverLibrary
{
    public interface IPosition
    {
        Direction Direction { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}