using System.Xml;

namespace Manifold.Tiled
{
    public static class TiledXmlExtensions
    {
        //public static string SafeValue(this XmlAttribute? attr, string ifNullValue)
        //{
        //    if (attr is null)
        //        return ifNullValue;
        //    else
        //        return attr.Value;
        //}

        public static string ErrorOrValue(this XmlAttribute? attr)
        {
            if (attr is null)
                throw new NullReferenceException("XML Atrtibute is null.");
            else
                return attr.Value;
        }

        //public static T SafeParseValue<T>(this XmlAttribute? attr, Func<string, T> parseFunction, T ifNullValue)
        //{
        //    if (attr is null)
        //        return ifNullValue;
        //    else
        //        return parseFunction.Invoke(attr.Value);
        //}

        public static T DefaultOrParseValue<T>(this XmlAttribute? attr, Func<string, T> parseFunction, T @default)
        {
            if (attr is null)
                return @default;
            else
                return parseFunction.Invoke(attr.Value);
        }

        public static T ErrorOrParseValue<T>(this XmlAttribute? attr, Func<string, T> parseFunction)
        {
            if (attr is null)
                throw new NullReferenceException("XML Atrtibute is null.");
            else
                return parseFunction.Invoke(attr.Value);
        }

        public static T? NullOrParseValue<T>(this XmlAttribute? attr, Func<string, T> parseFunction)
        {
            if (attr is null)
                return default(T);
            else
                return parseFunction.Invoke(attr.Value);
        }







        public delegate T FromXmlNodeFunc<T>(XmlDocument xml, string xpath, XmlNode? node);

        public static T[] FromXmlNodes<T>(XmlDocument xml, string xpath, FromXmlNodeFunc<T> function)
        {
            var nodes = xml.SelectNodes(xpath);
            var values = new T[nodes.Count];
            for (int i = 0; i < values.Length; i++)
            {
                var tilesetNode = nodes[i];
                values[i] = function(xml, xpath, tilesetNode);
            }
            return values;
        }

        public static T[] FromXml<T>(string xml, string xpath, FromXmlNodeFunc<T> function)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);

            var node = document.SelectNodes(xpath);
            var values = FromXmlNodes(document, xpath, function);

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
