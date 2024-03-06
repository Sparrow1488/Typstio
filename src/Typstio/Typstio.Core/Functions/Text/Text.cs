using Typstio.Core.Extensions;
using Typstio.Core.Foundations;
using Typstio.Core.Models;

namespace Typstio.Core.Functions.Text;

public abstract class TextSignature : SignatureBase
{
    protected TextSignature(string? font, string? size) : base("text")
    {
        Builder.Argument("font", new Str(font));
        Builder.Argument("size", size);
    }
}

public class TextRule : TextSignature, ISetRule
{
    public TextRule(string? font = null, string? size = null) : base(font, size)
    {
    }
}

public class Text : TextSignature, ITypstFunction
{
    public Text(Content content, string? font = null, string? size = null) : base(font, size)
    {
        Builder.Content(content);
    }
}