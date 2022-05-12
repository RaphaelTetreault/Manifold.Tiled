using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// Represents an elipse defined by its bounds.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#ellipse"/>
    /// for more information.
    /// </remarks>
    public class Ellipse :
        IBounded
    {
        /// <summary>
        ///  The x coordinate of the ellipse in pixels.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///  The y coordinate of the ellipse in pixels.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The width of the ellipse in pixels.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height of the ellipse in pixels.
        /// </summary>
        public int Height { get; set; }


        public static Ellipse FromXmlNode(XmlNode? ellipseNode)
        {
            string tag = "ellipse";
            if (ellipseNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (ellipseNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{ellipseNode.Name}' is not of type '{tag}'.");
            if (ellipseNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var ellipse = new Ellipse();
            ellipse.X = ellipseNode.Attributes["x"].ErrorOrParseValue(int.Parse);
            ellipse.Y = ellipseNode.Attributes["y"].ErrorOrParseValue(int.Parse);
            ellipse.Width = ellipseNode.Attributes["width"].ErrorOrParseValue(int.Parse);
            ellipse.Height = ellipseNode.Attributes["height"].ErrorOrParseValue(int.Parse);

            return ellipse;
        }

        public static Ellipse[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledParser.FromXmlNodes(document, xpath, FromXmlNode);

        public static Ellipse[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
