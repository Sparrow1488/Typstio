using Typstio.Core.Contracts;
using Typstio.Core.Scripting;

namespace Typstio.Core.Models;

public abstract class TypstFunction : IContentWritable
{
    private readonly FunctionBuilder _builder;

    protected TypstFunction(string name)
    {
        _builder = new FunctionBuilder(name);
    }

    public string Name => _builder.Name;
    public IReadOnlyCollection<FunctionArgument> Args => _builder.Args;
    
    /// <summary>
    /// Positional Argument
    /// </summary>
    protected void Argument(object? value, bool required = false) 
        => AddArgumentIfValid(new PositionalArgument(value, IsRequired: required), value, required);

    /// <summary>
    /// Named Argument
    /// </summary>
    protected void Argument(string name, object? value, bool required = false) 
        => AddArgumentIfValid(new ArgumentWithName(name, value, IsRequired: required), value, required);

    protected void ArgumentFunc(string name, TypstFunction? func, bool required = false) 
        => AddArgumentIfValid(new FunctionArgumentWithName(name, func, IsRequired: required), func, required);

    /// <summary>
    /// Named Content Argument
    /// </summary>
    protected void Argument(string name, Content? value, bool required = false)
    {
        var content = new ContentWriter();
        value?.Invoke(content);
        AddArgumentIfValid(new ContentArgumentWithName(name, content, required), value, required);
    }
    
    protected void Content(Content content) 
        => _builder.WithContent(content);
    
    protected void Content(IEnumerable<Content> contents) 
        => _builder.WithContents(contents);
    
    public void WriteToContent(ContentWriter writer)
    {
        writer.WriteFunction(this);
    }

    private void AddArgumentIfValid(FunctionArgument arg, object? value, bool required)
    {
        Require(value, required);
        
        if (value is not null)
            _builder.WithArg(arg);
    }

    private static void Require(object? value, bool required)
    {
        if (required && value is null)
            throw new ArgumentException("Value should not be null");
    }
}