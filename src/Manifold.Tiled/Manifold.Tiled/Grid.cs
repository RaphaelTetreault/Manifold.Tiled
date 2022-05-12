using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// This element is only used in case of isometric orientation, and determines
    /// how tile overlays for terrain and collision information are rendered.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#grid"/>
    /// for more information.
    /// </remarks>
    public class Grid :
        IGrid
    {
        /// <summary>
        /// Orientation of the grid for the tiles in this tileset.
        /// </summary>
        /// <remarks>
        /// Defaults to orthogonal.
        /// </remarks>
        public Orientation Orientation { get; set; } = Orientation.Orthogonal;

        /// <summary>
        /// Width of a grid cell.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of a grid cell.
        /// </summary>
        public int Height { get; set; }



        public static Grid FromXmlNode(XmlNode? gridNode)
        {
            string tag = "grid";
            if (gridNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (gridNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{gridNode.Name}' is not of type '{tag}'.");
            if (gridNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var grid = new Grid();
            grid.Orientation = gridNode.Attributes["orientation"].ErrorOrParseValue(TiledEnumUtility.Parse<Orientation>);
            grid.Width = gridNode.Attributes["width"].ErrorOrParseValue(int.Parse);
            grid.Height = gridNode.Attributes["height"].ErrorOrParseValue(int.Parse);

            return grid;
        }

        public static Grid[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledXmlExtensions.FromXmlNodes(document, xpath, FromXmlNode);

        public static Grid[] FromXml(string xml, string xpath)
            => TiledXmlExtensions.FromXml(xml, xpath, FromXmlNode);
    }
}
