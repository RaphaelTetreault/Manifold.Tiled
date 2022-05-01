namespace Manifold.Tiled
{
    /// <summary>
    /// Map orientation. Tiled supports “orthogonal”, “isometric”, “staggered” and “hexagonal” (since 0.11).
    /// </summary>
    public enum Orientation : byte
    {
        Orthogonal,
        Isometric,
        Staggered,
    }
}
