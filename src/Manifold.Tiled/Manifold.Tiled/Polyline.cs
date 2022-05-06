using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// Each polyline object is made up of a space-delimited list of x,y coordinates. The origin
    /// for these coordinates is the location of the parent object. By default, the first point
    /// is created as 0,0 denoting that the point will originate exactly where the object is placed.
    /// /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#polyline"/>
    /// for more information.
    /// </remarks>
    public class Polyline :
        IPointBased
    {
        /// <summary>
        /// A list of x,y coordinates in pixels.
        /// </summary>
        public Point[] Points { get; set; } = new Point[0];



        public static Polyline FromXmlNode(XmlNode? polylineNode)
        {
            string tag = "polyline";
            if (polylineNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (polylineNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{polylineNode.Name}' is not of type '{tag}'.");
            if (polylineNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var polyline = new Polyline();
            polyline.Points = Point.FromXml(polylineNode.InnerXml, "point");

            return polyline;
        }

        public static Polyline[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledXmlExtensions.FromXmlNodes(document, xpath, FromXmlNode);

        public static Polyline[] FromXml(string xml, string xpath)
            => TiledXmlExtensions.FromXml(xml, xpath, FromXmlNode);
    }
}
