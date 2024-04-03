using System.Windows;
using System.Windows.Controls;
using Typstio.Core.Contracts;
using Typstio.Core.Functions.Text;
using Typstio.Core.Models;

namespace Typstio.App.Gui.Documents;

public static class DocumentParser
{
    public static ContentWriter ReadDocument(UIElementCollection elements, DocumentInfo info)
    {
        var document = new ContentWriter();

        document.SetRuleLine(new TextRule(info.FontFamily, info.FontSize + "pt", info.Language));
        document.WriteBlock();
        
        foreach (UIElement element in elements)
        {
            if (element is IContentWritable writable)
                writable.WriteToContent(document);
            else throw new NotImplementedException();

            document.WriteBlock();
        }

        return document;
    }
}