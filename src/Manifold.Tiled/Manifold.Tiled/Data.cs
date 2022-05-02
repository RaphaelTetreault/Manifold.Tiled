namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// When no encoding or compression is given, the tiles are stored as individual XML tile elements.
    /// See <see href=""/>
    /// for more information.
    /// </remarks>
    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public Encoding Encoding { get; set; } = Encoding.None;

        /// <summary>
        /// 
        /// </summary>
        public Compression Compression { get; set; } = Compression.None;

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public Tile[]? Tiles { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        public Chunk[]? Chunks { get; set; } = null;
    }
}
