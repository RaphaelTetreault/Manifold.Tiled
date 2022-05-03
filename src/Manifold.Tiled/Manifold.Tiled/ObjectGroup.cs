namespace Manifold.Tiled
{
    /// <summary>
    /// A map layer composed of objects.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#objectgroup"/>
    /// for more information.
    /// </remarks>
    public class ObjectGroup
    {
        /// <summary>
        /// Unique ID of the layer.
        /// </summary>
        /// <remarks>
        /// Defaults to 0 with valid IDs being at least 1.
        /// ach layer that added to a map gets a unique id. Even if a layer is
        /// deleted, no layer ever gets the same ID.
        /// </remarks>
        public uint ID { get; set; } = 0;

        /// <summary>
        /// The name of the layer.
        /// </summary>
        /// <remarks>
        /// Defaults to "".
        /// </remarks>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The x coordinate of the layer in tiles.
        /// </summary>
        /// <remarks>
        /// Defaults to 0 and can not be changed in Tiled.
        /// </remarks>
        public int X { get; set; }

        /// <summary>
        /// The y coordinate of the layer in tiles.
        /// </summary>
        /// <remarks>
        /// Defaults to 0 and can not be changed in Tiled.
        /// </remarks>
        public int Y { get; set; }

        /// <summary>
        /// The width of the layer in tiles.
        /// </summary>
        /// <remarks>
        /// Always the same as the map width for fixed-size maps.
        /// </remarks>
        public int Width { get; set; }

        /// <summary>
        /// The height of the layer in tiles.
        /// </summary>
        /// <remarks>
        /// Always the same as the map height for fixed-size maps.
        /// </remarks>
        public int Height { get; set; }

        /// <summary>
        /// The opacity of the layer as a value from 0 to 1.
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        public float Opacity { get; set; } = 1f;

        /// <summary>
        /// A tint color that is multiplied with any tiles drawn by this layer in #AARRGGBB or #RRGGBB format
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        public Color? TintColor { get; set; }

        /// <summary>
        /// Horizontal offset for this layer in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int OffsetX { get; set; }

        /// <summary>
        /// Vertical offset for this layer in pixels.
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
    }
}
