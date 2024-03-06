using Typstio.Core.Contracts;
using Typstio.Core.Extensions;
using Typstio.Core.Functions.Colors;
using Typstio.Core.Models;

namespace Typstio.Core.Functions.Containers;

public abstract class BoxSignature : SignatureBase
{
    protected BoxSignature(ColorFunction? color, string? width, string? height, string? inset) : base("box")
    {
        Builder.Argument("width", width);
        Builder.Argument("height", height);
        Builder.Argument("inset", inset);
        Builder.ArgumentFunc("stroke", color);
    }
}

public class BoxRule : BoxSignature, ISetRule
{
    public BoxRule(ColorFunction? color = null, string? width = null, string? height = null, string? inset = null) : base(color, width, height, inset)
    {
    }
}

public class Box : BoxSignature, ITypstFunction
{
    public Box(Content content, ColorFunction? color = null, string? width = null, string? height = null, string? inset = null) : base(color, width, height, inset)
    {
        Builder.Content(content);
    }
}