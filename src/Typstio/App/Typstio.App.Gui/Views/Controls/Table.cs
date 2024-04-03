using System.Windows;
using System.Windows.Controls;
using Typstio.App.Gui.Data;
using Typstio.App.Gui.Services;
using Typstio.Core.Contracts;
using Typstio.Core.Extensions;
using Typstio.Core.Models;
using DataRow = System.Data.DataRow;

namespace Typstio.App.Gui.Views.Controls;

public class Table : Grid, IContentWritable, IDataBindable
{
    IData? _data;
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
            var column = data.Data.Columns[i];
            
            ColumnDefinitions.Add(new ColumnDefinition());
        
            var header = ControlsFactory.Text();
            header.Text = column.ColumnName;
            
            SetColumn(header, i);
            
            Children.Add(header);
        }
    }
    
    public void WriteToContent(ContentWriter writer)
    {
        if (_data is null)
            throw new InvalidOperationException("Data not bound");

        var contents = new List<Content>();

        // Headers
        foreach (UIElement child in Children)
        {
            if (child is IContentWritable writable)
                contents.Add(writable.WriteToContent);
        }

        // Data
        foreach (var data in _data.Data!.Rows)
        {
            if (data is not DataRow row)
            {
                continue;
            }

            for (var i = 0; i < row.ItemArray.Length; i++)
            {
                var content = row[i].ToString()!;
                contents.Add(c => c.WriteString(content));
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