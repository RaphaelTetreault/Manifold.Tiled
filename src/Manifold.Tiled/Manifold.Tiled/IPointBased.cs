namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPointBased
    {
        /// <summary>
        /// A list of x,y coordinates in pixels.
        /// </summary>
        Point[] Points { get; set; }
    }
}
