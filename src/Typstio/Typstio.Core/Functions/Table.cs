using Typstio.Core.Contracts;
using Typstio.Core.Types;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Table : TypstFunction
{
    public Table(IEnumerable<string> columns, IEnumerable<Action<ContentWriter>> contents, string? inset = null, string? align = null) : base("table")
    {
        Argument("columns", new Arr(columns));
        Argument("inset", inset);
        Argument("align", align);
        Content(contents);
    }
}