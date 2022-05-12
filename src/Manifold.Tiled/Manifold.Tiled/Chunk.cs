using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// A rectangle region of a map used when the map is set to 'infinite'.
    /// </summary>
    /// <remarks>
    /// This is currently added only for infinite maps. The contents of a chunk element is same as
    /// that of the data element, except it stores the data of the area specified in the attributes.
    /// 
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#chunk"/>
    /// for more information.
    /// </remarks>
    public class Chunk :
        IBounded
    {
        /// <summary>
        /// The x coordinate of the chunk in tiles.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The y coordinate of the chunk in tiles.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The width of the chunk in tiles.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height of the chunk in tiles.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Tiles from this chunk.
        /// </summary>
        public LayerTile[] Tiles { get; set; } = new LayerTile[0];

        /// <summary>
        /// Whether or not this chunk has tiles.
        /// </summary>
        public bool HasTiles => Tiles != null && Tiles.Length > 0;



        public static Chunk FromXmlNode(XmlNode? chunkNode)
        {
            string tag = "chunk";
            if (chunkNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (chunkNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{chunkNode.Name}' is not of type '{tag}'.");
            if (chunkNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var chunk = new Chunk();
            //
            chunk.X = chunkNode.Attributes["x"].ErrorOrParseValue(int.Parse);
            chunk.Y = chunkNode.Attributes["y"].ErrorOrParseValue(int.Parse);
            chunk.Width = chunkNode.Attributes["width"].ErrorOrParseValue(int.Parse);
            chunk.Height = chunkNode.Attributes["height"].ErrorOrParseValue(int.Parse);
            //
            var hasXml = !string.IsNullOrEmpty(chunkNode.InnerXml);
            if (hasXml)
            {
                chunk.Tiles = LayerTile.FromXml(chunkNode.InnerXml, "layertile");
            }
            return chunk;
        }

        public static Chunk[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledParser.FromXmlNodes(document, xpath, FromXmlNode);

        public static Chunk[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
