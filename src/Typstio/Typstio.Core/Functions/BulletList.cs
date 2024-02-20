using Typstio.Core.Contracts;
using Typstio.Core.Scripting;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class BulletList : ElementFunction, IContentWritable
{
    private const string Name = "list";
    
    private readonly IEnumerable<Action<ContentWriter>> _items;

    public BulletList(IEnumerable<Action<ContentWriter>> items)
    {
        _items = items;
    }
    
    public void WriteToDocument(ContentWriter writer)
    {
        writer.WriteFunction(
            new FunctionBuilder(Name)
                .WithContents(_items)
        );
    }
}