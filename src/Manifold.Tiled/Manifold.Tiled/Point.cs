namespace Manifold.Tiled
{
    /// <summary>
    /// Used to mark an object as a point.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#point"/>
    /// for more information.
    /// </remarks>
    public struct Point
    {
        /// <summary>
        /// X coordinate.
        /// </summary>
        public uint x;

        /// <summary>
        /// Y coordinate.
        /// </summary>
        public uint y;
    }
}
