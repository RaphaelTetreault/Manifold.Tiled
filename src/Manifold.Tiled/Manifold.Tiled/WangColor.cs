namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// See <see href=""/>
    /// for more information.
    /// </remarks>
    public class WangColor
    {
        /// <summary>
        /// The name of this color.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The color in #RRGGBB format
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// The tile ID of the tile representing this color.
        /// </summary>
        public int Tile { get; set; }

        /// <summary>
        /// The relative probability that this color is chosen over others in case of multiple options.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public float Probability { get; set; } = 0;

        public Property? Property { get; set; } = null;
    }
}
