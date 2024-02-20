using Typstio.Core.Scripting;
using Typstio.Core.Writers;

namespace Typstio.Core.Contracts;

public abstract class Function
{
    
}

public abstract class Function<TReturn> : Function
{
    
}

public abstract class ElementFunction : Function<Element>, IContentWritable
{
    private readonly FunctionBuilder _builder;

    protected ElementFunction(string name)
    {
        _builder = new FunctionBuilder(name);
    }
    
    /// <summary>
    /// Positional Argument
    /// </summary>
    protected void Argument(object? value, bool required = false) 
        => _builder.WithArg(new PositionalArg(value, IsRequired: required));

    /// <summary>
    /// Named Argument
    /// </summary>
    protected void Argument(string name, object? value, bool required = false) 
        => _builder.WithArg(new NamedArg(name, value, IsRequired: required));

    /// <summary>
    /// Named Content Argument
    /// </summary>
    protected void Argument(string name, Action<ContentWriter>? value, bool required = false)
    {
        var content = new ContentWriter();
        value?.Invoke(content);
        _builder.WithArg(new NamedContentArg(name, content, required));
    }
    
    protected void Content(Action<ContentWriter> content) 
        => _builder.WithContent(content);
    
    protected void Content(IEnumerable<Action<ContentWriter>> contents) 
        => _builder.WithContents(contents);
    
    public void WriteToContent(ContentWriter writer)
    {
        writer.WriteFunction(_builder);
    }
}