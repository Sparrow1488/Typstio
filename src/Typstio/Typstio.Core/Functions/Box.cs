using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Box : TypstFunction
{
    public Box(Action<ContentWriter> content, Rgb color, string? width = null, string? height = null) : base("box")
    {
        Argument("width", width);
        Argument("height", height);
        ArgumentFunc("stroke", color);
        Content(content);
    }
}