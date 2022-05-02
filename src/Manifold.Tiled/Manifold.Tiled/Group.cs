namespace Manifold.Tiled
{
    public class Group
    {
        /*
            id: Unique ID of the layer (defaults to 0, with valid IDs being at least 1). Each layer that added to a map gets a unique id. Even if a layer is deleted, no layer ever gets the same ID. Can not be changed in Tiled. (since Tiled 1.2)
            name: The name of the group layer. (defaults to “”)
            offsetx: Horizontal offset of the group layer in pixels. (defaults to 0)
            offsety: Vertical offset of the group layer in pixels. (defaults to 0)
            opacity: The opacity of the layer as a value from 0 to 1. (defaults to 1)
            visible: Whether the layer is shown (1) or hidden (0). (defaults to 1)
            tintcolor: A color that is multiplied with any graphics drawn by any child layers, in #AARRGGBB or #RRGGBB format (optional).
        
            A group layer, used to organize the layers of the map in a hierarchy. Its attributes offsetx, offsety, opacity, visible and tintcolor recursively affect child layers.
            Can contain at most one: <properties>
            Can contain any number: <layer>, <objectgroup>, <imagelayer>, <group>
         */
    }
}
