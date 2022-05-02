namespace Manifold.Tiled
{
    /// <summary>
    /// Contains the list of Wang sets defined for this tileset.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#wangsets"/>
    /// for more information.
    /// </remarks>
    public class Wangsets
    {
        /// <summary>
        /// The Wangset values.
        /// </summary>
        public Wangset[] Values { get; set; } = new Wangset[0];
    }
}
