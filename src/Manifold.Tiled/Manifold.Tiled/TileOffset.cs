using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manifold.Tiled
{
    /// <summary>
    /// This element is used to specify an offset in pixels, to be applied when drawing
    /// a tile from the related tileset.
    /// </summary>
    public struct TileOffset
    {
        /// <summary>
        /// Horizontal offset in pixels.
        /// </summary>
        public int x;

        /// <summary>
        /// Vertical offset in pixels.
        /// </summary>
        /// <remarks>
        /// Positive is down.
        /// Defaults to 0.
        /// </remarks>
        public int y;
    }
}
