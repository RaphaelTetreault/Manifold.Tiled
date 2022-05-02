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
        IIdentifyable,
        INamed
    {
        /*
            id: Unique ID of the layer (defaults to 0, with valid IDs being at least 1). Each layer that added to a map gets a unique id. Even if a layer is deleted, no layer ever gets the same ID. Can not be changed in Tiled. (since Tiled 1.2)
            name: The name of the group layer. (defaults to “”)
            offsetx: Horizontal offset of the group layer in pixels. (defaults to 0)
            offsety: Vertical offset of the group layer in pixels. (defaults to 0)
            opacity: The opacity of the layer as a value from 0 to 1. (defaults to 1)
            visible: Whether the layer is shown (1) or hidden (0). (defaults to 1)
            tintcolor: A color that is multiplied with any graphics drawn by any child layers, in #AARRGGBB or #RRGGBB format (optional).
        
            A group layer, used to organize the layers of the map in a hierarchy. Its attributes offsetx, offsety, opacity, visible and tintcolor recursively affect child layers.
            Can contain at most one: <properties>
            Can contain any number: <layer>, <objectgroup>, <imagelayer>, <group>
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
        public byte Visible { get; set; } = 1;

        /// <summary>
        ///  A color that is multiplied with the image drawn by this layer.
        /// </summary>
        public Color? TintColor { get; set; } = null;
    }
}
