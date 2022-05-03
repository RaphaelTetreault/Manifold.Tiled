namespace Manifold.Tiled
{
    /// <summary>
    /// Defines a list of colors and any number of Wang tiles using these colors.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#tmx-wangset"/>
    /// for more information.
    /// </remarks>
    public class WangSet : 
        INamed
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
        /// Properties associated with this wang set.
        /// </summary>
        public Properties? Properties { get; set; } = null;

        /// <summary>
        /// Colors associated with this wang set.
        /// </summary>
        public WangColor[] Colors { get; set; } = new WangColor[0];

        /// <summary>
        /// Wang tiles associated with this wang set.
        /// </summary>
        public WangTile[] WangTiles { get; set; } = new WangTile[0];

        /// <summary>
        /// Whether or not this wangset has properties.
        /// </summary>
        public bool HasProperties => Properties != null;

        /// <summary>
        /// Whether or not this wangset has wang colors.
        /// </summary>
        public bool HasColors => Colors != null && Colors.Length > 0;

        /// <summary>
        /// Whether or not this wangset has wang tiles.
        /// </summary>
        public bool HasWangTiles => WangTiles != null && WangTiles.Length > 0;

    }
}
