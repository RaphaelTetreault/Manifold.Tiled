namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#map"/>
    /// for more inormation.
    /// </remarks>
    public class Map : 
        IGrid
    {
        /// <summary>
        /// The TMX format version. Was “1.0” so far, and will be incremented to match minor Tiled releases.
        /// </summary>
        public string Version { get; set; } = string.Empty;

        /// <summary>
        /// The Tiled version used to save the file.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// Available since Tiled 1.0.1.
        /// May be a date (for snapshot builds).
        /// </remarks>
        public string? TiledVersion { get; set; } = null;

        /// <summary>
        /// Map orientation. Tiled supports “orthogonal”, “isometric”, “staggered” and “hexagonal”.
        /// </summary>
        /// <remarks>
        /// Available since Tiled 0.11)
        /// </remarks>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// The order in which tiles on tile layers are rendered.
        /// </summary>
        public RenderOrder RenderOrder { get; set; } = RenderOrder.Right_Down;

        /// <summary>
        /// The compression level to use for tile layer data.
        /// </summary>
        /// <remarks>
        /// Defaults to -1, which means to use the algorithm default.
        /// </remarks>
        public int CompressionLevel { get; set; } = -1;

        /// <summary>
        /// The map width in tiles.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The map height in tiles.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The width of a tile.
        /// </summary>
        public int TileWidth { get; set; }

        /// <summary>
        /// The height of a tile.
        /// </summary>
        public int TileHeight { get; set; }

        /// <summary>
        /// Determines the width or height (depending on the staggered axis) of the tile’s edge, in pixels.
        /// </summary>
        /// <remarks>
        /// Only for hexagonal maps. Is null otherwise.
        /// </remarks>
        public int? HexSideLength { get; set; } = null;

        /// <summary>
        /// For staggered and hexagonal maps, determines which axis is staggered.
        /// </summary>
        public StaggerAxis StaggerAxis { get; set; }

        /// <summary>
        /// For staggered and hexagonal maps, determines whether the “even” or “odd” indexes along the staggered axis are shifted. (since 0.11)
        /// </summary>
        public StaggerIndex StaggerIndex { get; set; }

        /// <summary>
        /// X coordinate of the parallax origin in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// Available since Tiled 1.8.
        /// </remarks>
        public int ParallaxOriginX { get; set; } = 0;

        /// <summary>
        /// Y coordinate of the parallax origin in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// Available since Tiled 1.8.
        /// </remarks>
        public int ParallaxOriginY { get; set; } = 0;

        /// <summary>
        /// The background color of the map.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// May include alpha value since 0.15.
        /// Defaults to fully transparent black.
        /// </remarks>
        public Color TiledColor { get; set; } = new Color(0, 0, 0, 255);

        /// <summary>
        /// Stores the next available ID for new layers.
        /// This number is stored to prevent reuse of the same ID after layers have been removed.
        /// (since 1.2) (defaults to the highest layer id in the file + 1)
        /// </summary>
        /// <remarks>
        /// Available since Tiled 1.2.
        /// Defaults to the highest layer id in the file + 1.
        /// </remarks>
        public int NextLayerID { get; set; }

        /// <summary>
        /// Stores the next available ID for new objects.
        /// This number is stored to prevent reuse of the same ID after objects have been removed.
        /// </summary>
        /// <remarks>
        /// Available since Tiled 0.11.
        /// Defaults to the highest object id in the file + 1.
        /// </remarks>
        public int NextObjectID { get; set; }

        /// <summary>
        /// Whether this map is infinite. An infinite map has no fixed size and can grow in all directions. Its layer data is stored in chunks.
        /// </summary>
        /// <remarks>
        /// 0 for false, 1 for true. Defaults to 0.
        /// </remarks>
        public byte Infinite { get; set; }


        // HELPER PROPERTIES
        public bool IsInfinite
        {
            get => Infinite > 0;
            set => Infinite = (byte)(value ? 1 : 0);
        }
    }
}