namespace Manifold.Tiled
{
    /// <summary>
    /// Represents an elipse defined by its bounds.
    /// </summary>
    public class Ellipse :
        IBounded
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
