using Typstio.Core.Extensions;
using Typstio.Core.Foundations;
using Typstio.Core.Models;

namespace Typstio.Core.Functions;

public class Image : TypstFunction
{
    public Image(string str, string? width = null, string? height = null) : base("image")
    {
        Builder.Argument(new Str(str), required: true);
        Builder.Argument("width", width);
        Builder.Argument("height", height);
    }
}