using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// This element is used to specify an offset in pixels, to be applied when drawing
    /// a tile from the related tileset.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#tileoffset"/>
    /// for more information.
    /// </remarks>
    public struct TileOffset
    {
        /// <summary>
        /// Horizontal offset in pixels.
        /// </summary>
        public int x;

        /// <summary>
        /// Vertical offset in pixels.
        /// </summary>
        /// <remarks>
        /// Positive is down.
        /// Defaults to 0.
        /// </remarks>
        public int y;


        public static TileOffset FromXmlNode(XmlNode? tileOffsetNode)
        {
            string tag = "tileoffset";
            if (tileOffsetNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (tileOffsetNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{tileOffsetNode.Name}' is not of type '{tag}'.");
            if (tileOffsetNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var tileOffset = new TileOffset();
            tileOffset.x = tileOffsetNode.Attributes["x"].ErrorOrParseValue(int.Parse);
            tileOffset.y = tileOffsetNode.Attributes["y"].ErrorOrParseValue(int.Parse);

            return tileOffset;
        }

        public static TileOffset[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static TileOffset[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
