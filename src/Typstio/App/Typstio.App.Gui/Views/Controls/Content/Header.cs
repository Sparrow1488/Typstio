using System.Windows.Controls;
using Typstio.Core.Contracts;
using Typstio.Core.Extensions;
using Typstio.Core.Functions.Text;
using Typstio.Core.Models;

namespace Typstio.App.Gui.Views.Controls.Content;

public class Header : TextBox, IContentWritable
{
    public int Level { get; set; }
    
    public void WriteToContent(ContentWriter writer)
    {
        writer.Write(new Heading(Level, Text));
    }
}