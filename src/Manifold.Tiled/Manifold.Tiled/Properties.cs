using System.Xml;

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
        /// Whether or not there are properties.
        /// </summary>
        /// <remarks>
        /// The `Values` array should always be initialized with size 0.
        /// </remarks>
        public bool HasValues => Values != null && Values.Length > 0;


        public static Properties FromXmlNode(XmlNode? propertiesNode)
        {
            string tag = "properties";
            if (propertiesNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (propertiesNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{propertiesNode.Name}' is not of type '{tag}'.");
            if (propertiesNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var properties = new Properties();
            // Using innerXml results in error: XML cannot resolve root node, so you need to pass the
            // outer XML and parse it by providing the path through the root.
            properties.Values = Property.FromXml(propertiesNode.OuterXml, "properties/property");

            return properties;
        }

        public static Properties[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledParser.FromXmlNodes(document, xpath, FromXmlNode);

        public static Properties[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
