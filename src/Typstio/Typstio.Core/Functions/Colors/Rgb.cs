using Typstio.Core.Extensions;
using Typstio.Core.Foundations;

namespace Typstio.Core.Functions.Colors;

public class Rgb : ColorFunction
{
    public Rgb(string hex) : base("rgb")
    {
        Builder.Argument(new Str(hex), required: true);
    }
}