using System.Windows;
using System.Windows.Controls;
using Typstio.App.Gui.Services;
using Typstio.Core.Contracts;
using Typstio.Core.Extensions;
using Typstio.Core.Models;

namespace Typstio.App.Gui.Views.Controls;

public class Table : Grid, IContentWritable, IDataBindable
{
    private IEnumerable<IData>? _data;
    private DataTemplate? _template;
    public string? Inset { get; set; }
    public string? Align { get; set; }

    public void Bind(DataTemplate template, IEnumerable<IData> data)
    {
        _data = data;
        _template = template;
        
        RowDefinitions.Clear();
        ColumnDefinitions.Clear();
        
        RowDefinitions.Add(new RowDefinition());

        for (var i = 0; i < template.Fields.Count; i++)
        {
            var field = template.Fields[i];
            
            ColumnDefinitions.Add(new ColumnDefinition());

            var header = ControlsFactory.Text();
            header.Text = field;
            
            SetColumn(header, i);
            
            Children.Add(header);
        }
    }
    
    public void WriteToContent(ContentWriter writer)
    {
        if (_template is null || _data is null)
            throw new InvalidOperationException("Data not bound");

        var contents = new List<Content>();

        // Headers
        foreach (UIElement child in Children)
        {
            if (child is IContentWritable writable)
                contents.Add(writable.WriteToContent);
        }

        // Data
        foreach (var data in _data)
        {
            if (data.Content is null)
                throw new InvalidOperationException("Data not load");
            
            foreach (var field in data.Content)
                contents.Add(c => c.WriteString(field.Value.ToString()!));
        }

        writer.Write(new Core.Functions.Containers.Table(
            _template.Fields.Select(_ => "1fr"), 
            contents, 
            Inset, 
            Align
        ));
    }
}