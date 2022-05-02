namespace Manifold.Tiled
{
    /// <summary>
    /// Defines a Wang tile, by referring to a tile in the tileset and associating it with a certain Wang ID.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#wangtile"/>
    /// for more information.
    /// </remarks>
    public class WangTile
    {
        /// <summary>
        /// The tile ID.
        /// </summary>
        public int TileID { get; set; }

        /// <summary>
        /// The Wang Tile global ID.
        /// </summary>
        /// <remarks>
        /// The Wang ID, given by a comma-separated list of indexes (starting from 1,
        /// because 0 means _unset_) referring to the Wang colors in the Wang set in
        /// the following order: top, top right, right, bottom right, bottom,
        /// bottom left, left, top left
        /// </remarks>
        public int WangGID { get; set; }
    }
}
