namespace Manifold.Tiled
{
    public class ImageLayer
    {
        /*
            id: Unique ID of the layer (defaults to 0, with valid IDs being at least 1). Each layer that added to a map gets a unique id. Even if a layer is deleted, no layer ever gets the same ID. Can not be changed in Tiled. (since Tiled 1.2)
            name: The name of the image layer. (defaults to “”)
            offsetx: Horizontal offset of the image layer in pixels. (defaults to 0) (since 0.15)
            offsety: Vertical offset of the image layer in pixels. (defaults to 0) (since 0.15)
            x: The x position of the image layer in pixels. (defaults to 0, deprecated since 0.15)
            y: The y position of the image layer in pixels. (defaults to 0, deprecated since 0.15)
            opacity: The opacity of the layer as a value from 0 to 1. (defaults to 1)
            visible: Whether the layer is shown (1) or hidden (0). (defaults to 1)
            tintcolor: A color that is multiplied with the image drawn by this layer in #AARRGGBB or #RRGGBB format (optional).
            repeatx: Whether the image drawn by this layer is repeated along the X axis. (since Tiled 1.8)
            repeaty: Whether the image drawn by this layer is repeated along the Y axis. (since Tiled 1.8)

            A layer consisting of a single image.
            Can contain at most one: <properties>, <image>
         */
    }
}
