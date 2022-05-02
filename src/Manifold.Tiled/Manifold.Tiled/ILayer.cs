namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILayer :
        IBounded
    {
        /// <summary>
        /// Unique ID of the layer.
        /// </summary>
        /// <remarks>
        /// Defaults to 0 with valid IDs being at least 1.
        /// ach layer that added to a map gets a unique id. Even if a layer is
        /// deleted, no layer ever gets the same ID.
        /// </remarks>
        uint ID { get; set; }

        /// <summary>
        /// The name of the layer.
        /// </summary>
        /// <remarks>
        /// Defaults to "".
        /// </remarks>
        string Name { get; set; }

        /// <summary>
        /// The x coordinate of the layer in tiles.
        /// </summary>
        /// <remarks>
        /// Defaults to 0 and can not be changed in Tiled.
        /// </remarks>
        new int X { get; set; }

        /// <summary>
        /// The y coordinate of the layer in tiles.
        /// </summary>
        /// <remarks>
        /// Defaults to 0 and can not be changed in Tiled.
        /// </remarks>
        new int Y { get; set; }

        /// <summary>
        /// The width of the layer in tiles.
        /// </summary>
        /// <remarks>
        /// Always the same as the map width for fixed-size maps.
        /// </remarks>
        new int Width { get; set; }

        /// <summary>
        /// The height of the layer in tiles.
        /// </summary>
        /// <remarks>
        /// Always the same as the map height for fixed-size maps.
        /// </remarks>
        new int Height { get; set; }

        /// <summary>
        /// The opacity of the layer as a value from 0 to 1.
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        float Opacity { get; set; }

        /// <summary>
        /// A tint color that is multiplied with any tiles drawn by this layer in #AARRGGBB or #RRGGBB format
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        Color? TintColor { get; set; }

        /// <summary>
        /// Horizontal offset for this layer in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        int OffsetX { get; set; }

        /// <summary>
        /// Vertical offset for this layer in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        int OffsetY { get; set; }
    }
}


