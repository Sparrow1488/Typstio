using System.Windows.Controls;
using Typstio.Core.Contracts;
using Typstio.Core.Functions.Text;
using Typstio.Core.Models;

namespace Typstio.App.Gui.Views.Controls;

public class Header : TextBlock, IContentWritable
{
    public int Level { get; set; }
    
    public void WriteToContent(ContentWriter writer)
    {
        new Heading(Level, Text).WriteToContent(writer);
    }
}