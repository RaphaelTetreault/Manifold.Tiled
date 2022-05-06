using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// Defines the value of a single tile on a tile layer. 
    /// </summary>
    /// <remarks>
    /// Not to be confused with the `tile` element inside a `tileset`.
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#tmx-tilelayer-tile"/>
    /// for more information.
    /// </remarks>
    public struct LayerTile
    {
        /// <summary>
        /// The global tile ID;
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int gid;

        public static LayerTile FromXmlNode(XmlNode? wangTileNode)
        {
            string tag = "layertile";
            if (wangTileNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (wangTileNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{wangTileNode.Name}' is not of type '{tag}'.");
            if (wangTileNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var wangTile = new LayerTile();
            wangTile.gid = wangTileNode.Attributes["gid"].ErrorOrParseValue(int.Parse);

            return wangTile;
        }

        public static LayerTile[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledXmlExtensions.FromXmlNodes(document, xpath, FromXmlNode);

        public static LayerTile[] FromXml(string xml, string xpath)
            => TiledXmlExtensions.FromXml(xml, xpath, FromXmlNode);
    }
}
