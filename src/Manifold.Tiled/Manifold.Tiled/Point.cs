using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// Used to mark an object as a point.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#point"/>
    /// for more information.
    /// </remarks>
    public struct Point
    {
        /// <summary>
        /// X coordinate.
        /// </summary>
        public uint x;

        /// <summary>
        /// Y coordinate.
        /// </summary>
        public uint y;


        public static Point FromXmlNode(XmlNode? pointNode)
        {
            string tag = "point";
            if (pointNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (pointNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{pointNode.Name}' is not of type '{tag}'.");
            if (pointNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var point = new Point();
            point.x = pointNode.Attributes["x"].ErrorOrParseValue(uint.Parse);
            point.y = pointNode.Attributes["y"].ErrorOrParseValue(uint.Parse);

            return point;
        }

        public static Point[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledParser.FromXmlNodes(document, xpath, FromXmlNode);

        public static Point[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
