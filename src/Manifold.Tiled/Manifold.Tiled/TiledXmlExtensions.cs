using System.Xml;

namespace Manifold.Tiled
{
    public static class TiledXmlExtensions
    {
        public static string SafeValue(this XmlAttribute? attr, string ifNullValue)
        {
            if (attr is null)
                return ifNullValue;
            else
                return attr.Value;
        }

        public static string ValueOrError(this XmlAttribute? attr)
        {
            if (attr is null)
                throw new NullReferenceException("XML Atrtibute is null.");
            else
                return attr.Value;
        }

        public static T SafeParseValue<T>(this XmlAttribute? attr, Func<string, T> parseFunction, T ifNullValue)
        {
            if (attr is null)
                return ifNullValue;
            else
                return parseFunction.Invoke(attr.Value);
        }

        public static T ParseValueOrDefault<T>(this XmlAttribute? attr, Func<string, T> parseFunction, T @default)
        {
            if (attr is null)
                return @default;
            else
                return parseFunction.Invoke(attr.Value);
        }

        public static T ParseValueOrError<T>(this XmlAttribute? attr, Func<string, T> parseFunction)
        {
            if (attr is null)
                throw new NullReferenceException("XML Atrtibute is null.");
            else
                return parseFunction.Invoke(attr.Value);
        }

        public static T? ParseValueOrNull<T>(this XmlAttribute? attr, Func<string, T> parseFunction)
        {
            if (attr is null)
                return default(T);
            else
                return parseFunction.Invoke(attr.Value);
        }
    }
}
