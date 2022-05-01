namespace Manifold.Tiled
{
    /// <summary>
    /// The order in which tiles on tile layers are rendered.
    /// </summary>
    /// <remarks>
    /// Order provides flag information.
    /// Bit 0 maps Right/Left to 0/1.
    /// Bit 1 maps Down/Up to 0/1.
    /// </remarks>
    public enum RenderOrder : byte
    {
        Right_Down,
        Left_Down,
        Right_Up,
        Left_Up,
    }
}
