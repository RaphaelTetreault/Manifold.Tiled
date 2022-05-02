namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#object"/>
    /// </remarks>
    public class Object :
        IIdentifyable,
        INamed,
        IRect
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

        public Property? Property { get; set; } = null;
        public Ellipse? Ellipse { get; set; } = null;
        public Point? Point { get; set; } = null;
        public Polygon? Polygon { get; set; } = null;
        public Polyline? Polyline { get; set; } = null;
        public Text? Text { get; set; } = null;
    }
}
