namespace Manifold.Tiled
{
    /// <summary>
    /// A tile as part of tileset or map's data.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#tile"/>
    /// for more information.
    /// </remarks>
    public class Tile
    {
        /// <summary>
        /// The local tile ID within its tileset.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The type of the tile. Refers to an object type and is used by tile objects.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// A percentage indicating the probability that this tile is chosen when it
        /// competes with others while editing with the terrain tool.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public float Probability { get; set; } = 0;


        /// <summary>
        /// Properties associated with this tile.
        /// </summary>
        public Properties? Properties { get; set; } = null;

        /// <summary>
        /// Image associated with this tile.
        /// </summary>
        public Image? Image { get; set; } = null;

        /// <summary>
        /// Object group associated with this tile.
        /// </summary>
        public ObjectGroup? ObjectGroup { get; set; } = null;

        /// <summary>
        /// Animation associated with this tile.
        /// </summary>
        public Animation? Animation { get; set; } = null;

        /// <summary>
        /// Whether or not this tile has properties.
        /// </summary>
        public bool HasProperties => Properties != null;

        /// <summary>
        /// Whether or not this tile has an image.
        /// </summary>
        public bool HasImage => Image != null;

        /// <summary>
        /// Whether or not this tile has an object group.
        /// </summary>
        public bool HasObjectGroup => ObjectGroup != null;

        /// <summary>
        /// Whether or not this tile has an animation.
        /// </summary>
        public bool HasAnimation => Animation != null;
    }
}
