using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manifold.Tiled
{
    public class Layer
    {
        /// <summary>
        ///  Unique ID of the layer.
        /// </summary>
        /// <remarks>
        /// Defaults to 0 with valid IDs being at least 1.
        /// ach layer that added to a map gets a unique id. Even if a layer is
        /// deleted, no layer ever gets the same ID.
        /// </remarks>
        public uint ID { get; set; } = 0;

        /// <summary>
        /// The name of the layer.
        /// </summary>
        /// <remarks>
        /// Defaults to "".
        /// </remarks>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The x coordinate of the layer in tiles.
        /// </summary>
        /// <remarks>
        /// Defaults to 0 and can not be changed in Tiled.
        /// </remarks>
        public int X { get; set; } = 0;

        /// <summary>
        /// The y coordinate of the layer in tiles.
        /// </summary>
        /// <remarks>
        /// Defaults to 0 and can not be changed in Tiled.
        /// </remarks>
        public int Y { get; set; } = 0;

        /// <summary>
        /// The width of the layer in tiles.
        /// </summary>
        /// <remarks>
        /// Always the same as the map width for fixed-size maps.
        /// </remarks>
        public int Width { get; set; }

        /// <summary>
        /// The height of the layer in tiles.
        /// </summary>
        /// <remarks>
        /// Always the same as the map height for fixed-size maps.
        /// </remarks>
        public int Height { get; set; }

        /// <summary>
        /// The opacity of the layer as a value from 0 to 1.
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        public float Opacity { get; set; } = 1;

        /// <summary>
        /// Whether the layer is shown (1) or hidden (0).
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        public byte Visible { get; set; } = 1;

        /// <summary>
        /// A tint color that is multiplied with any tiles drawn by this layer in #AARRGGBB or #RRGGBB format
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        public Color? Color { get; set; } = null;

        /// <summary>
        /// Horizontal offset for this layer in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int OffsetX { get; set; } = 0;

        /// <summary>
        /// Vertical offset for this layer in pixels.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// </remarks>
        public int OffsetY { get; set; } = 0;

        /// <summary>
        /// Horizontal parallax factor for this layer.
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        public float ParallaxX { get; set; } = 1;

        /// <summary>
        /// Vertical parallax factor for this layer.
        /// </summary>
        /// <remarks>
        /// Defaults to 1.
        /// </remarks>
        public float ParallaxY { get; set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        public Data? Data { get; set; }


        public bool IsVisible
        {
            get => Visible > 0;
            set => Visible = (byte)(value ? 1 : 0);
        }
        public bool IsValidID => ID > 0;
    }
}
