namespace Manifold.Tiled
{
    internal class TiledEnumUtility
    {
        /// <summary>
        /// Parse an enum while ignoring case.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEnum Parse<TEnum>(string value)
            where TEnum : struct, Enum
        {
            var result = Enum.Parse<TEnum>(value, true);
            return result;
        }

        /// <summary>
        /// Parse and enum while ignoring case. Converts all dash '-' to underscore '_'.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEnum ParseDashed<TEnum>(string value)
            where TEnum : struct, Enum
        {
            value = value.Replace("-", "_");
            var result = Enum.Parse<TEnum>(value, true);
            return result;
        }
    }
}
