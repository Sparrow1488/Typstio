using Typstio.Core.Contracts;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Lists;

public class BulletList : TypstFunction
{
    public BulletList(IEnumerable<Action<ContentWriter>> items) : base("list")
    {
        Content(items);
    }
}