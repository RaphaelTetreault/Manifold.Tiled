using System.Runtime.InteropServices;

namespace Manifold.Tiled
{
    /// <summary>
    /// A color structure used to manage Tiled's color formats.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Color
    {
        /// <summary>
        /// The raw color data in ARGB8 format.
        /// </summary>
        [FieldOffset(0)]
        public uint rawARGB;

        /// <summary>
        /// Color Alpha component.
        /// </summary>
        [FieldOffset(0)]
        public byte a;

        /// <summary>
        /// Color Red component.
        /// </summary>
        [FieldOffset(1)]
        public byte r;

        /// <summary>
        /// Color Green component.
        /// </summary>
        [FieldOffset(2)]
        public byte g;

        /// <summary>
        /// Color Blue component.
        /// </summary>
        [FieldOffset(3)]
        public byte b;


        public Color() : this(0, 0, 0, 0) { }
        public Color(byte intensity) : this(intensity, intensity, intensity, 0) { }
        public Color(byte r, byte g, byte b) : this(r, g, b, 0) { }
        public Color(byte r, byte g, byte b, byte a)
        {
            rawARGB = 0;
            this.a = a;
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public uint RawRGBA
        {
            get
            {
                return (uint)(
                    (r << 24) +
                    (g << 16) +
                    (b << 08) +
                    (a << 00));
            }
        }

        public uint RawARGB => rawARGB;

        public override string ToString()
        {
            return $"{a:x2}{r:x2}{g:x2}{b:x2}";
        }

        public Color FromRawRGBA(uint rawRGBA)
        {
            var color = new Color()
            {
                r = (byte)(rawRGBA >> 24),
                g = (byte)(rawRGBA >> 16),
                b = (byte)(rawRGBA >> 08),
                a = (byte)(rawRGBA >> 00),
            };
            return color;
        }

        public Color FromRawARGB(uint rawARGB)
        {
            var color = new Color()
            {
                rawARGB = rawARGB,
            };
            return color;
        }

        public static Color FromHexARGB(string hexString)
            => FromHex(hexString, true);

        public static Color FromHexRGBA(string hexString)
            => FromHex(hexString, false);

        private static Color FromHex(string hexString, bool isAlphaFirst)
        {
            var cleanColor = SanitizeHexString(hexString);
            var componentSize = cleanColor.Length > 4 ? 2 : 1;
            var fullColor = AddAlpha(cleanColor, componentSize, isAlphaFirst);
            var color = HexStringToColor(fullColor, componentSize, isAlphaFirst);
            return color;
        }

        private static string SanitizeHexString(string hexString)
        {
            // Strip off # if it exists
            hexString = hexString.Replace("#", "");

            // Ensure string is only hexadecimal
            bool isHex = uint.TryParse(hexString, out _);
            if (!isHex)
            {
                throw new ArgumentException($"Argument '{nameof(hexString)}' is not hexadecimal!");
            }

            // Ensure length of string
            bool isLength3 = hexString.Length == 3;
            bool isLength4 = hexString.Length == 4;
            bool isLength6 = hexString.Length == 6;
            bool isLength8 = hexString.Length == 8;
            if (!isLength3 && !isLength4 && !isLength6 && !isLength8)
            {
                throw new ArgumentException($"Argument '{nameof(hexString)}' is 3, 4, 6, or 8 characters long!");
            }

            return hexString;
        }

        private static string AddAlpha(string hexString, int componentSize, bool isAlphaFirst)
        {
            // Only add alpha if we are of size 3 or 6
            if (hexString.Length == 4 ||
                hexString.Length == 8)
                return hexString;

            var alpha = (componentSize == 2) ? "00" : "0";

            var value = isAlphaFirst
                ? alpha + hexString
                : hexString + alpha;

            return value;
        }

        private static Color HexStringToColor(string hexString, int componentSize, bool alphaFirst)
        {
            List<byte> components = new List<byte>(4);

            for (int i = 0; i < hexString.Length; i += componentSize)
            {
                var componentString = hexString.Substring(i, componentSize);
                var component = byte.Parse(componentString);
                components.Add(component);
            }

            byte a = alphaFirst ? components[0] : components[3];
            byte r = alphaFirst ? components[1] : components[0];
            byte g = alphaFirst ? components[2] : components[1];
            byte b = alphaFirst ? components[3] : components[2];

            return new Color(r, g, b, a);
        }

    }
}
