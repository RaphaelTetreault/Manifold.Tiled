namespace Manifold.Tiled
{
    /// <summary>
    /// Defines an element with a width, height, and orientation.
    /// </summary>
    public interface IGrid
    {
        /// <summary>
        /// 
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Height { get; set; }
    }
}
