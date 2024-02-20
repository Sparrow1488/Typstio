using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Text;

public class Text : TypstFunction
{
    public Text(Action<ContentWriter> content, string? font = null) : base("text")
    {
        Argument("font", font);
        Content(content);
    }
}