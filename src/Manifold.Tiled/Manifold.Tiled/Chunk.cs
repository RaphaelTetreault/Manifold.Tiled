namespace Manifold.Tiled
{
    /// <summary>
    /// A rectangle region of a map used when the map is set to 'infinite'.
    /// </summary>
    /// <remarks>
    /// This is currently added only for infinite maps. The contents of a chunk element is same as
    /// that of the data element, except it stores the data of the area specified in the attributes.
    /// 
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#chunk"/>
    /// for more information.
    /// </remarks>
    public class Chunk :
        IBounded
    {
        /// <summary>
        /// The x coordinate of the chunk in tiles.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The y coordinate of the chunk in tiles.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The width of the chunk in tiles.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height of the chunk in tiles.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Tiles from this chunk.
        /// </summary>
        public LayerTile[] Tiles { get; set; } = new LayerTile[0];

        /// <summary>
        /// Whether or not this chunk has tiles.
        /// </summary>
        public bool HasTiles => Tiles != null && Tiles.Length > 0;
    }
}
