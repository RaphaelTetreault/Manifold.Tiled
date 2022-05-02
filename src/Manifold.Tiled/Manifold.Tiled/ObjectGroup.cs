namespace Manifold.Tiled
{
    public class ObjectGroup :
        ILayer
    {
        public uint ID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public Color? Color { get; set; }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Width { get; set; }
        public int Height { get; set; }
        public float Opacity { get; set; } = 1f;
        public Color? TintColor { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public DrawOrder DrawOrder { get; set; } = DrawOrder.TopDown;
    }
}
