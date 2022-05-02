namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// See <see href=""/>
    /// for more information.
    /// </remarks>
    public class WangTile
    {
        /// <summary>
        /// The tile ID.
        /// </summary>
        public int TileID { get; set; }

        /// <summary>
        /// 
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
