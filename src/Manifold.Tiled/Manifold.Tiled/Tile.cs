namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// See <see href=""/>
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



        public Properties? Properties { get; set; } = null;
        public Image? Image { get; set; } = null;
        public ObjectGroup? ObjectGroup { get; set; } = null;
        public Animation? Animation { get; set; } = null;

        public bool HasProperties => Properties != null;
        public bool HasImage => Image != null;
        public bool HasObjectGroup => ObjectGroup != null;
        public bool HasAnimation => Animation != null;
    }
}
