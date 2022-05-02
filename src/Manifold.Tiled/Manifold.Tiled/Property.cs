namespace Manifold.Tiled
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// See <see href=""/>
    /// for more information.
    /// </remarks>
    public class Property
    {
        /*
            name: The name of the property.
            type: The type of the property. Can be string (default), int, float, bool, color, file, object or class (since 0.16, with color and file added in 0.17, object added in 1.4 and class added in 1.8).
            propertytype: The name of the custom property type, when applicable (since 1.8).
            value: The value of the property. (default string is “”, default number is 0, default boolean is “false”, default color is #00000000, default file is “.” (the current file’s parent directory))

            Boolean properties have a value of either “true” or “false”.
            Color properties are stored in the format #AARRGGBB.
            File properties are stored as paths relative from the location of the map file.
            Object properties can reference any object on the same map and are stored as an integer (the ID of the referenced object, or 0 when no object is referenced). When used on objects in the Tile Collision Editor, they can only refer to other objects on the same tile.
            Class properties will have their member values stored in a nested <properties> element. Only the actually set members are saved. When no members have been set the properties element is left out entirely.
            When a string property contains newlines, the current version of Tiled will write out the value as characters contained inside the property element rather than as the value attribute. It is possible that a future version of the TMX format will switch to always saving property values inside the element rather than as an attribute.
            Can contain at most one: <properties> (since 1.8)
         */
    }
}
