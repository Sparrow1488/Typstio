using Typstio.Core.Contracts;
using Typstio.Core.Foundations;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Containers;

public class Grid : TypstFunction
{
    public Grid(IEnumerable<Action<ContentWriter>> contents, IEnumerable<string>? columns = null, IEnumerable<string>? rows = null) : base("grid")
    {
        if (columns is not null)
            Argument("columns", new Arr(columns));
        if (rows is not null)
            Argument("rows", new Arr(rows));
        
        Content(contents);
    }
}