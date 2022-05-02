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
        IIdentifyable,
        INamed
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
        public byte Visible { get; set; } = 1;

        /// <summary>
        /// A reference to a template file.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        public string? Template { get; set; } = null;




        /// <summary>
        /// A property element tied to this object.
        /// </summary>
        public Property? Property { get; set; } = null;

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
        /// Whether or not this object has a property.
        /// </summary>
        public bool HasProperty => Property != null;

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
    }
}
