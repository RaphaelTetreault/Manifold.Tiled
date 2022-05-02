namespace Manifold.Tiled
{
    /// <summary>
    /// Tile layer data.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#data"/>
    /// for more information.
    /// </remarks>
    public class Data
    {
        /// <summary>
        /// The encoding used to encode the tile layer data.
        /// </summary>
        public Encoding Encoding { get; set; } = Encoding.None;

        /// <summary>
        /// The compression used to compress the tile layer data.
        /// </summary>
        public Compression Compression { get; set; } = Compression.None;

        /// <summary>
        /// The string value of the tile layer data.
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// The tiles stored in the tile layer data.
        /// </summary>
        /// <remarks>
        /// When no encoding or compression is given, the tiles are stored as individual XML tile elements.
        /// As such, this value is null otherwise.
        /// </remarks>
        public Tile[]? Tiles { get; set; } = null;

        /// <summary>
        /// Rectangle regions of a map used when the map is set to 'infinite'.
        /// </summary>
        public Chunk[]? Chunks { get; set; } = null;


        /// <summary>
        /// Whether this Data instance has Tiles or not.
        /// </summary>
        public bool HasTiles =>
            Encoding == Encoding.None &&
            Compression == Compression.None;
    }
}
