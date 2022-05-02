namespace Manifold.Tiled
{
    /// <summary>
    /// This element is only used in case of isometric orientation, and determines
    /// how tile overlays for terrain and collision information are rendered.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#grid"/>
    /// for more information.
    /// </remarks>
    public class Grid :
        IGrid
    {
        /// <summary>
        /// Orientation of the grid for the tiles in this tileset.
        /// </summary>
        /// <remarks>
        /// Defaults to orthogonal.
        /// </remarks>
        public Orientation Orientation { get; set; } = Orientation.Orthogonal;

        /// <summary>
        /// Width of a grid cell.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of a grid cell.
        /// </summary>
        public int Height { get; set; }
    }
}
