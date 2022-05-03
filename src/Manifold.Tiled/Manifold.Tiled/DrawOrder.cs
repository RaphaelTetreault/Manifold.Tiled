namespace Manifold.Tiled
{
    /// <summary>
    /// Whether objects are drawn according to order of appearance (“index”)
    /// or sorted by their y-coordinate (“topdown”).
    /// </summary>
    public enum DrawOrder : byte
    {
        /// <summary>
        /// Objects are sorted by their y-coordinate.
        /// </summary>
        TopDown,

        /// <summary>
        /// Objects are drawn according to the order of appearance.
        /// </summary>
        Index,
    }
}
