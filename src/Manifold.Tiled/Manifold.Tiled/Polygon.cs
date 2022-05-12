using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// Each polygon object is made up of a space-delimited list of x,y coordinates. The origin
    /// for these coordinates is the location of the parent object. By default, the first point
    /// is created as 0,0 denoting that the point will originate exactly where the object is placed.
    /// /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#polygon"/>
    /// for more information.
    /// </remarks>
    public class Polygon :
        IPointBased
    {
        /// <summary>
        /// A list of x,y coordinates in pixels.
        /// </summary>
        public Point[] Points { get; set; } = new Point[0];



        public static Polygon FromXmlNode(XmlNode? polygonNode)
        {
            string tag = "polygon";
            if (polygonNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (polygonNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{polygonNode.Name}' is not of type '{tag}'.");
            if (polygonNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var polygon = new Polygon();
            polygon.Points = Point.FromXml(polygonNode.InnerXml, "point");

            return polygon;
        }

        public static Polygon[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledParser.FromXmlNodes(document, xpath, FromXmlNode);

        public static Polygon[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
