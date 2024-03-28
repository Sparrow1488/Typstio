using Typstio.Core.Models;

namespace Typstio.Core.Scripting;

public class SignatureBuilder
{
    readonly List<SignatureArgument> _arguments = new();

    public SignatureBuilder(string name)
    {
        Name = name;
    }
    
    public string Name { get; }
    public IEnumerable<SignatureArgument> Arguments => _arguments;

    public SignatureBuilder WithArgument(SignatureArgument arg)
    {
        _arguments.Add(arg);
        return this;
    }
    
    public SignatureBuilder WithContent(Content content)
    {
        var writer = new ContentWriter();
        content.Invoke(writer);
        _arguments.Add(new ContentArgument(writer));
        return this;
    }

    public SignatureBuilder WithContents(IEnumerable<Content> contents)
    {
        foreach (var content in contents)
            WithContent(content);

        return this;
    }
}