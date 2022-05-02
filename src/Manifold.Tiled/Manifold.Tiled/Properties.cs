namespace Manifold.Tiled
{
    /// <summary>
    /// Wraps any number of custom properties. Can be used as a child of the map, tileset, tile
    /// (when part of a tileset), terrain, wangset, wangcolor, layer, objectgroup, object, imagelayer,
    /// group and property elements.
    /// </summary>
    /// <remarks>
    /// Can contain any number of properties.
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#properties"/>
    /// for more information.
    /// </remarks>
    public class Properties
    {
        /// <summary>
        /// The property values.
        /// </summary>
        public Property[] Values { get; set; } = new Property[0];

        /// <summary>
        /// Whether or not this object group has properties.
        /// </summary>
        public bool HasValues => Values != null && Values.Length > 0;


        public static Properties FromXML(string xml)
        {
            throw new NotImplementedException();
        }
    }
}
