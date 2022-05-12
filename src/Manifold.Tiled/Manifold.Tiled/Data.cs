using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// Tile layer data.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#data"/>
    /// for more information.
    /// </remarks>
    public class Data
    {
        /// <summary>
        /// The encoding used to encode the tile layer data.
        /// </summary>
        public Encoding Encoding { get; set; } = Encoding.None;

        /// <summary>
        /// The compression used to compress the tile layer data.
        /// </summary>
        public Compression Compression { get; set; } = Compression.None;

        /// <summary>
        /// The string value of the tile layer data.
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// The tiles stored in the tile layer data.
        /// </summary>
        /// <remarks>
        /// When no encoding or compression is given, the tiles are stored as individual XML tile elements.
        /// As such, this value is empty otherwise.
        /// </remarks>
        public Tile[] Tiles { get; set; } = new Tile[0];

        /// <summary>
        /// Rectangle regions of a map used when the map is set to 'infinite'.
        /// </summary>
        public Chunk[] Chunks { get; set; } = new Chunk[0];


        public int[] TileGIDs { get; set; } = new int[0];


        /// <summary>
        /// Whether this Data instance has inidividual XML tags for tiles or not.
        /// </summary>
        /// <remarks>
        /// When no encoding or compression is given, the tiles are stored as individual XML tile elements.
        /// </remarks>
        public bool ShouldHaveTiles =>
            Encoding == Encoding.None &&
            Compression == Compression.None;

        /// <summary>
        /// Whether this Data instance has tiles or not.
        /// </summary>
        public bool HasTiles => Tiles != null && Tiles.Length > 0;

        /// <summary>
        /// Whether this Data instance has chunks or not.
        /// </summary>
        public bool HasChunks => Chunks != null && Chunks.Length > 0;




        public static Data FromXmlNode(XmlNode? dataNode)
        {
            string tag = "data";
            if (dataNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (dataNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{dataNode.Name}' is not of type '{tag}'.");
            if (dataNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var data = new Data();
            // Values
            data.Encoding = dataNode.Attributes["encoding"].DefaultOrParseValue(TiledEnumUtility.Parse<Encoding>);
            data.Compression = dataNode.Attributes["compression"].DefaultOrParseValue(TiledEnumUtility.Parse<Compression>);
            data.Value = dataNode.Value is null ? "" : data.Value;
            // Children
            var hasXml = !string.IsNullOrEmpty(dataNode.OuterXml);
            if (hasXml)
            {
                // Use outer XML since inner is not valid XML
                data.Tiles = Tile.FromXml(dataNode.OuterXml, "data/tile");
                data.Chunks = Chunk.FromXml(dataNode.OuterXml, "data/chunk");
                // Get the inner string / data
                data.Value = dataNode.InnerText;
                // Parse the data into their global IDs
                data.TileGIDs = ParseIndexes(data.Encoding, data.Value);
            }

            return data;
        }

        public static Data[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static Data[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);


        public static int[] ParseIndexes(Encoding encoding, string data)
        {
            switch (encoding)
            {
                case Encoding.CSV: return ParseIndexesCSV(data);
                case Encoding.Base64: throw new NotImplementedException();
                case Encoding.None: throw new NotImplementedException();

                default:
                    throw new NotImplementedException();
            }
        }

        private static int[] ParseIndexesCSV(string data)
        {
            var cells = data.Split(',');
            var indexes = new int[cells.Length];
            for (int i = 0; i < indexes.Length; i++)
                indexes[i] = int.Parse(cells[i]);
            return indexes;
        }
    }
}
