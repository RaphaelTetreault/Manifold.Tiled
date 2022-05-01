using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manifold.Tiled
{
    /// <summary>
    /// Contains a list of animation frames.
    /// </summary>
    public class Animation
    {
        /// <summary>
        /// All animation frames.
        /// </summary>
        public AnimationFrame[] Frames { get; set; } = new AnimationFrame[0];
    }
}
