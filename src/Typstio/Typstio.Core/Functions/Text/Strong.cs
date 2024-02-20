using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Text;

public class Strong : TypstFunction
{
    public Strong(Action<ContentWriter> content) : base("strong")
    {
        Content(content);
    }
}