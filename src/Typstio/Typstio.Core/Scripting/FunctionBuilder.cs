using Typstio.Core.Writers;

namespace Typstio.Core.Scripting;

public class FunctionBuilder
{
    private readonly List<FuncArg> _args = new();

    public FunctionBuilder(string name)
    {
        Name = name;
    }
    
    public string Name { get; }
    public IReadOnlyCollection<FuncArg> Args => _args;

    public FunctionBuilder WithArg(FuncArg arg)
    {
        _args.Add(arg);
        return this;
    }
    
    public FunctionBuilder WithContent(Action<ContentWriter> content)
    {
        var writer = new ContentWriter();
        content.Invoke(writer);
        _args.Add(new ContentArg(writer));
        return this;
    }

    public FunctionBuilder WithContents(IEnumerable<Action<ContentWriter>> contents)
    {
        foreach (var content in contents)
            WithContent(content);

        return this;
    }
}