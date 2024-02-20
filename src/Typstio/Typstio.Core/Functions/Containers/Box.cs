using Typstio.Core.Contracts;
using Typstio.Core.Functions.Colors;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Containers;

public class Box : TypstFunction
{
    public Box(Action<ContentWriter> content, ColorFunction? color = null, string? width = null, string? height = null, string? inset = null) : base("box")
    {
        Argument("width", width);
        Argument("height", height);
        Argument("inset", inset);
        ArgumentFunc("stroke", color);
        Content(content);
    }
}