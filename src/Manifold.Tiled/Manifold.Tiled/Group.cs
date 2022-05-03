namespace Manifold.Tiled
{
    /// <summary>
    /// A group layer, used to organize the layers of the map in a hierarchy.
    /// Its attributes offsetx, offsety, opacity, visible and tintcolor recursively affect child layers.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#group"/>
    /// for more information.
    /// </remarks>
    public class Group :
        INamed,
        IUniquelyIdentifiable
    {
        /// <summary>
        /// Unique ID of the layer.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// Valid IDs are at least 1.
        /// </remarks>
        public uint ID { get; set; } = 0;

        /// <summary>
        /// The name of the image layer.
        /// </summary>
        /// <remarks>
        /// Defaults to “”.
        /// </remarks>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Horizontal offset of the group layer in pixels.
        /// </summary>
        public int OffsetX { get; set; } = 0;

        /// <summary>
        /// Vertical offset of the group layer in pixels.
        /// </summary>
        public int OffsetY { get; set; } = 0;

        /// <summary>
        /// Whether the layer is shown (1) or hidden (0).
        /// </summary>
        public IntBool Visible { get; set; } = 1;

        /// <summary>
        /// A color that is multiplied with the image drawn by this layer.
        /// </summary>
        public Color? TintColor { get; set; } = null;


        public bool IsVisible
        {
            get => Visible;
            set => Visible = value;
        }

        /// <summary>
        /// Whether or not this group has a tint color.
        /// </summary>
        public bool HasTintColor => TintColor != null;
    }
}
