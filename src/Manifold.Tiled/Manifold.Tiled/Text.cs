using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// Used to mark an object as a text object. Contains the actual text as character data.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#text"/>
    /// for more information.
    /// </remarks>
    public class Text
    {
        /// <summary>
        /// The font family used.
        /// </summary>
        /// <remarks>
        /// Defaults to "sans-serif".
        /// </remarks>
        public string FontFamily { get; set; } = "sans-serif";

        /// <summary>
        /// The size of the font in pixels.
        /// </summary>
        /// <remarks>
        /// Does not use points because other sizes in the TMX format are also using pixels.
        /// Defaults to 16.
        /// </remarks>
        public int PixelSize { get; set; } = 16;

        /// <summary>
        /// Whether word wrapping is enabled (1) or disabled (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public IntBool Wrap { get; set; } = 0;

        /// <summary>
        /// Color of the text.
        /// </summary>
        /// <remarks>
        /// Defaults to #000000.
        /// </remarks>
        public Color Color { get; set; } = new Color(0, 0, 0);

        /// <summary>
        /// Whether the font is bold (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public IntBool Bold { get; set; } = 0;

        /// <summary>
        /// Whether the font is italic (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public IntBool Italic { get; set; } = 0;

        /// <summary>
        /// Whether a line should be drawn below the text (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public IntBool Underline { get; set; } = 0;

        /// <summary>
        /// Whether a line should be drawn through the text (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public IntBool Strikeout { get; set; } = 0;

        /// <summary>
        /// Whether kerning should be used while rendering the text (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public IntBool Kerning { get; set; } = 0;

        /// <summary>
        /// Horizontal alignment of the text within the object.
        /// </summary>
        /// <remarks>
        /// Defaults to `Left`.
        /// </remarks>
        public HorizontalAlignment HAlign { get; set; } = HorizontalAlignment.Left;

        /// <summary>
        /// Vertical alignment of the text within the object.
        /// </summary>
        /// <remarks>
        /// Defaults to `Top`.
        /// </remarks>
        public VerticalAlignment VAlign { get; set; } = VerticalAlignment.Top;

        /// <summary>
        /// The Text's value.
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Whether word wrapping is enabled or disabled.
        /// </summary>
        public bool DoesWrap
        {
            get => Wrap;
            set => Wrap = value;
        }

        /// <summary>
        /// Whether the font is bold or not.
        /// </summary>
        public bool IsBold
        {
            get => Bold;
            set => Bold = value;
        }

        /// <summary>
        /// Whether a line should be drawn below the text or not.
        /// </summary>
        public bool IsUnderlined
        {
            get => Underline;
            set => Underline = value;
        }

        /// <summary>
        /// Whether a line should be drawn through the text or not.
        /// </summary>
        public bool IsStrikeout
        {
            get => Strikeout;
            set => Strikeout = value;
        }

        /// <summary>
        /// Whether kerning should be used while rendering the text or not.
        /// </summary>
        public bool UsesKerning
        {
            get => Kerning;
            set => Kerning = value;
        }


        public static Text FromXmlNode(XmlNode? textNode)
        {
            string tag = "text";
            if (textNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (textNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{textNode.Name}' is not of type '{tag}'.");
            if (textNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var text = new Text();
            text.FontFamily = textNode.Attributes["fontfamily"].DefaultOrValue("sans-serif");
            text.PixelSize = textNode.Attributes["pixelsize"].ErrorOrParseValue(int.Parse);
            text.Wrap = textNode.Attributes["wrap"].ErrorOrParseValue(int.Parse);
            text.Color = textNode.Attributes["color"].ErrorOrParseValue(Color.FromHexARGB);
            text.Bold = textNode.Attributes["bold"].ErrorOrParseValue(int.Parse);
            text.Italic = textNode.Attributes["italic"].ErrorOrParseValue(int.Parse);
            text.Underline = textNode.Attributes["underline"].ErrorOrParseValue(int.Parse);
            text.Strikeout = textNode.Attributes["strikeout"].ErrorOrParseValue(int.Parse);
            text.Kerning = textNode.Attributes["kerning"].ErrorOrParseValue(int.Parse);
            text.HAlign = textNode.Attributes["halign"].ErrorOrParseValue((string str) => Enum.Parse<HorizontalAlignment>(str, true));
            text.VAlign = textNode.Attributes["valign"].ErrorOrParseValue((string str) => Enum.Parse<VerticalAlignment>(str, true));
            text.Value = textNode.Attributes["value"].ErrorOrValue();

            return text;
        }

        public static Text[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledXmlExtensions.FromXmlNodes(document, xpath, FromXmlNode);

        public static Text[] FromXml(string xml, string xpath)
            => TiledXmlExtensions.FromXml(xml, xpath, FromXmlNode);
    }
}
