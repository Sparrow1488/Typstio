using Typstio.Core.Extensions;
using Typstio.Core.Foundations;
using Typstio.Core.Models;

namespace Typstio.Core.Functions.Containers;

public class Table : TypstFunction
{
    public Table(IEnumerable<string> columns, IEnumerable<Content> contents, string? inset = null, string? align = null) : base("table")
    {
        Builder.Argument("columns", new Arr(columns));
        Builder.Argument("inset", inset);
        Builder.Argument("align", align);
        Builder.Content(contents);
    }

    public Table(ArrTuple<string> columns, IEnumerable<Content> contents, string? inset = null, string? align = null) : this(columns.ToArray(), contents.ToArray(), inset, align)
    {
        
    }
}