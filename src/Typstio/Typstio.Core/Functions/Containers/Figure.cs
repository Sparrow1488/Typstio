using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Containers;

public class Figure : TypstFunction
{
    public Figure(Content content, Content caption) : base("figure")
    {
        Argument("caption", caption);
        Content(content);
    }
}