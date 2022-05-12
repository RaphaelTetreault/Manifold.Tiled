using System.Xml;

namespace Manifold.Tiled
{
    public static class TiledParser
    {

        public delegate T Parse<T>(string value);

        public static string ErrorOrValue(this XmlAttribute? attr)
        {
            if (attr is null)
                throw new NullReferenceException("XML Atrtibute is null.");
            else
                return attr.Value;
        }

        public static string DefaultOrValue(this XmlAttribute? attr, string @default)
        {
            if (attr is null)
                return @default;
            else
                return attr.Value;
        }

        public static T DefaultOrParseValue<T>(this XmlAttribute? attr, Parse<T> parse, T @default)
        {
            if (attr is null)
                return @default;
            else
                return parse.Invoke(attr.Value);
        }

        public static T? DefaultOrParseValue<T>(this XmlAttribute? attr, Parse<T?> parse)
        {
            return DefaultOrParseValue(attr, parse, default(T));
        }

        public static T ErrorOrParseValue<T>(this XmlAttribute? attr, Parse<T> parse)
        {
            if (attr is null)
                throw new NullReferenceException("XML Atrtibute is null.");
            else
                return parse.Invoke(attr.Value);
        }

        public static T? NullOrParseValue<T>(this XmlAttribute? attr, Parse<T> parse)
        {
            if (attr is null)
                return default(T);
            else
                return parse.Invoke(attr.Value);
        }



        public delegate T ParseNode<T>(XmlNode? node);

        public static T[] FromXmlNodes<T>(XmlDocument xml, string xpath, ParseNode<T> parseNode)
        {
            var nodes = xml.SelectNodes(xpath);
            var values = new T[nodes.Count];
            for (int i = 0; i < values.Length; i++)
            {
                var node = nodes[i];
                values[i] = parseNode(node);
            }
            return values;
        }

        public static T[] FromXml<T>(string xml, string xpath, ParseNode<T> parseNode)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);

            var node = document.SelectNodes(xpath);
            var values = FromXmlNodes(document, xpath, parseNode);

            return values;
        }



        public static T? GetOnlyValueOrNull<T>(this T[]? array)
        {
            if (array == null || array.Length == 0)
            {
                return default(T);
            }
            else if (array.Length != 1)
            {
                throw new ArgumentException("Array is not of size 1!");
            }
            else
            {
                return array[0];
            }
        }


    }
}
