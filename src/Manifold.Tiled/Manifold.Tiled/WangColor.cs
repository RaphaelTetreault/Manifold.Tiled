using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// A color that can be used to define the corner and/or edge of a Wang tile.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#wangcolor"/>
    /// for more information.
    /// </remarks>
    public class WangColor : 
        INamed
    {
        /// <summary>
        /// The name of this color.
        /// </summary>
        public string Name { get; set; } = string.Empty;

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



        public static WangColor FromXmlNode(XmlNode? wangColorNode)
        {
            string tag = "wangcolor";
            if (wangColorNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (wangColorNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{wangColorNode.Name}' is not of type '{tag}'.");
            if (wangColorNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var wangColor = new WangColor();
            //
            wangColor.Name = wangColorNode.Attributes["name"].ErrorOrValue();
            wangColor.Color = wangColorNode.Attributes["color"].ErrorOrParseValue(Color.FromHexARGB);
            wangColor.Tile = wangColorNode.Attributes["tile"].ErrorOrParseValue(int.Parse);
            wangColor.Probability = wangColorNode.Attributes["probability"].ErrorOrParseValue(float.Parse);
            //
            var hasXml = !string.IsNullOrEmpty(wangColorNode.InnerXml);
            if (hasXml)
            {
                wangColor.Properties = Properties.FromXml(wangColorNode.InnerXml, "properties").GetOnlyValueOrNull();
            }

            return wangColor;
        }

        public static WangColor[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledXmlExtensions.FromXmlNodes(document, xpath, FromXmlNode);

        public static WangColor[] FromXml(string xml, string xpath)
            => TiledXmlExtensions.FromXml(xml, xpath, FromXmlNode);
    }
}
