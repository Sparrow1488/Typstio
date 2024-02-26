namespace Typstio.Core.Models;

public class ContentWriter
{
    private readonly List<object> _elements = new();

    public IReadOnlyCollection<object> Elements => _elements;

    public ContentWriter WriteString(string str)
    {
        _elements.Add(str);
        return this;
    }

    public ContentWriter WriteFunction(TypstFunction function)
    {
        _elements.Add(function);
        return this;
    }
    
    public ContentWriter WriteEmptyBlock()
    {
        _elements.Add("\n\n");
        return this;
    }
}