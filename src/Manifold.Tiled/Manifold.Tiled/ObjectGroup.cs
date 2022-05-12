using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// A map group composed of objects.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#objectgroup"/>
    /// for more information.
    /// </remarks>
    public class ObjectGroup :
        INamed,
        IUniquelyIdentifiable
    {
        /// <summary>
        /// Unique ID of the group.
        /// </summary>
        /// <remarks>
        /// Defaults to 0 with valid IDs being at least 1.
        /// Each group that added to a map gets a unique id. Even if a group is
        /// deleted, no group ever gets the same ID.
        /// </remarks>
        public uint ID { get; set; } = 0;

        /// <summary>
        /// The name of the group.
        /// </summary>
        /// <remarks>
        /// Defaults to "".
        /// </remarks>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The x coordinate of the group in tiles.
        /// </summary>
        /// <remarks>
        /// Defaults to 0 and can not be changed in Tiled.
        /// </remarks>
        public int X { get; set; }

        /// <summary>
        /// The y coordinate of the group in tiles.
        /// </summary>
        /// <remarks>
        /// Defaults to 0 and can not be changed in Tiled.
        /// </remarks>
        public int Y { get; set; }

        /// <summary>
        /// The width of the group in tiles.
        /// </summary>
        /// <remarks>
        /// Always the same as the map width for fixed-size maps.
        /// </remarks>
        public int Width { get; set; }

        /// <summary>
        /// The height of the group in tiles.
        /// </summary>
        /// <remarks>
        /// Always the same as the map height for fixed-size maps.
        /// </remarks>
        public int Height { get; set; }

        /// <summary>
        /// The opacity of the group as a value from 0 to 1.
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        public float Opacity { get; set; } = 1f;

        /// <summary>
        /// A tint color that is multiplied with any tiles drawn by this group in #AARRGGBB or #RRGGBB format
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        public Color? TintColor { get; set; }

        /// <summary>
        /// Horizontal offset for this group in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int OffsetX { get; set; }

        /// <summary>
        /// Vertical offset for this group in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int OffsetY { get; set; }

        /// <summary>
        /// The order in which elements are drawn.
        /// </summary>
        public DrawOrder DrawOrder { get; set; } = DrawOrder.TopDown;


        /// <summary>
        /// Properties associated with this object group.
        /// </summary>
        public Properties? Properties { get; set; } = null;

        /// <summary>
        /// Objects associated with this object group.
        /// </summary>
        public Object[]? Objects { get; set; } = null;

        /// <summary>
        /// Whether or not this object group has properties.
        /// </summary>
        public bool HasProperties => Properties != null;

        /// <summary>
        /// Whether or not this object group has objects.
        /// </summary>
        public bool HasObjects => Objects != null && Objects.Length > 0;



        public static ObjectGroup FromXmlNode(XmlNode? objectGroupNode)
        {
            string tag = "objectgroup";
            if (objectGroupNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (objectGroupNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{objectGroupNode.Name}' is not of type '{tag}'.");
            if (objectGroupNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var objectGroup = new ObjectGroup();
            // Values
            objectGroup.ID = objectGroupNode.Attributes["id"].ErrorOrParseValue(uint.Parse);
            objectGroup.Name = objectGroupNode.Attributes["name"].ErrorOrValue();
            objectGroup.X = objectGroupNode.Attributes["x"].DefaultOrParseValue(int.Parse);
            objectGroup.Y = objectGroupNode.Attributes["y"].DefaultOrParseValue(int.Parse);
            objectGroup.Width = objectGroupNode.Attributes["width"].DefaultOrParseValue(int.Parse);
            objectGroup.Height = objectGroupNode.Attributes["height"].DefaultOrParseValue(int.Parse);
            objectGroup.Opacity = objectGroupNode.Attributes["opacity"].DefaultOrParseValue(float.Parse);
            objectGroup.TintColor = objectGroupNode.Attributes["tintcolor"].NullOrParseValue(Color.FromHexARGB);
            objectGroup.OffsetX = objectGroupNode.Attributes["offsetx"].DefaultOrParseValue(int.Parse);
            objectGroup.OffsetY = objectGroupNode.Attributes["offsety"].DefaultOrParseValue(int.Parse);
            objectGroup.DrawOrder = objectGroupNode.Attributes["draworder"].DefaultOrParseValue(TiledEnumUtility.Parse<DrawOrder>, DrawOrder.TopDown);
            // Children
            var hasXml = !string.IsNullOrEmpty(objectGroupNode.InnerXml);
            if (hasXml)
            {
                objectGroup.Properties = Properties.FromXml(objectGroupNode.InnerXml, "properties").GetOnlyValueOrNull();
                objectGroup.Objects = Object.FromXml(objectGroupNode.InnerXml, "object");
            }

            return objectGroup;
        }

        public static ObjectGroup[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledParser.FromXmlNodes(document, xpath, FromXmlNode);

        public static ObjectGroup[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
