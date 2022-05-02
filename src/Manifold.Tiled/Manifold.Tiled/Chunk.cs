using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manifold.Tiled
{
    public class Chunk
    {
        /// <summary>
        /// The x coordinate of the chunk in tiles.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The y coordinate of the chunk in tiles.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The width of the chunk in tiles.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height of the chunk in tiles.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LayerTile[]? Tiles { get; set; } = null;
    }
}
