namespace Manifold.Tiled
{
    public class Template
    {
        /*
            The template root element contains the saved map object and a tileset element that points to an external tileset, if the object is a tile object.

            Example of a template file:

            <?xml version="1.0" encoding="UTF-8"?>
            <template>
             <tileset firstgid="1" source="desert.tsx"/>
             <object name="cactus" gid="31" width="81" height="101"/>
            </template>

            Any tileset reference should always come before the object. Embedded tilesets are not supported.
            Can contain at most one: <tileset>
            Should contain exactly one: <object>
         */
    }
}
