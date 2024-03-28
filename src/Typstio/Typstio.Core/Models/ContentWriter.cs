using Typstio.Core.Contracts;

namespace Typstio.Core.Models;

public class ContentWriter
{
    readonly List<object> _elements = new();

    public IReadOnlyCollection<object> Elements => _elements;

    public ContentWriter WriteString(string str)
    {
        _elements.Add(str);
        return this;
    }

    public ContentWriter WriteFunction(ITypstFunction function)
    {
        _elements.Add(function);
        return this;
    }

    public ContentWriter SetRule(ISetRule rule)
    {
        _elements.Add(rule);
        return this;
    }

    public ContentWriter SetRuleLine(ISetRule rule)
    {
        _elements.Add(rule);
        NextLine();
        return this;
    }

    public ContentWriter NextLine()
    {
        _elements.Add("\n");
        return this;
    }
    
    public ContentWriter WriteBlock()
    {
        _elements.Add("\n\n");
        return this;
    }
}