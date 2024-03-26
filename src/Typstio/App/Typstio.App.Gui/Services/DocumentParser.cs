using System.Windows;
using System.Windows.Controls;
using Typstio.App.Gui.Views;
using Typstio.Core.Contracts;
using Typstio.Core.Models;

namespace Typstio.App.Gui.Services;

public static class DocumentParser
{
    public static ContentWriter ReadDocument(UIElementCollection elements)
    {
        var document = new ContentWriter();
        
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