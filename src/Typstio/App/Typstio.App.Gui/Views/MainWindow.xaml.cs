using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Typstio.App.Gui.Services;
using Typstio.Core;

namespace Typstio.App.Gui.Views;

public partial class MainWindow
{
    private double _scale = 1.0;

    public MainWindow()
    {
        InitializeComponent();
        ScrollDragger.Subscribe(MainGrid, GridViewer);
    }

    private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        if (sender is not MenuItem menuItem) throw new Exception();

        var header = (string) menuItem.Header;
        var body = PaperControl.Body;

        UIElement? element = header switch
        {
            "Заголовок" => ControlsFactory.Header(1),
            "Текст" => ControlsFactory.Text(),
            "Таблица" => ControlsFactory.Table(),
            _ => null
        };

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

    private void ParseDocument(object sender, RoutedEventArgs e)
    {
        var document = DocumentParser.ReadDocument(PaperControl);
        MessageBox.Show(CodeGenerator.ToCode(document));
    }
}