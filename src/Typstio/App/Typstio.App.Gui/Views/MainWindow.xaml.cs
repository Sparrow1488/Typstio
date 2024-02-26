using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Typstio.App.Gui.Services;

namespace Typstio.App.Gui.Views;

public partial class MainWindow
{
    private double _scale = 1.0;
    private readonly IDisposable _scrollSub;
    private readonly FontSizeConverter _fontSizeConverter;

    public MainWindow()
    {
        InitializeComponent();
        _scrollSub = ScrollDragger.Subscribe(MainGrid, GridViewer);
        _fontSizeConverter = new FontSizeConverter();
    }

    private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        var body = PaperControl.Body;
        
        UIElement? element = null;
        
        if (sender is MenuItem menuItem && (string) menuItem.Header == "Заголовок")
        {
            element = new TextBlock(new Run("Заголовок"))
            {
                FontWeight = FontWeights.SemiBold,
                FontSize = (double) _fontSizeConverter.ConvertFrom("26pt")!
            };
        }
        if (sender is MenuItem menuItem2 && (string) menuItem2.Header == "Текст")
        {
            element = new TextBlock(new Run("Просто текст"))
            {
                FontSize = FontSize = (double) _fontSizeConverter.ConvertFrom("14pt")!
            };
        }
        
        if (element is not null)
            body.Children.Add(element);
    }

    private void MainGrid_OnMouseWheel(object sender, MouseWheelEventArgs e)
    {
        if (e.Delta < 0)
        {
            _scale -= 0.05;
            MainGrid.LayoutTransform = new ScaleTransform(_scale, _scale);
        }               
        else if (e.Delta > 0)
        {
            _scale += 0.05;
            MainGrid.LayoutTransform = new ScaleTransform(_scale, _scale);
        }

        e.Handled = true;
    }
}