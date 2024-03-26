using Typstio.Core.Extensions;
using Typstio.Core.Foundations;
using Typstio.Core.Models;

namespace Typstio.Core.Functions.Containers;

public class Grid : TypstFunction
{
    public Grid(IEnumerable<Content> contents, IEnumerable<string>? columns = null, IEnumerable<string>? rows = null) : base("grid")
    {
        if (columns is not null)
            Builder.Argument("columns", new Arr(columns));
        if (rows is not null)
            Builder.Argument("rows", new Arr(rows));
        
        Builder.Content(contents);
    }

    public Grid(IEnumerable<Content> contents, ArrTuple<string>? columns = null, ArrTuple<string>? rows = null) : this(contents, columns?.ToArray<string>(), rows?.ToArray<string>())
    {
    }
}