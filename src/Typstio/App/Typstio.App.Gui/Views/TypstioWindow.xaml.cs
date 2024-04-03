using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Typstio.App.Gui.Contracts;
using Typstio.App.Gui.Documents;
using Typstio.App.Gui.Events;
using Typstio.App.Gui.Services;
using Typstio.Core.Contracts;

namespace Typstio.App.Gui.Views;

public partial class TypstioWindow
{
    readonly DocumentResources _resources;

    public TypstioWindow(IEventAggregator events, IReport report, DocumentResources resources)
    {
        _resources = resources;
        
        InitializeComponent();

        events.GetEvent<ReportAppendElementEvent>().Subscribe(OnAppendElement);

        if (report is UIReport uiReport)
            uiReport.Collection = ReportPanel.Children;
        
        ControlsFactory.SetHighlightLayer(MainGrid);
    }

    void OnAppendElement(IContentWritable element)
    {
        if (element is not UIElement uiElement)
        {
            throw new Exception("Report element should be assign to UIElement");
        }
        
        ReportPanel.Children.Add(uiElement);
        UpdateChildren(ReportPanel.Children);
    }

    void UpdateChildren(UIElementCollection collection)
    {
        foreach (UIElement elem in collection)
        {
            TextElement.SetFontFamily(elem, new FontFamily(_resources.DocFontFamily));
        }
    }
}

internal enum ElemTag
{
    Header,
    Table
}