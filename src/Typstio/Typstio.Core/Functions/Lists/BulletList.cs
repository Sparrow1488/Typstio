using Typstio.Core.Models;

namespace Typstio.Core.Functions.Lists;

public class BulletList : TypstFunction
{
    public BulletList(IEnumerable<Content> items) : base("list")
    {
        Content(items);
    }
}