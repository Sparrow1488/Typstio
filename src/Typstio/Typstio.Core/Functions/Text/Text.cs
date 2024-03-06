using Typstio.Core.Contracts;
using Typstio.Core.Extensions;
using Typstio.Core.Foundations;
using Typstio.Core.Models;

namespace Typstio.Core.Functions.Text;

public abstract class TextSignature : SignatureBase
{
    protected TextSignature(string? font, string? size, string? lang) : base("text")
    {
        Builder.Argument("font", new Str(font));
        Builder.Argument("size", size);
        Builder.Argument("lang", new Str(lang));
    }
}

public class TextRule : TextSignature, ISetRule
{
    public TextRule(string? font = null, string? size = null, string? lang = null) : base(font, size, lang)
    {
    }
}

public class Text : TextSignature, ITypstFunction
{
    public Text(Content content, string? font = null, string? size = null, string? lang = null) : base(font, size, lang)
    {
        Builder.Content(content);
    }
}