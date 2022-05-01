namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// The local tile ID within its tileset.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The type of the tile. Refers to an object type and is used by tile objects.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        public TileType? Type { get; set; } = null;

        /// <summary>
        /// A percentage indicating the probability that this tile is chosen when it
        /// competes with others while editing with the terrain tool.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public float Probability { get; set; } = 0;
    }
}
