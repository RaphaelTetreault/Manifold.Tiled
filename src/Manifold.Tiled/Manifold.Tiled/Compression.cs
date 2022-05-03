namespace Manifold.Tiled
{
    /// <summary>
    /// The compression used to compress the tile layer data.
    /// </summary>
    public enum Compression : byte
    {
        None,
        gzip,
        zlib,
        zstd,
    }
}
