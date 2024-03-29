﻿using System.Xml;

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

        public static LayerTile[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static LayerTile[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);

        public static LayerTile[] FromCSV(string csvChunk)
        {
            // Split CSV into lines separated by carriage return and newline
            // First and last lines are empty. Select range from +1 to -1 from end
            var csvRows = csvChunk.Split("\r\n")[1..^1];
            // Chunks are square, so get col width by getting number of valid rows
            int columnWidth = csvRows.Length;

            int numTiles = csvRows.Length * columnWidth;
            var tiles = new LayerTile[numTiles];

            for (int row = 0; row < csvRows.Length; row++)
            {
                int baseX = row * columnWidth;
                var rowDigits = csvRows[row].Split(',');
                for (int col = 0; col < columnWidth; col++)
                {
                    string digit = rowDigits[col];
                    int gid = int.Parse(digit);

                    int tileIndex = baseX + col;
                    tiles[tileIndex] = new LayerTile();
                    tiles[tileIndex].gid = gid;
                }
            }

            return tiles;
        }
    }
}
