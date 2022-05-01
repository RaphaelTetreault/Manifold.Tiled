namespace Manifold.Tiled
{
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
