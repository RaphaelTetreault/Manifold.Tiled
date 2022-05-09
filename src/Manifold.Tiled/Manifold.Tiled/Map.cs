﻿using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// A Tiled map.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#map"/>
    /// for more inormation.
    /// </remarks>
    public class Map :
        IGrid
    {
        /// <summary>
        /// The TMX format version. Was “1.0” so far, and will be incremented to match minor Tiled releases.
        /// </summary>
        public string Version { get; set; } = string.Empty;

        /// <summary>
        /// The Tiled version used to save the file.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// May be a date (for snapshot builds).
        /// </remarks>
        public string? TiledVersion { get; set; } = null;

        /// <summary>
        /// Map orientation. Tiled supports “orthogonal”, “isometric”, “staggered” and “hexagonal”.
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// The order in which tiles on tile layers are rendered.
        /// </summary>
        public RenderOrder RenderOrder { get; set; } = RenderOrder.Right_Down;

        /// <summary>
        /// The compression level to use for tile layer data.
        /// </summary>
        /// <remarks>
        /// Defaults to -1, which means to use the algorithm default.
        /// </remarks>
        public int? CompressionLevel { get; set; } = -1;

        /// <summary>
        /// The map width in tiles.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The map height in tiles.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The width of a tile.
        /// </summary>
        public int TileWidth { get; set; }

        /// <summary>
        /// The height of a tile.
        /// </summary>
        public int TileHeight { get; set; }

        /// <summary>
        /// Determines the width or height (depending on the staggered axis) of the tile’s edge, in pixels.
        /// </summary>
        /// <remarks>
        /// Only for hexagonal maps. Is null otherwise.
        /// </remarks>
        public int? HexSideLength { get; set; } = null;

        /// <summary>
        /// For staggered and hexagonal maps, determines which axis is staggered.
        /// </summary>
        public StaggerAxis? StaggerAxis { get; set; }

        /// <summary>
        /// For staggered and hexagonal maps, determines whether the “even” or “odd” indexes along the staggered axis are shifted. (since 0.11)
        /// </summary>
        public StaggerIndex? StaggerIndex { get; set; }

        /// <summary>
        /// X coordinate of the parallax origin in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int? ParallaxOriginX { get; set; } = 0;

        /// <summary>
        /// Y coordinate of the parallax origin in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int? ParallaxOriginY { get; set; } = 0;

        /// <summary>
        /// The background color of the map.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// Defaults to fully transparent black.
        /// </remarks>
        public Color? BackgroundColor { get; set; } = new Color(0, 0, 0, 255);

        /// <summary>
        /// Stores the next available ID for new layers.
        /// This number is stored to prevent reuse of the same ID after layers have been removed.
        /// (since 1.2) (defaults to the highest layer id in the file + 1)
        /// </summary>
        /// <remarks>
        /// Defaults to the highest layer id in the file + 1.
        /// </remarks>
        public int NextLayerID { get; set; }

        /// <summary>
        /// Stores the next available ID for new objects.
        /// This number is stored to prevent reuse of the same ID after objects have been removed.
        /// </summary>
        /// <remarks>
        /// Defaults to the highest object id in the file + 1.
        /// </remarks>
        public int NextObjectID { get; set; }

        /// <summary>
        /// Whether this map is infinite. An infinite map has no fixed size and can grow in all directions. Its layer data is stored in chunks.
        /// </summary>
        /// <remarks>
        /// 0 for false, 1 for true. Defaults to 0.
        /// </remarks>
        public IntBool Infinite { get; set; }


        // TODO: implement
        // EditorSettings;
        //      > ChunkSize
        //      > Export

        /// <summary>
        /// Properties associated with this map.
        /// </summary>
        public Properties? Properties { get; set; } = null;

        /// <summary>
        /// Tilesets associated with this map.
        /// </summary>
        public TiledCollection<Tileset> Tilesets { get; set; } = new TiledCollection<Tileset>();

        /// <summary>
        /// All map layers.
        /// </summary>
        public TiledCollection<Layer> Layers { get; set; } = new TiledCollection<Layer>();

        /// <summary>
        /// All map object groups
        /// </summary>
        public TiledCollection<ObjectGroup> ObjectGroups { get; set; } = new TiledCollection<ObjectGroup>();
        
        /// <summary>
        /// All map image layers.
        /// </summary>
        public TiledCollection<ImageLayer> ImageLayers { get; set; } = new TiledCollection<ImageLayer>();
        
        /// <summary>
        /// All map groups.
        /// </summary>
        public TiledCollection<Group> Groups { get; set; } = new TiledCollection<Group>();


        /// <summary>
        /// Whether or not this map is infinite.
        /// </summary>
        public bool IsInfinite
        {
            get => Infinite;
            set => Infinite = value;
        }



        public static Map FromXml(XmlDocument xml, string xpath = "map")
        {
            var mapNode = xml.SelectSingleNode(xpath);
            var map = FromXmlNode(xml, xpath, mapNode);
            return map;
        }

        public static Map FromXmlNode(XmlDocument xml, string xpath, XmlNode? mapNode)
        {
            string tag = "map";
            if (mapNode is null)
                throw new XmlNodeParseException();
            if (mapNode.Name != tag)
                throw new XmlNodeParseException();
            if (mapNode.Attributes is null)
                throw new XmlNodeParseException();

            // Set map
            var map = new Map();
            map.Version = mapNode.Attributes["version"].ErrorOrValue();
            map.TiledVersion = mapNode.Attributes["tiledversion"]?.Value;
            map.Orientation = mapNode.Attributes["orientation"].ErrorOrParseValue((string str) => Enum.Parse<Orientation>(str, true));
            map.RenderOrder = mapNode.Attributes["renderorder"].ErrorOrParseValue((string str) => Enum.Parse<RenderOrder>(str.Replace('-', '_'), true));
            map.CompressionLevel = mapNode.Attributes["compressionlevel"].NullOrParseValue(int.Parse);
            map.Width = mapNode.Attributes["width"].ErrorOrParseValue(int.Parse);
            map.Height = mapNode.Attributes["height"].ErrorOrParseValue(int.Parse);
            map.TileWidth = mapNode.Attributes["tilewidth"].ErrorOrParseValue(int.Parse);
            map.TileHeight = mapNode.Attributes["tileheight"].ErrorOrParseValue(int.Parse);
            map.HexSideLength = mapNode.Attributes["hexsidelength"].NullOrParseValue(int.Parse);
            map.StaggerAxis = mapNode.Attributes["staggeraxis"].NullOrParseValue((string str) => Enum.Parse<StaggerAxis>(str, true));
            map.StaggerIndex = mapNode.Attributes["staggerindex"].NullOrParseValue((string str) => Enum.Parse<StaggerIndex>(str, true));
            map.ParallaxOriginX = mapNode.Attributes["parallaxoriginx"].NullOrParseValue(int.Parse);
            map.ParallaxOriginY = mapNode.Attributes["parallaxoriginy"].NullOrParseValue(int.Parse);
            map.BackgroundColor = mapNode.Attributes["backgroundcolor"].NullOrParseValue(Color.FromHexARGB);
            map.NextLayerID = mapNode.Attributes["nextlayerid"].ErrorOrParseValue(int.Parse);
            map.NextObjectID = mapNode.Attributes["nextobjectid"].ErrorOrParseValue(int.Parse);
            map.Infinite = mapNode.Attributes["infinite"].ErrorOrParseValue(int.Parse);
            //
            map.Properties = Properties.FromXmlNodes(xml, "map/properties").GetOnlyValueOrNull();
            //
            map.Tilesets.AddRange(Tileset.FromXmlNodes(xml, $"map/tileset"));
            map.Layers.AddRange(Layer.FromXmlNodes(xml, $"map/layer"));
            map.ObjectGroups.AddRange(ObjectGroup.FromXmlNodes(xml, $"map/objectgroup"));
            map.ImageLayers.AddRange(ImageLayer.FromXmlNodes(xml, $"map/imagelayer"));
            map.Groups.AddRange(Group.FromXmlNodes(xml, $"map/group"));

            return map;
        }
    }
}