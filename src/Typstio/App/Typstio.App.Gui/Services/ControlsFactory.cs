using System.Windows;
using System.Windows.Input;
using Typstio.App.Gui.Views.Controls;
using ResourceKey = Typstio.App.Gui.Defaults.ResourceKey;

namespace Typstio.App.Gui.Services;

public static class ControlsFactory
{
    private static readonly FontSizeConverter FontSizeConverter = new();
    private static ResourceDictionary Resources => Application.Current.Resources;
    
    public static Header Header(int level)
    {
        return AttachSubs(new Header
        {
            Text = "Заголовок",
            Level = level,
            FontWeight = FontWeights.SemiBold,
            FontSize = (double) FontSizeConverter.ConvertFrom(Resources[ResourceKey.Heading1Size])!
        });
    }

    public static Text Text()
    {
        return AttachSubs(new Text
        {
            Text = "Просто текст",
            FontSize = (double) FontSizeConverter.ConvertFrom(Resources[ResourceKey.Text])!
        });
    }

    private static T AttachSubs<T>(T element) where T : FrameworkElement
    {
        element.MouseDown += OnMouseDown;
        return element;
    }

    private static void OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show(sender.ToString());
    }
}