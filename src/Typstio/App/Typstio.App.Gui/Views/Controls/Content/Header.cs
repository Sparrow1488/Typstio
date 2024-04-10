using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Typstio.Core.Contracts;
using Typstio.Core.Extensions;
using Typstio.Core.Functions.Text;
using Typstio.Core.Models;

namespace Typstio.App.Gui.Views.Controls.Content;

public class Header : TextBox, IContentWritable
{
    public Header()
    {
        Background = Brushes.Transparent;
        BorderBrush = Brushes.Transparent;
        BorderThickness = new Thickness(0);
    }
    
    public int Level { get; set; }
    
    public void WriteToContent(ContentWriter writer)
    {
        writer.Write(new Heading(Level, Text));
    }
}