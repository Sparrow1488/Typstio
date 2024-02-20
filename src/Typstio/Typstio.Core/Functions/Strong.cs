using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Strong : Function
{
    public Strong(Action<ContentWriter> content) : base("strong")
    {
        Content(content);
    }
}