namespace Manifold.Tiled
{
    public class ImageLayer : 
        IIdentifyable,
        INamed
    {
        /*
            id: Unique ID of the layer (defaults to 0, with valid IDs being at least 1). Each layer that added to a map gets a unique id. Even if a layer is deleted, no layer ever gets the same ID. Can not be changed in Tiled. (since Tiled 1.2)
            name: The name of the image layer. (defaults to “”)
            offsetx: Horizontal offset of the image layer in pixels. (defaults to 0) (since 0.15)
            offsety: Vertical offset of the image layer in pixels. (defaults to 0) (since 0.15)
            x: The x position of the image layer in pixels. (defaults to 0, deprecated since 0.15)
            y: The y position of the image layer in pixels. (defaults to 0, deprecated since 0.15)
            opacity: The opacity of the layer as a value from 0 to 1. (defaults to 1)
            visible: Whether the layer is shown (1) or hidden (0). (defaults to 1)
            tintcolor: A color that is multiplied with the image drawn by this layer in #AARRGGBB or #RRGGBB format (optional).
            repeatx: Whether the image drawn by this layer is repeated along the X axis. (since Tiled 1.8)
            repeaty: Whether the image drawn by this layer is repeated along the Y axis. (since Tiled 1.8)

            A layer consisting of a single image.
            Can contain at most one: <properties>, <image>
         */

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

        public Properties? Properties { get; set; } = null;
        public Image? Image { get; set; } = null;
    }
}
