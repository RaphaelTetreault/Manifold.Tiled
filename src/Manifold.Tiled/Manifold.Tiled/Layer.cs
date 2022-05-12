using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// A tile layer.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#layer"/>
    /// for more information.
    /// </remarks>
    public class Layer : 
        INamed,
        IUniquelyIdentifiable
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
        public int X { get; set; } = 0;

        /// <summary>
        /// The y coordinate of the layer in tiles.
        /// </summary>
        public int Y { get; set; } = 0;

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
        public float Opacity { get; set; } = 1;

        /// <summary>
        /// Whether the layer is shown (1) or hidden (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        public IntBool Visible { get; set; } = 1;

        /// <summary>
        /// A tint color that is multiplied with any tiles drawn by this layer in #AARRGGBB or #RRGGBB format
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        public Color? TintColor { get; set; } = null;

        /// <summary>
        /// Horizontal offset for this layer in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int? OffsetX { get; set; } = null;

        /// <summary>
        /// Vertical offset for this layer in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int? OffsetY { get; set; } = null;

        /// <summary>
        /// Horizontal parallax factor for this layer.
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        public float ParallaxX { get; set; } = 1;

        /// <summary>
        /// Vertical parallax factor for this layer.
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        public float ParallaxY { get; set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        public Data? Data { get; set; }


        /// <summary>
        /// Whether the layer is shown or hidden.
        /// </summary>
        public bool IsVisible
        {
            get => Visible;
            set => Visible = value;
        }



        public static Layer FromXmlNode(XmlNode? layerNode)
        {
            string tag = "layer";
            if (layerNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (layerNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{layerNode.Name}' is not of type '{tag}'.");
            if (layerNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var layer = new Layer();
            //
            layer.ID = layerNode.Attributes["id"].ErrorOrParseValue(uint.Parse);
            layer.Name = layerNode.Attributes["name"].ErrorOrValue();
            layer.X = layerNode.Attributes["x"].DefaultOrParseValue(int.Parse, layer.X);
            layer.Y = layerNode.Attributes["y"].DefaultOrParseValue(int.Parse, layer.Y);
            layer.OffsetX = layerNode.Attributes["offsetx"].DefaultOrParseValue(int.Parse, 0);
            layer.OffsetY = layerNode.Attributes["offsety"].DefaultOrParseValue(int.Parse, 0);
            layer.Opacity = layerNode.Attributes["opacity"].DefaultOrParseValue(float.Parse, 1f);
            layer.Visible = layerNode.Attributes["visible"].DefaultOrParseValue(int.Parse, 1);
            layer.TintColor = layerNode.Attributes["tintcolor"].NullOrParseValue(Color.FromHexARGB);
            layer.OffsetX = layerNode.Attributes["offsetx"].DefaultOrParseValue(int.Parse, 0);
            layer.OffsetY = layerNode.Attributes["offsety"].DefaultOrParseValue(int.Parse, 0);
            // Child nodes
            var hasXml = !string.IsNullOrEmpty(layerNode.InnerXml);
            if (hasXml)
            {
                layer.Data = Data.FromXml(layerNode.InnerXml, "data").GetOnlyValueOrNull();
            }

            return layer;
        }

        public static Layer[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static Layer[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);

    }
}
