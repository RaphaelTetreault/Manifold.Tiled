﻿using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// A group layer, used to organize the layers of the map in a hierarchy.
    /// Its attributes offsetx, offsety, opacity, visible and tintcolor recursively affect child layers.
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#group"/>
    /// for more information.
    /// </remarks>
    public class Group :
        INamed,
        IUniquelyIdentifiable
    {
        /// <summary>
        /// Unique ID of the layer.
        /// </summary>
        /// <remarks>
        /// Defaults to 0.
        /// Valid IDs are at least 1.
        /// </remarks>
        public int ID { get; set; } = 0;

        /// <summary>
        /// The name of the image layer.
        /// </summary>
        /// <remarks>
        /// Defaults to “”.
        /// </remarks>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Horizontal offset of the group layer in pixels.
        /// </summary>
        public int OffsetX { get; set; } = 0;

        /// <summary>
        /// Vertical offset of the group layer in pixels.
        /// </summary>
        public int OffsetY { get; set; } = 0;

        /// <summary>
        /// Whether the layer is shown (1) or hidden (0).
        /// </summary>
        public IntBool Visible { get; set; } = 1;

        /// <summary>
        /// A color that is multiplied with the image drawn by this layer.
        /// </summary>
        public Color? TintColor { get; set; } = null;



        public TiledCollection<Layer> Layers { get; set; } = new TiledCollection<Layer>();

        public bool IsVisible
        {
            get => Visible;
            set => Visible = value;
        }

        /// <summary>
        /// Whether or not this group has a tint color.
        /// </summary>
        public bool HasTintColor => TintColor != null;




        public static Group FromXmlNode(XmlNode? groupNode)
        {
            string tag = "group";
            if (groupNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (groupNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{groupNode.Name}' is not of type '{tag}'.");
            if (groupNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var group = new Group();
            group.ID = groupNode.Attributes["id"].ErrorOrParseValue(int.Parse);
            group.Name = groupNode.Attributes["name"].ErrorOrValue();
            group.OffsetX = groupNode.Attributes["offsetx"].DefaultOrParseValue(int.Parse);
            group.OffsetY = groupNode.Attributes["offsety"].DefaultOrParseValue(int.Parse);
            group.Visible = groupNode.Attributes["visible"].DefaultOrParseValue(int.Parse, 1);
            group.TintColor = groupNode.Attributes["tintcolor"].NullOrParseValue(Color.FromHexARGB);
            //
            var hasXml = !string.IsNullOrEmpty(groupNode.InnerXml);
            if (hasXml)
            {
                group.Layers.AddRange(Layer.FromXml(groupNode.InnerXml, $"layer"));
            }

            return group;
        }

        public static Group[] FromXmlDocument(XmlDocument document, string xpath)
            => TiledParser.FromXmlDocument(document, xpath, FromXmlNode);

        public static Group[] FromXml(string xml, string xpath)
            => TiledParser.FromXml(xml, xpath, FromXmlNode);
    }
}
