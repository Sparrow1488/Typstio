using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Box : ElementFunction
{
    public Box(Action<ContentWriter> content, string? width = null, string? height = null) : base("box")
    {
        Argument("width", width);
        Argument("height", height);
        // Argument("stroke", color); // TODO https://typst.app/docs/reference/visualize/color/
        Content(content);
    }
}