using Typstio.Core.Contracts;
using Typstio.Core.Scripting;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Text : ElementFunction, IContentWritable
{
    private const string Name = "text";
    private const string FontArg = "font";

    private readonly Action<ContentWriter> _content;
    private readonly string? _font;
    
    public Text(Action<ContentWriter> content, string? font = null)
    {
        _content = content;
        _font = font;
    }
    
    public void WriteToDocument(ContentWriter writer)
    {
        var text = new FunctionBuilder(Name)
            .WithArg(new NamedArg(FontArg, _font))
            .WithContent(_content);

        writer.WriteFunction(text);
    }
}