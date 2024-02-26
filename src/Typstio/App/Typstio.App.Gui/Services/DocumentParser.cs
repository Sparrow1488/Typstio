using System.Windows;
using Typstio.App.Gui.Views;
using Typstio.Core.Contracts;
using Typstio.Core.Models;

namespace Typstio.App.Gui.Services;

public static class DocumentParser
{
    public static ContentWriter ReadDocument(Paper paper)
    {
        var document = new ContentWriter();
        
        foreach (UIElement element in paper.Body.Children)
        {
            if (element is IContentWritable writable)
                writable.WriteToContent(document);
            else throw new InvalidOperationException();

            document.WriteEmptyBlock();
        }

        return document;
    }
}