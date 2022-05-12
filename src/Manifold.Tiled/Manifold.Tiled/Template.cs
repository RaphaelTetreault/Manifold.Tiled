using System.Xml;

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



        public static Template FromXmlNode(XmlNode? templateNode)
        {
            string tag = "template";
            if (templateNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (templateNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{templateNode.Name}' is not of type '{tag}'.");
            if (templateNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var template = new Template();
            template.Tileset = Tileset.FromXml(templateNode.InnerXml, "point").GetOnlyValueOrNull();
            template.Object = Object.FromXml(templateNode.InnerXml, "point").GetOnlyValueOrNull();

            return template;
        }

        public static Template[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static Template[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
