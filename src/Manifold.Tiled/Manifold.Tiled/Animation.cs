using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// Contains a list of animation frames.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#animation"/>
    /// for more information.
    /// </remarks>
    public class Animation
    {
        /// <summary>
        /// All animation frames.
        /// </summary>
        public AnimationFrame[] Frames { get; set; } = new AnimationFrame[0];

        /// <summary>
        /// Whether or not this animation has frames.
        /// </summary>
        /// <remarks>
        /// The `Frames` array should always be initialized with size 0.
        /// </remarks>
        public bool HasFrames => Frames != null && Frames.Length > 0;


        public static Animation FromXmlNode(XmlNode? animationNode)
        {
            string tag = "animation";
            if (animationNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (animationNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{animationNode.Name}' is not of type '{tag}'.");
            if (animationNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var animation = new Animation();
            animation.Frames = AnimationFrame.FromXml(animationNode.InnerXml, "frame");

            return animation;
        }

        public static Animation[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static Animation[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
