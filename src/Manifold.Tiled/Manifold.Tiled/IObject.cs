namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    public interface IObject :
        IIdentifyable,
        INamed
    {
        /// <summary>
        /// Unique ID of the object.
        /// </summary>
        new uint ID { get; set; }

        /// <summary>
        /// The name of the object. An arbitrary string.
        /// </summary>
        new string Name { get; set; }
    }
}
