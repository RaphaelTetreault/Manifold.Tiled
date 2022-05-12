using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// Defines a list of colors and any number of Wang tiles using these colors.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#tmx-wangset"/>
    /// for more information.
    /// </remarks>
    public class WangSet : 
        INamed
    {
        /// <summary>
        /// The name of the Wang set.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The tile ID of the tile representing this Wang set.
        /// </summary>
        public int Tile { get; set; }


        /// <summary>
        /// Properties associated with this wang set.
        /// </summary>
        public Properties? Properties { get; set; } = null;

        /// <summary>
        /// Colors associated with this wang set.
        /// </summary>
        public WangColor[] WangColors { get; set; } = new WangColor[0];

        /// <summary>
        /// Wang tiles associated with this wang set.
        /// </summary>
        public WangTile[] WangTiles { get; set; } = new WangTile[0];

        /// <summary>
        /// Whether or not this wangset has properties.
        /// </summary>
        public bool HasProperties => Properties != null;

        /// <summary>
        /// Whether or not this wangset has wang colors.
        /// </summary>
        public bool HasColors => WangColors != null && WangColors.Length > 0;

        /// <summary>
        /// Whether or not this wangset has wang tiles.
        /// </summary>
        public bool HasWangTiles => WangTiles != null && WangTiles.Length > 0;


        public static WangSet FromXmlNode(XmlNode? wangSetNode)
        {
            string tag = "wangset";
            if (wangSetNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (wangSetNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{wangSetNode.Name}' is not of type '{tag}'.");
            if (wangSetNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var wangSet = new WangSet();
            //
            wangSet.Name = wangSetNode.Attributes["name"].ErrorOrValue();
            wangSet.Tile = wangSetNode.Attributes["tile"].ErrorOrParseValue(int.Parse);
            //
            var hasXml = !string.IsNullOrEmpty(wangSetNode.InnerXml);
            if (hasXml)
            {
                wangSet.Properties = Properties.FromXml(wangSetNode.InnerXml, "properties").GetOnlyValueOrNull();
                wangSet.WangColors = WangColor.FromXml(wangSetNode.InnerXml, "wangcolor");
                wangSet.WangTiles = WangTile.FromXml(wangSetNode.InnerXml, "wangtile");
            }

            return wangSet;
        }

        public static WangSet[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static WangSet[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);

    }
}
