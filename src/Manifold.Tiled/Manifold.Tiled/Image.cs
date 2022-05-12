using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// Represents an image.
    /// </summary>
    /// <remarks>
    /// Note that it is not currently possible to use Tiled to create maps with embedded image data,
    /// even though the TMX format supports this.
    /// 
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#image"/>
    /// for more information.
    /// </remarks>
    public class Image
    {
        /// <summary>
        /// Used for embedded images, in combination with a data child element.
        /// </summary>
        /// <remarks>
        /// Valid values are file extensions like png, gif, jpg, bmp, etc.
        /// </remarks>
        public string? Format { get; set; } = null;

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
        public Color? Trans { get; set; } = null;

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

        /// <summary>
        /// Wrapper for Trans property.
        /// Defines a specific color that is treated as transparent (example value: “#FF00FF” for magenta).
        /// </summary>
        public Color? TransparentColor
        {
            get => Trans;
            set => Trans = value;
        }


        public Data? Data { get; set; } = null;

        /// <summary>
        /// Whether or not this group has a tint color.
        /// </summary>
        public bool HasTransparentColor => Trans != null;

        /// <summary>
        /// Whether or not this image has a width value.
        /// </summary>
        public bool HasWidth => Width != null;

        /// <summary>
        /// Whether or not this image has a height value.
        /// </summary>
        public bool HasHeight => Height != null;




        public static Image FromXmlNode(XmlNode? imageNode)
        {
            string tag = "image";
            if (imageNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (imageNode.Name != tag)
                throw new XmlNodeParseException($"Node is not of type '{tag}'.");
            if (imageNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var image = new Image();
            // Values
            image.Format = imageNode.Attributes["format"]?.Value;
            image.Source = imageNode.Attributes["source"].ErrorOrValue();
            image.Trans = imageNode.Attributes["trans"].NullOrParseValue(Color.FromHexARGB);
            image.Width = imageNode.Attributes["width"].NullOrParseValue(int.Parse);
            image.Height = imageNode.Attributes["height"].NullOrParseValue(int.Parse);
            // Child nodes
            var hasXml = !string.IsNullOrEmpty(imageNode.InnerXml);
            if (hasXml)
            {
                image.Data = Data.FromXml(imageNode.InnerXml, "data").GetOnlyValueOrNull();
            }

            return image;
        }

        public static Image[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static Image[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
