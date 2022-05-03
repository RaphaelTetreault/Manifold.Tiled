namespace Manifold.Tiled
{
    /// <summary>
    /// A layer consisting of a single image.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#imagelayer"/>
    /// for more information.
    /// </remarks>
    public class ImageLayer : 
        IIdentifyable,
        INamed
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
        /// Horizontal offset of the image layer in pixels.
        /// </summary>
        public int OffsetX { get; set; } = 0;

        /// <summary>
        /// Vertical offset of the image layer in pixels.
        /// </summary>
        public int OffsetY { get; set; } = 0;

        /// <summary>
        /// The opacity of the layer as a value from 0 to 1.
        /// </summary>
        public float Opacity { get; set; } = 1f;

        /// <summary>
        /// Whether the layer is shown (1) or hidden (0).
        /// </summary>
        public byte Visible { get; set; } = 1;

        /// <summary>
        ///  A color that is multiplied with the image drawn by this layer.
        /// </summary>
        public Color? TintColor { get; set; } = null;

        /// <summary>
        /// Whether the image drawn by this layer is repeated along the X axis.
        /// </summary>
        public byte RepeatX { get; set; } = 0;

        /// <summary>
        /// Whether the image drawn by this layer is repeated along the Y axis.
        /// </summary>
        public byte RepeatY { get; set; } = 0;


        /// <summary>
        /// Properties associated with this image layer.
        /// </summary>
        public Properties? Properties { get; set; } = null;

        /// <summary>
        /// The image for this layer.
        /// </summary>
        public Image? Image { get; set; } = null;

        /// <summary>
        /// Whether or not this image layer has properties.
        /// </summary>
        public bool HasProperties => Properties != null;

        /// <summary>
        /// Whether or not this image layer has an image.
        /// </summary>
        public bool HasImage => Image != null;

    }
}
