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
        public byte Wrap { get; set; } = 0;

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
        public byte Bold { get; set; } = 0;

        /// <summary>
        /// Whether the font is italic (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public byte Italic { get; set; } = 0;

        /// <summary>
        /// Whether a line should be drawn below the text (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public byte Underline { get; set; } = 0;

        /// <summary>
        /// Whether a line should be drawn through the text (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public byte Strikeout { get; set; } = 0;

        /// <summary>
        /// Whether kerning should be used while rendering the text (1) or not (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public byte Kerning { get; set; } = 0;

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
            get => Wrap > 0;
            set => Wrap = (byte)(value ? 1 : 0);
        }

        /// <summary>
        /// Whether the font is bold or not.
        /// </summary>
        public bool IsBold
        {
            get => Bold > 0;
            set => Bold = (byte)(value ? 1 : 0);
        }

        /// <summary>
        /// Whether a line should be drawn below the text or not.
        /// </summary>
        public bool IsUnderlined
        {
            get => Underline > 0;
            set => Underline = (byte)(value ? 1 : 0);
        }

        /// <summary>
        /// Whether a line should be drawn through the text or not.
        /// </summary>
        public bool IsStrikeout
        {
            get => Strikeout > 0;
            set => Strikeout = (byte)(value ? 1 : 0);
        }

        /// <summary>
        /// Whether kerning should be used while rendering the text or not.
        /// </summary>
        public bool UsesKerning
        {
            get => Kerning > 0;
            set => Kerning = (byte)(value ? 1 : 0);
        }
    }
}
