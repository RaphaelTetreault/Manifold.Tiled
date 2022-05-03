namespace Manifold.Tiled
{
    /// <summary>
    /// A color that can be used to define the corner and/or edge of a Wang tile.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#wangcolor"/>
    /// for more information.
    /// </remarks>
    public class WangColor
    {
        /// <summary>
        /// The name of this color.
        /// </summary>
        public string Name { get; set; } = String.Empty;

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



        /// <summary>
        /// Properties associated with this wang color.
        /// </summary>
        public Properties? Properties { get; set; } = null;

        /// <summary>
        /// Whether or not this tileset has properties.
        /// </summary>
        public bool HasProperties => Properties != null;
    }
}
