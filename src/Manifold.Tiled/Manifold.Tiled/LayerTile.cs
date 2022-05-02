namespace Manifold.Tiled
{
    /// <summary>
    /// Defines the value of a single tile on a tile layer. 
    /// </summary>
    /// <remarks>
    /// Not to be confused with the `tile` element inside a `tileset`.
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#tmx-tilelayer-tile"/>
    /// for more information.
    /// </remarks>
    public struct LayerTile
    {
        /// <summary>
        /// The global tile ID;
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int gid;
    }
}
