namespace Manifold.Tiled
{
    /// <summary>
    /// Represents an element with a start coordinate (x,y) and a width and height.
    /// </summary>
    public interface IBounded
    {
        /// <summary>
        /// X coordinate of the bounds.
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Y coordinate of the bounds.
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// Width of the bounds.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Height of the bounds.
        /// </summary>
        int Height { get; set; }
    }
}
