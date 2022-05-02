namespace Manifold.Tiled
{
    /// <summary>
    /// One frame of animation. Tiled calls this 'frame'.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#frame"/>
    /// for more information.
    /// </remarks>
    public struct AnimationFrame
    {
        /// <summary>
        /// The local ID of a tile within the parent tileset.
        /// </summary>
        public int TileID { get; set; }

        /// <summary>
        /// How long (in milliseconds) this frame should be displayed before advancing to the next frame.
        /// </summary>
        public int Duration { get; set; }
    }
}
