using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Figure : Function
{
    public Figure(Action<ContentWriter> content, Action<ContentWriter> caption) : base("figure")
    {
        Argument("caption", caption);
        Content(content);
    }
}