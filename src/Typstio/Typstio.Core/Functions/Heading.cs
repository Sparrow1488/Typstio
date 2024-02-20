using Typstio.Core.Contracts;
using Typstio.Core.Scripting;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Heading : ElementFunction, IContentWritable
{
    private const string Name = "heading";
    private const string LevelArg = "level";
    
    private readonly int _level;
    private readonly Action<ContentWriter> _content;

    public Heading(int level, Action<ContentWriter> content)
    {
        _level = level;
        _content = content;
    }

    public void WriteToDocument(ContentWriter writer)
    {
        writer.WriteFunction(
            new FunctionBuilder(Name)
                .WithArg(new NamedArg(LevelArg, _level))
                .WithContent(_content)
        );
    }
}