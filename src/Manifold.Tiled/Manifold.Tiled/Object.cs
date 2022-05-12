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
        //IBounded,
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
        public int ID { get; set; } = 0;

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
        public double X { get; set; } = 0;

        /// <summary>
        /// The y coordinate of the object in pixels.
        /// </summary>
        ///  <remarks>
        /// Defaults to 0.
        /// </remarks>
        public double Y { get; set; } = 0;

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
        public int? GID { get; set; } = null;

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


        public static Object FromXmlNode(XmlNode? objectNode)
        {
            string tag = "object";
            if (objectNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (objectNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{objectNode.Name}' is not of type '{tag}'.");
            if (objectNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var @object = new Object();
            // Values
            @object.ID = objectNode.Attributes["id"].ErrorOrParseValue(int.Parse);
            @object.Name = objectNode.Attributes["name"].DefaultOrValue(string.Empty);
            @object.Type = objectNode.Attributes["type"].DefaultOrValue(string.Empty);
            @object.X = objectNode.Attributes["x"].ErrorOrParseValue(double.Parse);
            @object.Y = objectNode.Attributes["y"].ErrorOrParseValue(double.Parse);
            @object.Width = objectNode.Attributes["width"].ErrorOrParseValue(int.Parse);
            @object.Height = objectNode.Attributes["height"].ErrorOrParseValue(int.Parse);
            @object.Rotation = objectNode.Attributes["rotation"].DefaultOrParseValue(float.Parse);
            @object.GID = objectNode.Attributes["gid"].NullOrParseValue(int.Parse);
            @object.Visible = objectNode.Attributes["visible"].DefaultOrParseValue(int.Parse, 1);
            // Children
            var hasXml = !string.IsNullOrEmpty(objectNode.InnerXml);
            if (hasXml)
            {
                @object.Properties = Properties.FromXml(objectNode.InnerXml, "properties").GetOnlyValueOrNull();
                @object.Ellipse = Ellipse.FromXml(objectNode.InnerXml, "ellipse").GetOnlyValueOrNull();
                @object.Point = Tiled.Point.FromXml(objectNode.InnerXml, "point").GetOnlyValueOrNull();
                @object.Polygon = Polygon.FromXml(objectNode.InnerXml, "polygon").GetOnlyValueOrNull();
                @object.Polyline = Polyline.FromXml(objectNode.InnerXml, "polyline").GetOnlyValueOrNull();
                @object.Text = Text.FromXml(objectNode.InnerXml, "text").GetOnlyValueOrNull();
            }

            return @object;
        }

        public static Object[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static Object[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
