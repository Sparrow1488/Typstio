using Typstio.Core.Extensions;
using Typstio.Core.Models;

namespace Typstio.Core.Functions.Text;

public class Strong : TypstFunction
{
    public Strong(Content content) : base("strong")
    {
        Builder.Content(content);
    }

    public Strong(string text) : this(w => w.WriteString(text))
    {
        
    }
}