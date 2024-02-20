namespace Typstio.Core.Functions.Colors;

public class Luma : ColorFunction
{
    public Luma(byte value) : base("luma")
    {
        Argument(value, required: true);
    }
}