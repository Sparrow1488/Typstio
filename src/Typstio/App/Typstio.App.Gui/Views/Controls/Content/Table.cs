using System.Data;
using System.Windows;
using System.Windows.Controls;
using Typstio.App.Gui.Contracts;
using Typstio.App.Gui.Data;
using Typstio.App.Gui.Services;
using Typstio.Core.Contracts;
using Typstio.Core.Extensions;
using Typstio.Core.Models;
using DataRow = System.Data.DataRow;

namespace Typstio.App.Gui.Views.Controls.Content;

public class Table : Grid, IContentWritable, IDataBindable
{
    IData? _data;
    UIElement[]? _headers;
    UIElement[]? _rowTemplate;

    public string? Inset { get; set; }
    public string? Align { get; set; }

    public void Bind(IData data)
    {
        _data = data;

        if (!data.IsLoaded || data.Data is null)
        {
            throw new Exception();
        }
        
        RowDefinitions.Clear();
        ColumnDefinitions.Clear();
        
        RowDefinitions.Add(new RowDefinition());

        for (var i = 0; i < data.Data.Columns.Count; i++)
        {
            ColumnDefinitions.Add(new ColumnDefinition());
        }
        
        var headersList = data.Data.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();

        _headers = headersList.Select(ContentFactory).ToArray();
        _rowTemplate = headersList.Select(h => ContentFactory($"[{h}]")).ToArray();

        WriteRow(_headers);
        WriteRow(_rowTemplate);

        UIElement ContentFactory(string text)
        {
            var header = ControlsFactory.Text();
            header.Text = text;

            return header;
        }
    }

    void WriteRow(IReadOnlyList<UIElement> contents)
    {
        RowDefinitions.Add(new RowDefinition());
        
        for (var i = 0; i < contents.Count; i++)
        {
            var content = contents[i];

            SetRow(content, RowDefinitions.Count - 1);
            SetColumn(content, i);
            
            Children.Add(content);
        }
    }
    
    public void WriteToContent(ContentWriter writer)
    {
        if (_data?.Data is null)
            throw new InvalidOperationException("Data not bound");
        
        if (_headers is null)
            throw new ArgumentException("Headers is null");
        
        if (_rowTemplate is null)
            throw new ArgumentException("Row template is null");

        var contents = new List<Core.Models.Content>();

        // Headers
        foreach (var child in _headers)
        {
            if (child is IContentWritable writable)
                contents.Add(writable.WriteToContent);
        }

        var rows = _data.Data.Rows.Cast<DataRow>().ToArray();

        // Data
        foreach (var data in rows)
        {
            foreach (var template in _rowTemplate)
            {
                if (template is IProvideFieldName provider && provider.GetFieldName() is string field)
                {
                    var content = data[field].ToString() ?? string.Empty;
                    contents.Add(c => c.WriteString(content));
                }
                else if (template is IContentWritable writable)
                {
                    contents.Add(c => writable.WriteToContent(c));
                }
            }
        }

        writer.Write(new Core.Functions.Containers.Table(
            Enumerable.Range(0, _data.Data.Columns.Count).Select(_ => "1fr"), 
            contents, 
            Inset, 
            Align
        ));
    }
}