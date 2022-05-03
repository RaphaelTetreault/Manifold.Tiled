using System.Xml;

namespace Manifold.Tiled
{
    /// <summary>
    /// A property which can take the forma of varies types of variables. 
    /// </summary>
    /// <remarks>
    /// See <see href="https://doc.mapeditor.org/en/stable/reference/tmx-map-format/#property"/>
    /// for more information.
    /// </remarks>
    public class Property :
        INamed
    {
        /// <summary>
        /// The name of the property.
        /// </summary>
        /// <remarks>
        /// Defaults to “”.
        /// </remarks>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The type of the property.
        /// </summary>
        public PropertyType Type { get; set; } = Tiled.PropertyType.Default;

        /// <summary>
        /// The name of the custom property type, when applicable
        /// </summary>
        public string? PropertyType { get; set; } = string.Empty;

        /// <summary>
        /// The value of the property.
        /// </summary>
        /// <remarks>
        /// Default string is “”.
        /// Default number is 0.
        /// Default boolean is “false”.
        /// Default color is #00000000.
        /// Default file is “.” (the current file’s parent directory).
        /// </remarks>
        public string Value { get; set; } = string.Empty;


        /// <summary>
        /// The property value as a string.
        /// </summary>
        public string StringValue => Value;

        /// <summary>
        /// The property value parsed as an integer.
        /// </summary>
        public int IntValue => int.Parse(Value);

        /// <summary>
        /// The property value parsed as a float.
        /// </summary>
        public float FloatValue => float.Parse(Value);

        /// <summary>
        /// The property value parsed as a boolean.
        /// </summary>
        public bool BoolValue => bool.Parse(Value);

        /// <summary>
        /// The property value parsed as a color value in AARRGGBB format.
        /// </summary>
        public Color ColorValue => Color.FromHexARGB(Value);

        /// <summary>
        /// The property value as a File path. Can be a local file path.
        /// </summary>
        public string FileValue => Value;

        /// <summary>
        /// The property value as a full File path.
        /// </summary>
        public string FullFilePathValue => Path.GetFullPath(Value);

        /// <summary>
        /// The property value parsed as an Object value.
        /// </summary>
        /// <remarks>
        /// Object properties can reference any object on the same map and are stored as an integer
        /// (the ID of the referenced object, or 0 when no object is referenced). When used on objects
        /// in the Tile Collision Editor, they can only refer to other objects on the same tile.
        /// </remarks>
        public int ObjectValue => int.Parse(Value);

        /// <summary>
        /// The property value parsed as a nested Properties value.
        /// </summary>
        /// <remarks>
        /// Class properties will have their member values stored in a nested <properties> element.
        /// Only the actually set members are saved. When no members have been set the properties
        /// element is left out entirely.
        /// </remarks>
        public Properties? Properties { get; set; } = null;

        public bool HasProperties => Properties != null;



        public static Property FromXmlNode(XmlDocument document, string xpath, XmlNode? propertyNode)
        {
            string tag = "property";
            if (propertyNode is null)
                throw new XmlNodeParseException("Node is null.");
            if (propertyNode.Name != tag)
                throw new XmlNodeParseException($"Node named '{propertyNode.Name}' is not of type '{tag}'.");
            if (propertyNode.Attributes is null)
                throw new XmlNodeParseException("Node.Attributes is null.");

            // Create new from XML
            var property = new Property();
            //
            property.Name = propertyNode.Attributes["name"].ErrorOrValue();
            property.Type = propertyNode.Attributes["type"].ErrorOrParseValue((string str) => Enum.Parse<PropertyType>(str, true));
            property.PropertyType = propertyNode.Attributes["propertytype"]?.Value;
            property.Value = propertyNode.Attributes["propertytype"].ErrorOrValue();
            //
            var hasXml = !string.IsNullOrEmpty(propertyNode.InnerXml);
            if (hasXml)
            {
                property.Properties = Properties.FromXml(propertyNode.InnerXml, "properties").GetOnlyValueOrNull();
            }
            return property;
        }

        public static Property[] FromXmlNodes(XmlDocument document, string xpath)
            => TiledXmlExtensions.FromXmlNodes(document, xpath, FromXmlNode);

        public static Property[] FromXml(string xml, string xpath)
            => TiledXmlExtensions.FromXml(xml, xpath, FromXmlNode);
    }
}
