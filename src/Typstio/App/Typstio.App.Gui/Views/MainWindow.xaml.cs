using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Typstio.App.Gui.Services;
using Typstio.Core;

namespace Typstio.App.Gui.Views;

public partial class MainWindow
{
    double _scale = 1.0;

    public MainWindow()
    {
        InitializeComponent();
        ScrollDragger.Subscribe(MainGrid, GridViewer);
    }

    void ClickMenuItem(object sender, RoutedEventArgs e)
    {
        PaperControl.Body.Children.Add(
            CreateElementByName(
                ((MenuItem)sender).Header.ToString()!
            )
        );
    }

    static UIElement CreateElementByName(string elementName)
    {
        UIElement? element = elementName switch
        {
            "Заголовок" => ControlsFactory.Header(1),
            "Текст" => ControlsFactory.Text(),
            _ => null
        };

        return element!;
    }

    void OnMainGridMouseWheel(object sender, MouseWheelEventArgs e)
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

    void ParseDocument(object sender, RoutedEventArgs e)
    {
        // var document = DocumentParser.ReadDocument(PaperControl.Body.Children);
        // MessageBox.Show(CodeGenerator.ToCode(document));
    }
}