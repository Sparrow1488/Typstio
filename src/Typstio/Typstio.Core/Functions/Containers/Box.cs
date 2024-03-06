using Typstio.Core.Extensions;
using Typstio.Core.Functions.Colors;
using Typstio.Core.Models;

namespace Typstio.Core.Functions.Containers;

public class Box : TypstFunction
{
    public Box(Content content, ColorFunction? color = null, string? width = null, string? height = null, string? inset = null) : base("box")
    {
        Builder.Argument("width", width);
        Builder.Argument("height", height);
        Builder.Argument("inset", inset);
        Builder.ArgumentFunc("stroke", color);
        Builder.Content(content);
    }
}