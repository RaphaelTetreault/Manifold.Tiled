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

        /// <summary>
        /// Whether or not this animation has frames.
        /// </summary>
        /// <remarks>
        /// The `Frames` array should always be initialized with size 0.
        /// </remarks>
        public bool HasFrames => Frames != null && Frames.Length > 0;
    }
}
