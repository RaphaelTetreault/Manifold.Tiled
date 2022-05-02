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
        /// The template tileset.
        /// </summary>
        public Tileset? Tileset { get; set; } 

        /// <summary>
        /// The template object.
        /// </summary>
        public Object? Object { get; set; }


        /// <summary>
        /// Whether or not this template has a tileset.
        /// </summary>
        public bool HasTileset => Tileset != null;

        /// <summary>
        /// Whether or not this template has an object.
        /// </summary>
        public bool HasObject => Object != null;
    }
}
