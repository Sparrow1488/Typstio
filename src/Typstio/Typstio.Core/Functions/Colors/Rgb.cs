using Typstio.Core.Foundations;

namespace Typstio.Core.Functions.Colors;

public class Rgb : ColorFunction
{
    public Rgb(string hex) : base("rgb")
    {
        Argument(new Str(hex), required: true);
    }
}