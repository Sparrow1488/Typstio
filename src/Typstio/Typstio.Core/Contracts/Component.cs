namespace Typstio.Core.Contracts;

public class Component : Element
{
    private readonly List<Element> _elements = new();
    
    public IReadOnlyCollection<Element> Elements => _elements;

    public void AddElement(Element element)
    {
        _elements.Add(element);
    }
}