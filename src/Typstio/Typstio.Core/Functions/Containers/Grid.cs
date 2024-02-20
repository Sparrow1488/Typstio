using Typstio.Core.Contracts;
using Typstio.Core.Foundations;
using Typstio.Core.Helpful;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Containers;

public class Grid : TypstFunction
{
    public Grid(IEnumerable<Content> contents, IEnumerable<string>? columns = null, IEnumerable<string>? rows = null) : base("grid")
    {
        if (columns is not null)
            Argument("columns", new Arr(columns));
        if (rows is not null)
            Argument("rows", new Arr(rows));
        
        Content(contents);
    }

    public Grid(IEnumerable<Content> contents, STuple<string>? columns = null, STuple<string>? rows = null) : this(contents, columns?.ToArray<string>(), rows?.ToArray<string>())
    {
    }
}