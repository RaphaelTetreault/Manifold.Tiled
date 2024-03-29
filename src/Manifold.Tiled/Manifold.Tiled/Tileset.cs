﻿using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// A tileset can be either based on a single image, which is cut into tiles based on the given
    /// parameters, or a collection of images, in which case each tile defines its own image.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#tileset"/>
    /// for more information.
    /// </remarks>
    public class Tileset :
        INamed
    {
        /// <summary>
        /// The first global tile ID of this tileset.
        /// </summary>
        /// <remarks>
        /// This global ID maps to the first tile in this tileset.
        /// </remarks>
        public int FirstGID { get; set; }

        /// <summary>
        /// If this tileset is stored in an external TSX (Tile Set XML) file, this attribute refers to that file. 
        /// </summary>
        /// <remarks>
        /// That TSX file has the same structure as the <tileset> element described here. (There is the firstgid
        /// attribute missing and this source attribute is also not there. These two attributes are kept in the
        /// TMX map, since they are map specific.)
        /// </remarks>
        public string? Source { get; set; } = null;

        /// <summary>
        ///  The name of this tileset.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The (maximum) width of the tiles in this tileset. Irrelevant for image collection tilesets, but stores the maximum tile width.
        /// </summary>
        public int TileWidth { get; set; }

        /// <summary>
        /// The (maximum) height of the tiles in this tileset. Irrelevant for image collection tilesets, but stores the maximum tile height.
        /// </summary>
        public int TileHeight { get; set; }

        /// <summary>
        /// The spacing in pixels between the tiles in this tileset (applies to the tileset image, defaults to 0). Irrelevant for image collection tilesets.
        /// </summary>
        public int? Spacing { get; set; } = null;

        /// <summary>
        /// The margin around the tiles in this tileset (applies to the tileset image, defaults to 0). Irrelevant for image collection tilesets.
        /// </summary>
        public int? Margin { get; set; } = null;

        /// <summary>
        /// The number of tiles in this tileset (since 0.13). Note that there can be tiles with a higher ID than the tile count, in case the tileset is an image collection from which tiles have been removed.
        /// </summary>
        public int TileCount { get; set; }

        /// <summary>
        /// The number of tile columns in the tileset. For image collection tilesets it is editable and is used when displaying the tileset. (since 0.15)
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// Controls the alignment for tile objects.
        /// </summary>
        /// <remarks>
        /// The default value is unspecified, for compatibility reasons.
        /// When unspecified, tile objects use bottomleft in orthogonal mode and bottom in isometric mode.
        /// Available since Tiled 1.4.
        /// </remarks>
        public ObjectAlignment ObjectAlignment { get; set; } = ObjectAlignment.Unspecified;



        /// <summary>
        /// Image associated with this tileset.
        /// </summary>
        public Image? Image { get; set; } = null;

        /// <summary>
        /// Tile offset for this tileset.
        /// </summary>
        public TileOffset? TileOffset { get; set; } = null;

        /// <summary>
        /// Grid associated with this tileset.
        /// </summary>
        public Grid? Grid { get; set; } = null;

        /// <summary>
        /// Properties associated with this tileset.
        /// </summary>
        public Properties? Properties { get; set; } = null;

        /// <summary>
        /// Wangsets associated with this tileset.
        /// </summary>
        public WangSets? Wangsets { get; set; } = null;

        /// <summary>
        /// Tiles for this tileset.
        /// </summary>
        public Tile[] Tiles { get; set; } = new Tile[0];

        /// <summary>
        /// Whether or not this tileset has an image.
        /// </summary>
        public bool HasImage => Image != null;

        /// <summary>
        /// Whether or not this tileset has a tile offset.
        /// </summary>
        public bool HasTileOffset => TileOffset != null;

        /// <summary>
        /// Whether or not this tileset has a grid.
        /// </summary>
        public bool HasGrid => Grid != null;

        /// <summary>
        /// Whether or not this tileset has properties.
        /// </summary>
        public bool HasProperties => Properties != null;

        /// <summary>
        /// Whether or not this tileset has wangsets.
        /// </summary>
        public bool HasWangsets => Wangsets != null;

        /// <summary>
        /// Whether or not this tileset has tiles.
        /// </summary>
        public bool HasTiles => Tiles != null && Tiles.Length > 0;


        public int Rows => TileCount / Columns;


        public static Tileset FromXmlNode(XmlNode? tilesetNode)
        {
            string tag = "tileset";
            if (tilesetNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (tilesetNode.Name != tag)
                throw new XmlNodeParseException($"Node is not of type '{tag}'.");
            if (tilesetNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            //
            var tileset = new Tileset();
            // Values
            tileset.FirstGID = tilesetNode.Attributes["firstgid"].ErrorOrParseValue(int.Parse);
            tileset.Source = tilesetNode.Attributes["source"]?.Value;
            tileset.Name = tilesetNode.Attributes["name"].DefaultOrValue(string.Empty);
            tileset.TileWidth = tilesetNode.Attributes["tilewidth"].DefaultOrParseValue(int.Parse);
            tileset.TileHeight = tilesetNode.Attributes["tileheight"].DefaultOrParseValue(int.Parse);
            tileset.Spacing = tilesetNode.Attributes["spacing"].NullOrParseValue(int.Parse);
            tileset.Margin = tilesetNode.Attributes["margin"].NullOrParseValue(int.Parse);
            tileset.TileCount = tilesetNode.Attributes["tilecount"].DefaultOrParseValue(int.Parse);
            tileset.Columns = tilesetNode.Attributes["columns"].DefaultOrParseValue(int.Parse);
            tileset.ObjectAlignment = tilesetNode.Attributes["objectalignment"].DefaultOrParseValue(TiledEnumUtility.Parse<ObjectAlignment>);
            // Child nodes
            var hasXml = !string.IsNullOrEmpty(tilesetNode.InnerXml);
            if (hasXml)
            {
                tileset.Image = Image.FromXml(tilesetNode.InnerXml, "image").GetOnlyValueOrNull();
                tileset.TileOffset = Tiled.TileOffset.FromXml(tilesetNode.InnerXml, "tileoffset").GetOnlyValueOrNull();
                tileset.Grid = Grid.FromXml(tilesetNode.InnerXml, "grid").GetOnlyValueOrNull();
                tileset.Properties = Properties.FromXml(tilesetNode.InnerXml, "properties").GetOnlyValueOrNull();
                tileset.Wangsets = WangSets.FromXml(tilesetNode.InnerXml, "wangsets").GetOnlyValueOrNull();
                tileset.Tiles = Tile.FromXml(tilesetNode.InnerXml, "tile");
            }

            return tileset;
        }

        public static Tileset[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static Tileset[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);

    }
}
