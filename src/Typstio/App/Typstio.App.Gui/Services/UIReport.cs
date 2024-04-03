using System.Windows.Controls;
using Typstio.App.Gui.Contracts;
using Typstio.App.Gui.Documents;
using Typstio.Core.Models;

namespace Typstio.App.Gui.Services;

// ReSharper disable file InconsistentNaming
public class UIReport : IReport
{
    readonly DocumentResources _resources;

    public UIReport(DocumentResources resources)
    {
        _resources = resources;
    }

    internal UIElementCollection? Collection { get; set; }
    public ContentWriter Content => ParseContent();

    ContentWriter ParseContent()
    {
        var info = new DocumentInfo
        {
            FontFamily = _resources.DocFontFamily,
            FontSize = _resources.DocFontSize
        };

        if (Collection is null)
        {
            throw new Exception("Collection of UIElements not set");
        }
        
        return DocumentParser.ReadDocument(Collection, info);
    }
}