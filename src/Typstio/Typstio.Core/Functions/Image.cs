using Typstio.Core.Contracts;

namespace Typstio.Core.Functions;

public class Image : ElementFunction
{
    public Image(string str, string? width = null, string? height = null) : base("image")
    {
        Argument(str, required: true);
        Argument("width", width);
        Argument("height", height);
    }
}