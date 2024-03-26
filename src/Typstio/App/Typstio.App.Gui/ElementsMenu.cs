using System.Windows.Controls;

namespace Typstio.App.Gui;

public class ElementsMenu : ContextMenu
{
    public ElementsMenu()
    {
        ItemsSource = new[]
        {
            "Заголовок",
            
        };
    }
}