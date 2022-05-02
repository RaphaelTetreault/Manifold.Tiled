namespace Manifold.Tiled
{
    /// <summary>
    /// Represents an element with a start coordinate (x,y) and a width and height.
    /// </summary>
    public interface IBounded
    {
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
    }
}
