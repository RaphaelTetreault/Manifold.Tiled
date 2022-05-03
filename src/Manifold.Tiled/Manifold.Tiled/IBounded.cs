namespace Manifold.Tiled
{
    /// <summary>
    /// Represents an element with a start coordinate (x,y) and a width and height.
    /// </summary>
    public interface IBounded
    {
        /// <summary>
        /// 
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int Height { get; set; }
    }
}
