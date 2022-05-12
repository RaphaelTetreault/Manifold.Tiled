using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// Representes a non-grid-based element.
    /// Objects have their coordinates and size in pixels.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#object"/>
    /// for more information.
    /// </remarks>
    public class Object :
        IBounded,
        INamed,
        IUniquelyIdentifiable
    {
        /// <summary>
        /// Unique ID of the object.
        /// </summary>
        /// <remarks>
        /// Defaults to 0, with valid IDs being at least 1.
        /// Each object that is placed on a map gets a unique ID.
        /// Even if an object was deleted, no object gets the same ID.
        /// </remarks>
        public uint ID { get; set; } = 0;

        /// <summary>
        /// The name of the object. An arbitrary string.
        /// </summary>
        /// <remarks>
        /// Defaults to "".
        /// </remarks>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The type of the object. An arbitrary string.
        /// </summary>
        /// <remarks>
        /// Defaults to "".
        /// </remarks>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// The x coordinate of the object in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int X { get; set; } = 0;

        /// <summary>
        /// The y coordinate of the object in pixels.
        /// </summary>
        ///  <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int Y { get; set; } = 0;

        /// <summary>
        /// The width of the object in pixels.
        /// </summary>
        ///  <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int Width { get; set; } = 0;

        /// <summary>
        /// The height of the object in pixels.
        /// </summary>
        ///  <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int Height { get; set; } = 0;

        /// <summary>
        /// The rotation of the object in degrees clockwise around (x, y).
        /// </summary>
        ///  <remarks>
        /// Defaults to 0.
        /// </remarks>
        public float Rotation { get; set; } = 0;

        /// <summary>
        /// A reference to a tile.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        public uint? GID { get; set; } = null;

        /// <summary>
        /// Whether the object is shown (1) or hidden (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        public IntBool Visible { get; set; } = 1;

        /// <summary>
        /// A reference to a template file.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        public Template? Template { get; set; } = null;



        /// <summary>
        /// Properties associated with this object.
        /// </summary>
        public Properties? Properties { get; set; } = null;

        /// <summary>
        /// A ellipse element tied to this object.
        /// </summary>
        public Ellipse? Ellipse { get; set; } = null;

        /// <summary>
        /// A point element tied to this object.
        /// </summary>
        public Point? Point { get; set; } = null;

        /// <summary>
        /// A polygon element tied to this object.
        /// </summary>
        public Polygon? Polygon { get; set; } = null;

        /// <summary>
        /// A polyline element tied to this object.
        /// </summary>
        public Polyline? Polyline { get; set; } = null;

        /// <summary>
        /// A text element tied to this object.
        /// </summary>
        public Text? Text { get; set; } = null;



        /// <summary>
        /// Whether the layer is shown or hidden.
        /// </summary>
        public bool IsVisible
        {
            get => Visible;
            set => Visible = value;
        }

        /// <summary>
        /// Whether or not this object has a template.
        /// </summary>
        public bool HasTemplate => Template != null;


        /// <summary>
        /// Whether or not this object has a property.
        /// </summary>
        public bool HasProperties => Properties != null;

        /// <summary>
        /// Whether or not this object has a ellipse.
        /// </summary>
        public bool HasEllipse => Ellipse != null;

        /// <summary>
        /// Whether or not this object has a point.
        /// </summary>
        public bool HasPoint => Point != null;

        /// <summary>
        /// Whether or not this object has a polygon.
        /// </summary>
        public bool HasPolygon => Polygon != null;

        /// <summary>
        /// Whether or not this object has a polyline.
        /// </summary>
        public bool HasPolyline => Polyline != null;

        /// <summary>
        /// Whether or not this object has a text.
        /// </summary>
        public bool HasText => Text != null;


        public static Object FromXmlNode(XmlNode? objectGroupNode)
        {
            string tag = "object";
            if (objectGroupNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (objectGroupNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{objectGroupNode.Name}' is not of type '{tag}'.");
            if (objectGroupNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var @object = new Object();
            // Values
            @object.ID = objectGroupNode.Attributes["id"].ErrorOrParseValue(uint.Parse);
            @object.Name = objectGroupNode.Attributes["name"].ErrorOrValue();
            @object.Type = objectGroupNode.Attributes["type"].ErrorOrValue();
            @object.X = objectGroupNode.Attributes["x"].ErrorOrParseValue(int.Parse);
            @object.Y = objectGroupNode.Attributes["y"].ErrorOrParseValue(int.Parse);
            @object.Width = objectGroupNode.Attributes["width"].ErrorOrParseValue(int.Parse);
            @object.Height = objectGroupNode.Attributes["height"].ErrorOrParseValue(int.Parse);
            @object.Rotation = objectGroupNode.Attributes["rotation"].ErrorOrParseValue(float.Parse);
            @object.GID = objectGroupNode.Attributes["gid"].ErrorOrParseValue(uint.Parse);
            @object.Visible = objectGroupNode.Attributes["visible"].ErrorOrParseValue(int.Parse);
            // Children
            var hasXml = !string.IsNullOrEmpty(objectGroupNode.InnerXml);
            if (hasXml)
            {
                @object.Properties = Properties.FromXml(objectGroupNode.InnerXml, "properties").GetOnlyValueOrNull();
                @object.Ellipse = Ellipse.FromXml(objectGroupNode.InnerXml, "ellipse").GetOnlyValueOrNull();
                @object.Point = Tiled.Point.FromXml(objectGroupNode.InnerXml, "point").GetOnlyValueOrNull();
                @object.Polygon = Polygon.FromXml(objectGroupNode.InnerXml, "polygon").GetOnlyValueOrNull();
                @object.Polyline = Polyline.FromXml(objectGroupNode.InnerXml, "polyline").GetOnlyValueOrNull();
                @object.Text = Text.FromXml(objectGroupNode.InnerXml, "text").GetOnlyValueOrNull();
            }

            return @object;
        }

        public static Object[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledParser.FromXmlNodes(document, xpath, FromXmlNode);

        public static Object[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
