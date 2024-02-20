using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Text;

public class Text : TypstFunction
{
    public Text(Content content, string? font = null) : base("text")
    {
        Argument("font", font);
        Content(content);
    }

    public Text(string text, string? font = null) : this(w => w.WriteString(text), font)
    {
        
    }
}