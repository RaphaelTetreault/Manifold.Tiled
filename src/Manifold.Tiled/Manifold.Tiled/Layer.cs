namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// See <see href=""/>
    /// for more information.
    /// </remarks>
    public class Layer :
        ILayer
    {
        public uint ID { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public int X { get; set; } = 0;

        public int Y { get; set; } = 0;

        public int Width { get; set; }

        public int Height { get; set; }

        public float Opacity { get; set; } = 1;

        /// <summary>
        /// Whether the layer is shown (1) or hidden (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        public byte Visible { get; set; } = 1;

        public Color? TintColor { get; set; } = null;

        public int OffsetX { get; set; } = 0;

        public int OffsetY { get; set; } = 0;

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


        public bool IsVisible
        {
            get => Visible > 0;
            set => Visible = (byte)(value ? 1 : 0);
        }
        public bool IsValidID => ID > 0;
    }
}
