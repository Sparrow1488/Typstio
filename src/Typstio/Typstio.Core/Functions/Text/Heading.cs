using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Text;

public class Heading : TypstFunction
{
    public Heading(int level, Content content) : base("heading")
    {
        Argument("level", level);
        Content(content);
    }

    public Heading(int level, string text) : this(level, w => w.WriteString(text))
    {
        
    }
}