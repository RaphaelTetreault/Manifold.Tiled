namespace Manifold.Tiled
{
    /// <summary>
    /// Contains a list of animation frames.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#animation"/>
    /// for more information.
    /// </remarks>
    public class Animation
    {
        /// <summary>
        /// All animation frames.
        /// </summary>
        public AnimationFrame[] Frames { get; set; } = new AnimationFrame[0];
    }
}
