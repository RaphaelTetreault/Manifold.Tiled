namespace Manifold.Tiled
{
    /// <summary>
    /// Defines an element with unique ID.
    /// </summary>
    public interface IIdentifyable
    {
        /// <summary>
        /// Unique ID.
        /// </summary>
        public uint ID { get; set; }
    }
}
