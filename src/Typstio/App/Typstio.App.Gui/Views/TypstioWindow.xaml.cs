using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Typstio.App.Gui.Services;
using Typstio.App.Gui.Views.Controls;
using Typstio.Core;
using Typstio.Core.Functions.Containers;

namespace Typstio.App.Gui.Views;

public partial class TypstioWindow
{
    public TypstioWindow()
    {
        InitializeComponent();
    }

    private void OnContextMenuClick(object sender, RoutedEventArgs e)
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
            // Bind data template
            // Example
            var sample = GetSampleData();
            bindable.Bind(sample.Item1, sample.Item2);
        }

        ReportPanel.Children.Add(element);
    }

    private static (DataTemplate, IEnumerable<IData>) GetSampleData()
    {
        var data = new List<IData>();

        for (var i = 0; i < 10; i++)
        {
            data.Add(new MockData(new Dictionary<string, object>
            {
                {"ID", i},
                {"Name", "Andrey"},
                {"Phone", "+12345678910"}
            }));
        }
        
        return (new DataTemplate(new[] {"ID", "Name", "Phone"}), data);
    }

    private void LoadReport(object sender, RoutedEventArgs e)
    {
        var document = DocumentParser.ReadDocument(ReportPanel.Children);
        var code = CodeGenerator.ToCode(document);
        
        MessageBox.Show(code);
        Debug.WriteLine(code);
    }
}

internal static class ElKeys
{
    public const string Header = "el.header";
    public const string Table = "el.table";
}