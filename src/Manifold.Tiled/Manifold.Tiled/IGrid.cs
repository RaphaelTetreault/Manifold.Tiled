namespace Manifold.Tiled
{
    public interface IGrid
    {
        public Orientation Orientation { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
