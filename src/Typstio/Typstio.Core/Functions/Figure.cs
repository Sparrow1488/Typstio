using Typstio.Core.Contracts;
using Typstio.Core.Scripting;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Figure : ElementFunction, IContentWritable
{
    private const string Name = "figure";
    private const string CaptionArg = "caption";
    
    private readonly Action<ContentWriter> _content;
    private readonly ContentWriter _caption;
    
    public Figure(Action<ContentWriter> content, Action<ContentWriter> caption)
    {
        _content = content;
        
        var captionWriter = new ContentWriter();
        caption.Invoke(captionWriter);

        _caption = captionWriter;
    }
    
    public void WriteToContent(ContentWriter writer)
    {
        writer.WriteFunction(
            new FunctionBuilder(Name)
                .WithArg(new NamedContentArg(CaptionArg, _caption))
                .WithContent(_content)
        );
    }
}