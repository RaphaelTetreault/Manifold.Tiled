namespace Manifold.Tiled
{
    /// <summary>
    /// Defines a list of colors and any number of Wang tiles using these colors.
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
        public Properties? Properties { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        public WangColor[] Colors { get; set; } = new WangColor[0];

        /// <summary>
        /// 
        /// </summary>
        public WangTile[] WangTiles { get; set; } = new WangTile[0];

        /// <summary>
        /// 
        /// </summary>
        public bool HasProperties => Properties != null;

        /// <summary>
        /// 
        /// </summary>
        public bool HasColors => Colors != null && Colors.Length > 0;

        /// <summary>
        /// 
        /// </summary>
        public bool HasWangTiles => WangTiles != null && WangTiles.Length > 0;

    }
}
