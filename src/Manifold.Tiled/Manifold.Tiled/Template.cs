namespace Manifold.Tiled
{
    /// <summary>
    /// The template root element contains the saved map object and a tileset element that points
    /// to an external tileset, if the object is a tile object.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#template"/>
    /// for more information.
    /// </remarks>
    public class Template
    {
        /// <summary>
        /// 
        /// </summary>
        public Tileset? Tileset { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public Object? Object { get; set; }

    }
}
