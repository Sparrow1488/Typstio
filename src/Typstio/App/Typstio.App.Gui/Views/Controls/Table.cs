using System.Windows.Controls;
using Typstio.Core.Contracts;
using Typstio.Core.Models;

namespace Typstio.App.Gui.Views.Controls;

public class Table : DataGrid, IContentWritable
{
    public string? Inset { get; set; }
    public string? Align { get; set; }
    
    public void WriteToContent(ContentWriter writer)
    {
        var c = Columns;
    }
}