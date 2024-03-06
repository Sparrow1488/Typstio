using Typstio.Core.Extensions;
using Typstio.Core.Models;

namespace Typstio.Core.Functions.Containers;

public class Padding : TypstFunction
{
    public Padding(Content content, string? top = null, string? right = null, string? bottom = null, string? left = null) : base("pad")
    {
        Builder.Argument("top", top);
        Builder.Argument("right", right);
        Builder.Argument("bottom", bottom);
        Builder.Argument("left", left);
        
        Builder.Content(content);
    }
}