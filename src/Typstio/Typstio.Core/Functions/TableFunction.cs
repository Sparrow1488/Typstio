using System.Text;
using Typstio.Core.Contracts;
using Typstio.Core.Elements;

namespace Typstio.Core.Functions;

public class TableFunction : Function
{
    private readonly Table _table;

    public TableFunction(Table table)
    {
        _table = table;
    }

    public override void Append(object? context, StringBuilder builder)
    {
        var columns = _table.Columns.Count();

        builder.AppendLine(Tokens.Function + "table(");
        builder.AppendLine(Tokens.Tab + "columns: " + columns + ",");
        builder.AppendLine(Tokens.Tab + string.Concat(_table.Columns.Select(x => InQuotes(x) + ", ")));
        
        foreach (var dataItem in _table.Data)
        {
            var valuesInline = Tokens.Tab + string.Concat(_table.Columns.Select(c => InQuotes(dataItem[c]) + ", "));
            builder.AppendLine(valuesInline);
        }

        builder.AppendLine(")");
    }

    private static string InQuotes(object? text) => $"\"{text}\"";
}