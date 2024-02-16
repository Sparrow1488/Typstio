using Typstio.Core.Contracts;

namespace Typstio.Core.Elements;

public class List : Element
{
    public List<ListItem> Items { get; } = new();
    
    public List AddItem(ListItem item)
    {
        Items.Add(item);
        return this;
    }
}

public enum ItemStyle
{
    Dot,
    Line,
    Numeric
}

public class ListItem
{
    private readonly List<ListItem> _nested = new();

    public ListItem(string text, ItemStyle style)
    {
        Text = text;
        Style = style;
    }
    
    public string Text { get; }
    public ItemStyle Style { get; }
    public IReadOnlyCollection<ListItem> Nested => _nested;

    public ListItem Add(ListItem nested)
    {
        _nested.Add(nested);
        return this;
    }
}