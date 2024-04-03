using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Typstio.App.Gui.Data;
using Typstio.App.Gui.Services;
using Typstio.Core.Services;

namespace Typstio.App.Gui.Views;

public partial class TypstioWindow
{
    readonly TypstCompiler _compiler;

    public TypstioWindow()
    {
        InitializeComponent();

        _compiler = new TypstCompiler();
    }

    static int DocFontSize => 14;
    static string DocFontFamily => "Atkinson Hyperlegible";

    async void OnContextMenuClick(object sender, RoutedEventArgs e)
    {
        if (sender is not MenuItem item || string.IsNullOrWhiteSpace(item?.Tag?.ToString())) 
            return;

        FrameworkElement element = item.Tag.ToString() switch
        {
            ElKeys.Header => ControlsFactory.Header(1),
            ElKeys.Table => ControlsFactory.Table(),
            _ => throw new NotImplementedException()
        };

        if (element is IDataBindable bindable)
        {
            bindable.Bind(await GetDataAsync());
        }

        Dispatcher.Invoke(() =>
        {
            ReportPanel.Children.Add(element);
            UpdateChildren(ReportPanel.Children);
        });
    }

    static void UpdateChildren(UIElementCollection collection)
    {
        foreach (UIElement elem in collection)
        {
            TextElement.SetFontFamily(elem, new FontFamily(DocFontFamily));
        }
    }

    static async Task<IData> GetDataAsync()
    {
        var json = new JsonData(await File.ReadAllTextAsync("./wwwroot/users.json"));
        await json.LoadAsync();

        return json;
    }

    async void CompileReport(object sender, RoutedEventArgs e)
    {
        const string output = "./output.pdf";

        var info = new DocumentInfo
        {
            FontFamily = DocFontFamily,
            FontSize = DocFontSize
        };
        
        var document = DocumentParser.ReadDocument(ReportPanel.Children, info);
        await _compiler.PdfAsync(document, "code.txt", output);

        // Show result in browser
        Process.Start("explorer", Path.GetFullPath(output));
    }
}

internal static class ElKeys
{
    public const string Header = "el.header";
    public const string Table = "el.table";
}