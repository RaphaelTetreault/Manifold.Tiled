using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// Defines a Wang tile, by referring to a tile in the tileset and associating it with a certain Wang ID.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#wangtile"/>
    /// for more information.
    /// </remarks>
    public class WangTile
    {
        /// <summary>
        /// The tile ID.
        /// </summary>
        public int TileID { get; set; }

        /// <summary>
        /// The Wang Tile global ID.
        /// </summary>
        /// <remarks>
        /// The Wang ID, given by a comma-separated list of indexes (starting from 1,
        /// because 0 means _unset_) referring to the Wang colors in the Wang set in
        /// the following order: top, top right, right, bottom right, bottom,
        /// bottom left, left, top left
        /// </remarks>
        public int WangGID { get; set; }


        public static WangTile FromXmlNode(XmlNode? wangTileNode)
        {
            string tag = "wangtile";
            if (wangTileNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (wangTileNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{wangTileNode.Name}' is not of type '{tag}'.");
            if (wangTileNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var wangTile = new WangTile();
            wangTile.TileID = wangTileNode.Attributes["tileid"].ErrorOrParseValue(int.Parse);
            wangTile.WangGID = wangTileNode.Attributes["wanggid"].ErrorOrParseValue(int.Parse);

            return wangTile;
        }

        public static WangTile[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static WangTile[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
