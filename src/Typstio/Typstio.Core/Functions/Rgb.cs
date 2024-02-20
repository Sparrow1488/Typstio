using Typstio.Core.Contracts;
using Typstio.Core.Types;

namespace Typstio.Core.Functions;

public class Rgb : Function
{
    public Rgb(string hex) : base("rgb")
    {
        Argument(new Str(hex), required: true);
    }
}