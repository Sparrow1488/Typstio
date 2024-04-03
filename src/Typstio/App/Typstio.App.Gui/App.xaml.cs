using ResourceKey = Typstio.App.Gui.Defaults.ResourceKey;

namespace Typstio.App.Gui;

public partial class App
{
    public App()
    {
        Resources[ResourceKey.Heading1Size] = "26pt";
        Resources[ResourceKey.Heading2Size] = "23pt";
        Resources[ResourceKey.Heading3Size] = "20pt";
        Resources[ResourceKey.Text] = "14pt";
    }
}