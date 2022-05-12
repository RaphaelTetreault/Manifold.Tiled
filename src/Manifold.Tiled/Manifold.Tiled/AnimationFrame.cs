using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// One frame of animation. Tiled calls this 'frame'.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#frame"/>
    /// for more information.
    /// </remarks>
    public struct AnimationFrame
    {
        /// <summary>
        /// The local ID of a tile within the parent tileset.
        /// </summary>
        public int TileID { get; set; }

        /// <summary>
        /// How long (in milliseconds) this frame should be displayed before advancing to the next frame.
        /// </summary>
        public int Duration { get; set; }



        public static AnimationFrame FromXmlNode(XmlNode? frameNode)
        {
            string tag = "frame";
            if (frameNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (frameNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{frameNode.Name}' is not of type '{tag}'.");
            if (frameNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var frame = new AnimationFrame();
            // Values
            frame.TileID = frameNode.Attributes["tileid"].ErrorOrParseValue(int.Parse);
            frame.Duration = frameNode.Attributes["duration"].ErrorOrParseValue(int.Parse);

            return frame;
        }

        public static AnimationFrame[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static AnimationFrame[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
