using System.Xml;

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
        /// <remarks>
        /// The `Values` array should always be initialized with size 0.
        /// </remarks>
        public bool HasValues => Values != null && Values.Length > 0;


        public static WangSets FromXmlNode(XmlNode? wangsetsNode)
        {
            string tag = "wangsets";
            if (wangsetsNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (wangsetsNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{wangsetsNode.Name}' is not of type '{tag}'.");
            if (wangsetsNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var wangsets = new WangSets();
            wangsets.Values = WangSet.FromXml(wangsetsNode.InnerXml, "wangsets");

            return wangsets;
        }

        public static WangSets[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledParser.FromXmlNodes(document, xpath, FromXmlNode);

        public static WangSets[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
