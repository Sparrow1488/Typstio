using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Heading : ElementFunction
{
    public Heading(int level, Action<ContentWriter> content) : base("heading")
    {
        Argument("level", level);
        Content(content);
    }
}