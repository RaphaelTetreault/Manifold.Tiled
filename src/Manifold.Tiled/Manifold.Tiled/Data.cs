﻿using System.Xml;

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
            data.Encoding = dataNode.Attributes["encoding"].DefaultOrParseValue((string str) => Enum.Parse<Encoding>(str, true), Encoding.None);
            data.Compression = dataNode.Attributes["compression"].DefaultOrParseValue((string str) => Enum.Parse<Compression>(str, true), Compression.None);
            data.Value = dataNode.Value is null ? "" : data.Value;
            // Children
            var hasXml = !string.IsNullOrEmpty(dataNode.InnerXml);
            if (hasXml)
            {
                data.Tiles = Tile.FromXml(dataNode.InnerXml, "tile");
                data.Chunks = Chunk.FromXml(dataNode.InnerXml, "chunk");
            }

            return data;
        }

        public static Data[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledXmlExtensions.FromXmlNodes(document, xpath, FromXmlNode);

        public static Data[] FromXml(string xml, string xpath)
            => TiledXmlExtensions.FromXml(xml, xpath, FromXmlNode);
    }
}
