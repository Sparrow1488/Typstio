using System.Windows;
using System.Windows.Controls;

namespace Typstio.App.Gui.Views;

public class Paper : UserControl
{
    public Paper()
    {
        Content = new StackPanel();
        Padding = new Thickness(50, 40, 50, 50);
    }

    public StackPanel Body => (StackPanel) Content;
}