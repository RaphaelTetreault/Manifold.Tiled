namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#tmx-wangset"/>
    /// for more information.
    /// </remarks>
    public class Wangset
    {
        /// <summary>
        /// The name of the Wang set.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The tile ID of the tile representing this Wang set.
        /// </summary>
        public int Tile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Property? Property { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WangColor[]? Colors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WangTile[] TileTiles { get; set; } = new WangTile[0];
    }
}
