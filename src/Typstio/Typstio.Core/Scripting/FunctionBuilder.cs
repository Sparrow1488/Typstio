using Typstio.Core.Models;

namespace Typstio.Core.Scripting;

public class FunctionBuilder
{
    private readonly List<FunctionArgument> _args = new();

    public FunctionBuilder(string name)
    {
        Name = name;
    }
    
    public string Name { get; }
    public IReadOnlyCollection<FunctionArgument> Args => _args;

    public FunctionBuilder WithArg(FunctionArgument arg)
    {
        _args.Add(arg);
        return this;
    }
    
    public FunctionBuilder WithContent(Content content)
    {
        var writer = new ContentWriter();
        content.Invoke(writer);
        _args.Add(new ContentArgument(writer));
        return this;
    }

    public FunctionBuilder WithContents(IEnumerable<Content> contents)
    {
        foreach (var content in contents)
            WithContent(content);

        return this;
    }
}