﻿namespace Manifold.Tiled
{
    internal class Image
    {
        /// <summary>
        /// Used for embedded images, in combination with a data child element.
        /// </summary>
        /// <remarks>
        /// Valid values are file extensions like png, gif, jpg, bmp, etc.
        /// </remarks>
        public string Format { get; set; } = string.Empty;

        /// <summary>
        /// The reference to the tileset image file.
        /// </summary>
        /// <remarks>
        /// Tiled supports most common image formats.
        /// Only used if the image is not embedded.
        /// </remarks>
        public string Source { get; set; } = string.Empty;

        /// <summary>
        /// Defines a specific color that is treated as transparent (example value: “#FF00FF” for magenta).
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        public TiledColor? Trans { get; set; } = null;

        /// <summary>
        /// The image width in pixels.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// Used for tile index correction when the image changes.
        /// </remarks>
        public int? Width { get; set; } = null;

        /// <summary>
        /// The image height in pixels.
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        public int? Height { get; set; } = null;
    }
}