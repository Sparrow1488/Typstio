using Typstio.Core.Contracts;

namespace Typstio.Core.Elements;

public class Table : Element
{
    public Table(IEnumerable<string> columns, IEnumerable<Dictionary<string, object>> data)
    {
        Columns = columns;
        Data = data;
    }

    public IEnumerable<string> Columns { get; }
    public IEnumerable<Dictionary<string, object>> Data { get; }
}