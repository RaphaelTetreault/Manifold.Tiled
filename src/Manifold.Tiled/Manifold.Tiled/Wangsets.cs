namespace Manifold.Tiled
{
    /// <summary>
    /// Contains the list of Wang sets defined for this tileset.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#wangsets"/>
    /// for more information.
    /// </remarks>
    public class WangSets
    {
        /// <summary>
        /// The Wangset values.
        /// </summary>
        public WangSet[] Values { get; set; } = new WangSet[0];

        /// <summary>
        /// Whether or not there are wang set values.
        /// </summary>
        public bool HasValues => Values != null && Values.Length > 0;
    }
}
