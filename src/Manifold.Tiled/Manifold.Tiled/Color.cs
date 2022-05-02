namespace Manifold.Tiled
{
    public struct Color
    {
        public byte a;
        public byte r;
        public byte g;
        public byte b;

        public Color() : this(0, 0, 0, 0) { }
        public Color(byte intensity) : this(intensity, intensity, intensity, 0) { }
        public Color(byte r, byte g, byte b) : this(r, g, b, 0) { }
        public Color(byte r, byte g, byte b, byte a)
        {
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

        public uint RawARGB
        {
            get
            {
                return (uint)(
                    (a << 24) +
                    (r << 16) +
                    (g << 08) +
                    (b << 00));
            }
        }

        public override string ToString()
        {
            return $"{a:x2}{r:x2}{g:x2}{b:x2}";
        }
    }
}
