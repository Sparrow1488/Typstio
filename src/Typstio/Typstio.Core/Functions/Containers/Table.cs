using Typstio.Core.Contracts;
using Typstio.Core.Foundations;
using Typstio.Core.Helpful;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Containers;

public class Table : TypstFunction
{
    public Table(IEnumerable<string> columns, IEnumerable<Content> contents, string? inset = null, string? align = null) : base("table")
    {
        Argument("columns", new Arr(columns));
        Argument("inset", inset);
        Argument("align", align);
        Content(contents);
    }

    public Table(STuple<string> columns, IEnumerable<Content> contents, string? inset = null, string? align = null) : this(columns.ToArray(), contents.ToArray(), inset, align)
    {
        
    }
}