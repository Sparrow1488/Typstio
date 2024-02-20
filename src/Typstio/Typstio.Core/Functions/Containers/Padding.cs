using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Containers;

public class Padding : TypstFunction
{
    public Padding(Content content, string? top = null, string? right = null, string? bottom = null, string? left = null) : base("pad")
    {
        Argument("top", top);
        Argument("right", right);
        Argument("bottom", bottom);
        Argument("left", left);
        
        Content(content);
    }
}