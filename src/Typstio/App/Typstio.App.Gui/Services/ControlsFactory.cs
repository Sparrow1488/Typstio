using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Typstio.App.Gui.Views.Controls;
using Typstio.App.Gui.Views.Controls.Content;
using ResourceKey = Typstio.App.Gui.ResourceKey;
using Table = Typstio.App.Gui.Views.Controls.Content.Table;

namespace Typstio.App.Gui.Services;

public static class ControlsFactory
{
    static readonly FontSizeConverter FontSizeConverter = new();
    static Visual? _highlightLayer;
    static Adorner? _adorner;
    static ResourceDictionary Resources => Application.Current.Resources;

    public static void SetHighlightLayer(Visual layer)
    {
        _highlightLayer = layer;
    }
    
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
    
    public static Table Table()
    {
        return AttachSubs(new Table());
    }

    static T AttachSubs<T>(T element) where T : FrameworkElement
    {
        element.PreviewMouseDown += OnMouseDown;
        return element;
    }

    static void OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        // MessageBox.Show(sender.ToString());
        
        if (_highlightLayer is null) return;

        var layer = AdornerLayer.GetAdornerLayer(_highlightLayer)!;

        if (_adorner is not null)
        {
            layer.Remove(_adorner);
            _adorner = null;
        }
        
        layer.Add(_adorner ??= new Highlight((UIElement)sender));
    }
}