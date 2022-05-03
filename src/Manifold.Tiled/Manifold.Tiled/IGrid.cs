namespace Manifold.Tiled
{
    /// <summary>
    /// Defines an element with a width, height, and orientation.
    /// </summary>
    public interface IGrid
    {
        /// <summary>
        /// Defines the grid's orientation.
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// Width of the grid.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of the grid.
        /// </summary>
        public int Height { get; set; }
    }
}
