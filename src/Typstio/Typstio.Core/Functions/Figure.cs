using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Figure : ElementFunction
{
    public Figure(Action<ContentWriter> content, Action<ContentWriter> caption) : base("figure")
    {
        Argument("caption", caption);
        Content(content);
    }
}