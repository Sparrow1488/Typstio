using Typstio.Core.Contracts;
using Typstio.Core.Types;

namespace Typstio.Core.Functions;

public class Image : Function
{
    public Image(string str, string? width = null, string? height = null) : base("image")
    {
        Argument(new Str(str), required: true);
        Argument("width", width);
        Argument("height", height);
    }
}