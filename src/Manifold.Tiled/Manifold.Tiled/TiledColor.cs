namespace Manifold.Tiled
{
    public struct TiledColor
    {
        public byte a;
        public byte r;
        public byte g;
        public byte b;

        public TiledColor() : this(0, 0, 0, 0) { }
        public TiledColor(byte intensity) : this(intensity, intensity, intensity, 0) { }
        public TiledColor(byte r, byte g, byte b) : this(r, g, b, 0) { }
        public TiledColor(byte r, byte g, byte b, byte a)
        {
            this.a = a;
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public override string ToString()
        {
            return $"{a:x2}{r:x2}{g:x2}{b:x2}";
        }
    }
}
