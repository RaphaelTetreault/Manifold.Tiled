namespace Manifold.Tiled
{
    /// <summary>
    /// This element is used to specify an offset in pixels, to be applied when drawing
    /// a tile from the related tileset.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#tileoffset"/>
    /// for more information.
    /// </remarks>
    public struct TileOffset
    {
        /// <summary>
        /// Horizontal offset in pixels.
        /// </summary>
        public int x;

        /// <summary>
        /// Vertical offset in pixels.
        /// </summary>
        /// <remarks>
        /// Positive is down.
        /// Defaults to 0.
        /// </remarks>
        public int y;
    }
}
