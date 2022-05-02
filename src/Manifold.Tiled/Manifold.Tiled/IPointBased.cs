namespace Manifold.Tiled
{
    /// <summary>
    /// Defines an element that is composed with multiple points.
    /// </summary>
    public interface IPointBased
    {
        /// <summary>
        /// A list of x,y coordinates in pixels.
        /// </summary>
        Point[] Points { get; set; }
    }
}
