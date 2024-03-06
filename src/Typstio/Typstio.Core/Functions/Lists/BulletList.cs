using Typstio.Core.Extensions;
using Typstio.Core.Models;

namespace Typstio.Core.Functions.Lists;

public class BulletList : TypstFunction
{
    public BulletList(IEnumerable<Content> items) : base("list")
    {
        Builder.Content(items);
    }
}