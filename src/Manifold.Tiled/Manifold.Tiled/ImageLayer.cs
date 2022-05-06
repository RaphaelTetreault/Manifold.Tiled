using System.Xml;

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
        public IntBool Visible { get; set; } = 1;

        /// <summary>
        ///  A color that is multiplied with the image drawn by this layer.
        /// </summary>
        public Color? TintColor { get; set; } = null;

        /// <summary>
        /// Whether the image drawn by this layer is repeated along the X axis.
        /// </summary>
        public IntBool RepeatX { get; set; } = 0;

        /// <summary>
        /// Whether the image drawn by this layer is repeated along the Y axis.
        /// </summary>
        public IntBool RepeatY { get; set; } = 0;

        /// <summary>
        /// Whether the layer is shown (1) or hidden (0).
        /// </summary>
        public bool IsVisible
        {
            get => Visible;
            set => Visible = value;
        }

        /// <summary>
        /// Whether the image drawn by this layer is repeated along the X axis.
        /// </summary>
        public bool IsRepeatX
        {
            get => RepeatX;
            set => RepeatX = value;
        }

        /// <summary>
        /// Whether the image drawn by this layer is repeated along the Y axis.
        /// </summary>
        public bool IsRepeatY
        {
            get => RepeatY;
            set => RepeatY = value;
        }

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


        public static ImageLayer FromXmlNode(XmlNode? imageLayerNode)
        {
            string tag = "imagelayer";
            if (imageLayerNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (imageLayerNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{imageLayerNode.Name}' is not of type '{tag}'.");
            if (imageLayerNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var imagelayer = new ImageLayer();
            imagelayer.ID = imageLayerNode.Attributes["id"].ErrorOrParseValue(uint.Parse);
            imagelayer.Name = imageLayerNode.Attributes["name"].ErrorOrValue();
            imagelayer.OffsetX = imageLayerNode.Attributes["offsetx"].ErrorOrParseValue(int.Parse);
            imagelayer.OffsetY = imageLayerNode.Attributes["offsety"].ErrorOrParseValue(int.Parse);
            imagelayer.Opacity = imageLayerNode.Attributes["opacity"].ErrorOrParseValue(float.Parse);
            imagelayer.Visible = imageLayerNode.Attributes["visible"].ErrorOrParseValue(int.Parse);
            imagelayer.TintColor = imageLayerNode.Attributes["tintcolor"].NullOrParseValue(Color.FromHexARGB);
            imagelayer.RepeatX = imageLayerNode.Attributes["repeatx"].ErrorOrParseValue(int.Parse);
            imagelayer.RepeatY = imageLayerNode.Attributes["repeaty"].ErrorOrParseValue(int.Parse);

            return imagelayer;
        }

        public static ImageLayer[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledXmlExtensions.FromXmlNodes(document, xpath, FromXmlNode);

        public static ImageLayer[] FromXml(string xml, string xpath)
            => TiledXmlExtensions.FromXml(xml, xpath, FromXmlNode);

    }
}
