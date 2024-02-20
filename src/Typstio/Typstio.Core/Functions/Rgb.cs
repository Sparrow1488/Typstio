using Typstio.Core.Contracts;
using Typstio.Core.Types;

namespace Typstio.Core.Functions;

public class Rgb : TypstFunction
{
    public Rgb(string hex) : base("rgb")
    {
        Argument(new Str(hex), required: true);
    }
}