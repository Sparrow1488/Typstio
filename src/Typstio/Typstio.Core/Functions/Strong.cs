using Typstio.Core.Contracts;
using Typstio.Core.Scripting;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Strong : ElementFunction, IContentWritable
{
    private const string Name = "strong";

    private readonly Action<ContentWriter> _content;

    public Strong(Action<ContentWriter> content)
    {
        _content = content;
    }

    public void WriteToDocument(ContentWriter writer)
    {
        writer.WriteFunction(
            new FunctionBuilder(Name)
                .WithContent(_content)
        );
    }
}