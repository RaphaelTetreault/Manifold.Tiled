namespace Manifold.Tiled
{
    /// <summary>
    /// Represents an elipse defined by its bounds.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#ellipse"/>
    /// for more information.
    /// </remarks>
    public class Ellipse :
        IBounded
    {
        /// <summary>
        ///  The x coordinate of the ellipse in pixels.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///  The y coordinate of the ellipse in pixels.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The width of the ellipse in pixels.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height of the ellipse in pixels.
        /// </summary>
        public int Height { get; set; }
    }
}
