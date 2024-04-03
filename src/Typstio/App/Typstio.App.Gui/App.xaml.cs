using System.Windows;
using Typstio.App.Gui.Contracts;
using Typstio.App.Gui.Data;
using Typstio.App.Gui.Documents;
using Typstio.App.Gui.Services;
using Typstio.App.Gui.Views;
using ResourceKey = Typstio.App.Gui.ResourceKey;

namespace Typstio.App.Gui;

public partial class App
{
    public App()
    {
        Resources[ResourceKey.Heading1Size] = "22pt";
        Resources[ResourceKey.Heading2Size] = "20pt";
        Resources[ResourceKey.Heading3Size] = "18pt";
        Resources[ResourceKey.Text] = "14pt";
    }

    protected override void RegisterTypes(IContainerRegistry registry)
    {
        registry.RegisterSingleton<IReport, UIReport>();
        registry.RegisterSingleton<DocumentResources>();
        registry.RegisterSingleton<IDataSources, DataSources>();
    }

    protected override Window CreateShell() => Container.Resolve<TypstioWindow>();
}