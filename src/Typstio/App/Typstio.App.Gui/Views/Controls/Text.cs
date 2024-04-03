using System.Windows.Controls;
using Typstio.Core.Contracts;
using Typstio.Core.Models;

namespace Typstio.App.Gui.Views.Controls;

public class Text : TextBlock, IContentWritable
{
    public void WriteToContent(ContentWriter writer)
    {
        new Core.Functions.Text.Text(
            c => c.WriteString(Text)
        ).WriteToContent(writer);
    }
}