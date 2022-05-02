namespace Manifold.Tiled
{
    /// <summary>
    /// A tileset can be either based on a single image, which is cut into tiles based on the given
    /// parameters, or a collection of images, in which case each tile defines its own image.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#tileset"/>
    /// for more information.
    /// </remarks>
    public class Tileset
    {
        /// <summary>
        /// The first global tile ID of this tileset.
        /// </summary>
        /// <remarks>
        /// This global ID maps to the first tile in this tileset.
        /// </remarks>
        public int FirstGid { get; set; }

        /// <summary>
        /// If this tileset is stored in an external TSX (Tile Set XML) file, this attribute refers to that file. 
        /// </summary>
        /// <remarks>
        /// That TSX file has the same structure as the <tileset> element described here. (There is the firstgid
        /// attribute missing and this source attribute is also not there. These two attributes are kept in the
        /// TMX map, since they are map specific.)
        /// </remarks>
        public string Source { get; set; } = string.Empty;

        /// <summary>
        ///  The name of this tileset.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The (maximum) width of the tiles in this tileset. Irrelevant for image collection tilesets, but stores the maximum tile width.
        /// </summary>
        public int TileWidth { get; set; }

        /// <summary>
        /// The (maximum) height of the tiles in this tileset. Irrelevant for image collection tilesets, but stores the maximum tile height.
        /// </summary>
        public int TileHeight { get; set; }

        /// <summary>
        /// The spacing in pixels between the tiles in this tileset (applies to the tileset image, defaults to 0). Irrelevant for image collection tilesets.
        /// </summary>
        public int Spacing { get; set; }

        /// <summary>
        /// The margin around the tiles in this tileset (applies to the tileset image, defaults to 0). Irrelevant for image collection tilesets.
        /// </summary>
        public int Margin { get; set; }

        /// <summary>
        /// The number of tiles in this tileset (since 0.13). Note that there can be tiles with a higher ID than the tile count, in case the tileset is an image collection from which tiles have been removed.
        /// </summary>
        public int TileCount { get; set; }

        /// <summary>
        /// The number of tile columns in the tileset. For image collection tilesets it is editable and is used when displaying the tileset. (since 0.15)
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// Controls the alignment for tile objects.
        /// </summary>
        /// <remarks>
        /// The default value is unspecified, for compatibility reasons.
        /// When unspecified, tile objects use bottomleft in orthogonal mode and bottom in isometric mode.
        /// Available since Tiled 1.4.
        /// </remarks>
        public ObjectAlignment Alignment { get; set; } = ObjectAlignment.Unspecified;




        public Image? Image { get; set; } = null;
        public TileOffset? TileOffset { get; set; } = null;
        public Grid? Grid { get; set; } = null;
        public Properties? Properties { get; set; } = null;
        public Wangsets? Wangsets { get; set; } = null;
        public Tile[]? Tiles { get; set; } = null;


        public bool HasImage => Image != null;
        public bool HasTileOffset => TileOffset != null;
        public bool HasGrid => Grid != null;
        public bool HasProperties => Properties != null;
        public bool HasWangsets => Wangsets != null;
        public bool HasTiles => Tiles != null && Tiles.Length > 0;
    }
}
