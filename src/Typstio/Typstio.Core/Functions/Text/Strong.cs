using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Text;

public class Strong : TypstFunction
{
    public Strong(Content content) : base("strong")
    {
        Content(content);
    }

    public Strong(string text) : this(w => w.WriteString(text))
    {
        
    }
}