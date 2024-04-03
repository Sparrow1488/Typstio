using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Win32;
using Typstio.App.Gui.Data;
using Typstio.App.Gui.Services;
using Typstio.Core.Services;

namespace Typstio.App.Gui.Views;

public partial class TypstioWindow
{
    readonly TypstCompiler _compiler = new();
    readonly List<IDataSource> _dataSources = new();

    public TypstioWindow()
    {
        InitializeComponent();
    }

    static int DocFontSize => 14;
    static string DocFontFamily => "Atkinson Hyperlegible";

    async void OnContextMenuClick(object sender, RoutedEventArgs e)
    {
        if (sender is not MenuItem item || string.IsNullOrWhiteSpace(item.Tag?.ToString())) 
            return;

        FrameworkElement element = item.Tag switch
        {
            ElemTag.Header => ControlsFactory.Header(1),
            ElemTag.Table => ControlsFactory.Table(),
            _ => throw new NotImplementedException()
        };

        if (element is IDataBindable bindable && _dataSources.Count != 0)
        {
            // Пока прикрепляю данные таким образом. Потом будет возможность выбора через UI
            
            var source = _dataSources.Last();
            var data = await source.ProvideAsync();
            
            await data.LoadAsync();
            bindable.Bind(data);
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
    
    void OnAttachDataFileClick(object sender, RoutedEventArgs e)
    {
        if (sender is not MenuItem {Tag: DataProvideTag.JsonFile}) return;

        var dialog = new OpenFileDialog
        {
            Filter = "Json file |*.json",
            FilterIndex = 1,
            Multiselect = false
        };

        if (dialog.ShowDialog() is not true)
        {
            return;
        }
        
        var source = new JsonDataSource(dialog.FileName);
        _dataSources.Add(source);
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

internal enum ElemTag
{
    Header,
    Table
}

internal enum DataProvideTag
{
    JsonFile
}