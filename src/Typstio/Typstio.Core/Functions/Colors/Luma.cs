using Typstio.Core.Extensions;

namespace Typstio.Core.Functions.Colors;

public class Luma : ColorFunction
{
    public Luma(byte value) : base("luma")
    {
        Builder.Argument(value, required: true);
    }
}