namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#polyline"/>
    /// for more information.
    /// </remarks>
    public class Polyline :
        IPointBased
    {
        /// <summary>
        /// A list of x,y coordinates in pixels.
        /// </summary>
        public Point[] Points { get; set; } = new Point[0];
    }
}
