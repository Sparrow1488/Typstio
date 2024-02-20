using Typstio.Core.Contracts;
using Typstio.Core.Scripting;
using Typstio.Core.Types;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Table : ElementFunction, IContentWritable
{
    private const string Name = "table";
    private const string ColumnsArg = "columns";
    private const string InsetArg = "inset";
    private const string AlignArg = "align";

    private readonly IEnumerable<string> _columns;
    private readonly IEnumerable<Action<ContentWriter>> _contents;
    private readonly string? _inset;
    private readonly string? _align;

    public Table(IEnumerable<string> columns, IEnumerable<Action<ContentWriter>> contents, string? inset = null, string? align = null)
    {
        _columns = columns;
        _contents = contents;
        _inset = inset;
        _align = align;
    }
    
    public void WriteToContent(ContentWriter writer)
    {
        writer.WriteFunction(
            new FunctionBuilder(Name)
                .WithArg(new NamedArg(ColumnsArg, new Arr(_columns)))
                .WithArg(new NamedArg(AlignArg, _align))
                .WithArg(new NamedArg(InsetArg, _inset))
                .WithContents(_contents)
        );
    }
}